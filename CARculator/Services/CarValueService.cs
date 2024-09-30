using CARculator.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.Services
{
    public class CarValueService
    {
        private readonly HttpClient _client;

        public CarValueService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36");
        }

        public async Task<double> GetCarAveragePriceAsync(string modelUrl, int maxPages)
        {
            var (totalOffers, totalPrices) = await CountOtomotoOffersMultiplePagesAsync(modelUrl, maxPages);

            if (totalOffers > 0 && totalPrices.Any())
            {
                double averagePrice = totalPrices.Average();
                return averagePrice;
            }
            else
            {
                throw new Exception("Nie udało się pobrać danych o cenach.");
            }
        }

        private async Task<(int totalOffers, List<double> totalPrices)> CountOtomotoOffersMultiplePagesAsync(string baseUrl, int maxPages)
        {
            int totalOffers = 0;
            List<double> totalPrices = new List<double>();
            int pageNum = 1;

            while (pageNum <= maxPages)
            {
                string url = $"{baseUrl}&page={pageNum}";
                var (offersCount, prices) = await CountOtomotoOffersAsync(url);

                if (offersCount >= 0 && prices != null)
                {
                    totalOffers += offersCount;
                    totalPrices.AddRange(prices);

                    if (offersCount < 32)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

                pageNum++;
            }

            return (totalOffers, totalPrices);
        }
        public static class OtomotoUrlBuilder
        {
            public static string BuildUrl(
                string brand,
                string model,
                string generation,
                FuelType? fuelType,
                TransmissionType? transmissionType,
                string engineCapacityFrom,
                string engineCapacityTo,
                string productionYearFrom = null,
                string productionYearTo = null)
            {
                var formattedModel = model.ToLower().Replace(" ", "-");

                if (brand.ToLower() == "mercedes-benz")
                {
                    if (formattedModel.ToLower() == "klasa-e")
                    {
                        formattedModel = "e-klasa";
                    }
                    else if (formattedModel.ToLower() == "klasa-c")
                    {
                        formattedModel = "c-klasa";
                    }
                }

                var baseUrl = $"https://www.otomoto.pl/osobowe/{brand.ToLower()}/{formattedModel}";

                var queryParams = new List<string>();

                if (fuelType.HasValue)
                {
                    queryParams.Add($"search%5Bfilter_enum_fuel_type%5D={fuelType.Value.ToString().ToLower()}");
                }

                if (transmissionType.HasValue)
                {
                    queryParams.Add($"search%5Bfilter_enum_gearbox%5D={transmissionType.Value.ToString().ToLower()}");
                }

                
                if (!string.IsNullOrEmpty(generation))
                {
                    if (brand.ToLower() == "audi" && generation == "C7")
                    {
                        queryParams.Add($"search%5Bfilter_enum_generation%5D=gen-{generation.ToLower()}-{productionYearFrom}");
                    }
                    else if (brand.ToLower() == "mercedes-benz" && generation == "W212")
                    {
                        queryParams.Add($"search%5Bfilter_enum_generation%5D=gen-{generation.ToLower()}-{productionYearFrom}");
                    }
                    else if (brand.ToLower() == "bmw" && (generation == "G30" || generation == "F10"))
                    {
                        queryParams.Add($"search%5Bfilter_enum_generation%5D=gen-{generation.ToLower()}-{productionYearFrom}");
                    }
                    else
                    {
                        queryParams.Add($"search%5Bfilter_enum_generation%5D=gen-{generation.ToLower()}-{productionYearFrom}-{productionYearTo}");
                    }
                }

                if (!string.IsNullOrEmpty(engineCapacityFrom) && !string.IsNullOrEmpty(engineCapacityTo))
                {
                    queryParams.Add($"search%5Bfilter_float_engine_capacity%3Afrom%5D={engineCapacityFrom}");
                    queryParams.Add($"search%5Bfilter_float_engine_capacity%3Ato%5D={engineCapacityTo}");
                }

                queryParams.Add("search%5Badvanced_search_expanded%5D=true");

                var queryString = string.Join("&", queryParams);

                return $"{baseUrl}?{queryString}";
            }
        }





        public async Task<(int offersCount, List<double> prices)> CountOtomotoOffersAsync(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var pageContents = await response.Content.ReadAsStringAsync();

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(pageContents);

                    var offersCountNode = doc.DocumentNode.SelectSingleNode("//p[contains(@class, 'e17gkxda2 ooa-17owgto er34gjf0')]//b");
                    int offersCount = 0;
                    if (offersCountNode != null)
                    {
                        string offersCountText = offersCountNode.InnerText.Trim();
                        if (int.TryParse(offersCountText, out int count))
                        {
                            offersCount = count;
                        }
                    }

                    // ceny
                    var priceNodes = doc.DocumentNode.SelectNodes("//h3[contains(@class, 'efpuxbr16 ooa-1n2paoq er34gjf0')]");

                    List<double> prices = new List<double>();

                    if (priceNodes != null)
                    {
                        foreach (var priceNode in priceNodes)
                        {
                            string priceText = priceNode.InnerText.Trim().Replace(" ", "").Replace(",", ".");
                            if (double.TryParse(priceText, out double price))
                            {
                                prices.Add(price);
                            }
                        }
                    }

                    return (offersCount, prices);
                }
                else
                {
                    Console.WriteLine($"Nie udało się pobrać zawartości strony. Kod błędu: {response.StatusCode}");
                    return (0, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił błąd podczas przetwarzania strony: {e.Message}");
                return (0, null);
            }
        }

    }
}
