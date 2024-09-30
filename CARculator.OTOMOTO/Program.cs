using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CARculator.OTOMOTO
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "https://www.otomoto.pl/osobowe/audi/a4/od-2008?search%5Bfilter_enum_fuel_type%5D=petrol&search%5Bfilter_enum_generation%5D=gen-b8-2007-2015&search%5Bfilter_float_year%3Ato%5D=2008";
            int maxPages = 8;

            var (offersCount, prices) = await CountOtomotoOffersMultiplePages(baseUrl, maxPages);

            if (offersCount >= 0 && prices != null)
            {
                Console.WriteLine($"Liczba ofert na Otomoto: {offersCount}");
                if (prices.Count > 0)
                {
                    double averagePrice = prices.Average();
                    Console.WriteLine($"Średnia cena: {Math.Round(averagePrice, 2)} zł");
                }
                else
                {
                    Console.WriteLine("Brak danych o cenach.");
                }
            }
            else
            {
                Console.WriteLine("Wystąpił błąd podczas przetwarzania ofert.");
            }


        }



        static async Task<(int offersCount, List<double> prices)> CountOtomotoOffers(string url)
        {
            try
            {
                using HttpClient client = new HttpClient();

                // Dodanie nagłówka User-Agent
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36");

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var pageContents = await response.Content.ReadAsStringAsync();

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(pageContents);

                    // Znalezienie wszystkich cen
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
                        // Liczba ofert to liczba znalezionych cen
                        return (prices.Count, prices);
                    }
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

            return (0, null);
        }

        static async Task<(int totalOffers, List<double> totalPrices)> CountOtomotoOffersMultiplePages(string baseUrl, int maxPages)
        {
            int totalOffers = 0;
            List<double> totalPrices = new List<double>();
            int pageNum = 1;

            while (pageNum <= maxPages)
            {
                string url = $"{baseUrl}&page={pageNum}";
                var (offersCount, prices) = await CountOtomotoOffers(url);

                if (offersCount >= 0 && prices != null)
                {
                    totalOffers += offersCount;
                    totalPrices.AddRange(prices);

                    // Sprawdzenie, czy liczba ofert na stronie jest mniejsza niż 32
                    if (offersCount < 32)
                    {
                        Console.WriteLine($"Liczba ofert poniżej 32 na stronie {pageNum}. Zakończono paginację.");
                        break;
                    }
                }
                else
                {
                    break; // Przerwij pętlę w przypadku błędu
                }

                pageNum++;
            }

            return (totalOffers, totalPrices);
        }
    }
}
