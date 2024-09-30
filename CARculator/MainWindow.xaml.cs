using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using CARculator.DynamicServices;
using CARculator.Models;
using CARculator.OTOMOTO;
using CARculator.Services;
using CARculator.Views;
using static CARculator.Services.CarValueService;

namespace CARculator
{
    public partial class MainWindow : Window
    {
        private CarService carService;
        private CarValueService carValueService;
        private bool isMenuExpanded = false;
        private string _linkOtomoto;

        public MainWindow()
        {
            InitializeComponent();
            carService = new CarService();
            carValueService = new CarValueService();
            LoadBrands();
            //DisplayDynamicCars();
        }

        //private void OnLoadDynamicCarsClicked(object sender, RoutedEventArgs e)
        //{
        //    DisplayDynamicCars();
        //}

        //private void DisplayDynamicCars()
        //{
        //    var cars = DynamicCarStorage.Instance.GetCars();
        //    CarListView.ItemsSource = cars;
        //}

        private void LoadBrands()
        {
            var brands = carService.GetFilteredCars(null, null, null, null, null, null, null, null, null, null)
                                   .Select(car => car.Brand)
                                   .Distinct()
                                   .ToList();
            BrandComboBox.ItemsSource = brands;

            FuelTypeComboBox.ItemsSource = Enum.GetValues(typeof(FuelType)).Cast<FuelType>().ToList();
        }

        private void OnBrandSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedBrand))
            {
                ModelComboBox.ItemsSource = null;
                ModelComboBox.IsEnabled = false;
                return;
            }

            var models = carService.GetFilteredCars(selectedBrand, null, null, null, null, null, null, null, null, null)
                                   .Select(car => car.Model)
                                   .Distinct()
                                   .ToList();
            ModelComboBox.ItemsSource = models;
            ModelComboBox.IsEnabled = true;

            GenerationComboBox.ItemsSource = null;
            GenerationComboBox.IsEnabled = false;
            FuelTypeComboBox.ItemsSource = null;
            FuelTypeComboBox.IsEnabled = false;
            EngineComboBox.ItemsSource = null;
            EngineComboBox.IsEnabled = false;

            CheckIfApplyFiltersButtonShouldBeEnabled();
        }

        private void OnModelSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandComboBox.SelectedItem as string;
            var selectedModel = ModelComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedBrand) || string.IsNullOrEmpty(selectedModel))
            {
                GenerationComboBox.ItemsSource = null;
                GenerationComboBox.IsEnabled = false;
                return;
            }

            var generations = carService.GetFilteredCars(selectedBrand, selectedModel, null, null, null, null, null, null, null, null)
                                        .Select(car => car.Generation)
                                        .Distinct()
                                        .ToList();
            GenerationComboBox.ItemsSource = generations;
            GenerationComboBox.IsEnabled = true;

            FuelTypeComboBox.ItemsSource = null;
            FuelTypeComboBox.IsEnabled = false;
            EngineComboBox.ItemsSource = null;
            EngineComboBox.IsEnabled = false;

            CheckIfApplyFiltersButtonShouldBeEnabled();
        }

        private void OnGenerationSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandComboBox.SelectedItem as string;
            var selectedModel = ModelComboBox.SelectedItem as string;
            var selectedGeneration = GenerationComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedBrand) || string.IsNullOrEmpty(selectedModel) || string.IsNullOrEmpty(selectedGeneration))
            {
                FuelTypeComboBox.ItemsSource = null;
                FuelTypeComboBox.IsEnabled = false;
                EngineComboBox.ItemsSource = null;
                EngineComboBox.IsEnabled = false;
                return;
            }

            var cars = carService.GetFilteredCars(selectedBrand, selectedModel, selectedGeneration, null, null, null, null, null, null, null);
            var fuelTypes = cars.Select(car => car.FuelType).Distinct().ToList();
            FuelTypeComboBox.ItemsSource = fuelTypes;
            FuelTypeComboBox.IsEnabled = true;

            EngineComboBox.ItemsSource = null;
            EngineComboBox.IsEnabled = false;

            CheckIfApplyFiltersButtonShouldBeEnabled();
        }
        private void OnFuelTypeSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandComboBox.SelectedItem as string;
            var selectedModel = ModelComboBox.SelectedItem as string;
            var selectedGeneration = GenerationComboBox.SelectedItem as string;
            var selectedFuelType = FuelTypeComboBox.SelectedItem as FuelType?;

            if (string.IsNullOrEmpty(selectedBrand) || string.IsNullOrEmpty(selectedModel) || string.IsNullOrEmpty(selectedGeneration) || selectedFuelType == null)
            {
                EngineComboBox.ItemsSource = null;
                EngineComboBox.IsEnabled = false;
                return;
            }

            var cars = carService.GetFilteredCars(selectedBrand, selectedModel, selectedGeneration, null, null, null, null, null, selectedFuelType, null);
            var engines = cars.SelectMany(car => car.Engines)
                              .Select(engine => engine.Type)
                              .Distinct()
                              .ToList();

            EngineComboBox.ItemsSource = engines;
            EngineComboBox.IsEnabled = true;

            CheckIfApplyFiltersButtonShouldBeEnabled();
        }
        private void OnTransmissionSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandComboBox.SelectedItem as string;
            var selectedModel = ModelComboBox.SelectedItem as string;
            var selectedGeneration = GenerationComboBox.SelectedItem as string;
            var selectedFuelType = FuelTypeComboBox.SelectedItem as FuelType?;
            var selectedEngineType = EngineComboBox.SelectedItem as string;
            var selectedTransmission = TransmissionComboBox.SelectedItem as TransmissionType?;

            var cars = carService.GetFilteredCars(selectedBrand, selectedModel, selectedGeneration,
                                                  null, null, selectedTransmission, null, null, selectedFuelType, selectedEngineType);

        }
        private void OnEngineSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandComboBox.SelectedItem as string;
            var selectedModel = ModelComboBox.SelectedItem as string;
            var selectedGeneration = GenerationComboBox.SelectedItem as string;
            var selectedFuelType = FuelTypeComboBox.SelectedItem as FuelType?;
            var selectedEngineType = EngineComboBox.SelectedItem as string;

            var cars = carService.GetFilteredCars(selectedBrand, selectedModel, selectedGeneration,
                                                  null, null, null, null, null, selectedFuelType, selectedEngineType);

            var transmissions = cars.SelectMany(car => car.Transmissions)
                                     .Distinct()
                                     .ToList();

            TransmissionComboBox.ItemsSource = transmissions;
            TransmissionComboBox.IsEnabled = true;
        }
        private async void OnApplyFiltersClicked(object sender, RoutedEventArgs e)
        {
            var brand = BrandComboBox.SelectedItem as string;
            var model = ModelComboBox.SelectedItem as string;
            var generation = GenerationComboBox.SelectedItem as string;
            var fuelType = FuelTypeComboBox.SelectedItem as FuelType?;
            var transmissionType = TransmissionComboBox.SelectedItem as TransmissionType?;
            var carService = new CarService();
            var selectedEngineType = EngineComboBox.Text;

            var selectedFuelType = fuelType ?? FuelType.Petrol;
            var selectedTransmissionType = transmissionType ?? TransmissionType.Manual;

            // szczegoly silnika
            var engine = GetEngineDetails(brand, model, generation, selectedEngineType, selectedFuelType);
            var engineCapacityFrom = engine?.Capacity.Split('-').FirstOrDefault();
            var engineCapacityTo = engine?.Capacity.Split('-').LastOrDefault();

            // lata
            var productionYears = CarModelHelper.GetProductionYears(carService.GetAllCars(), brand, model, generation, selectedFuelType);
            var years = productionYears.Split('-');
            var productionYearFrom = years.Length > 0 ? years[0] : string.Empty;
            var productionYearTo = years.Length > 1 ? years[1] : string.Empty;

            // url builder
            var otomotoUrl = OtomotoUrlBuilder.BuildUrl(
                brand,
                model,
                generation,
                fuelType,
                transmissionType,
                engineCapacityFrom,
                engineCapacityTo,
                productionYearFrom,
                productionYearTo);

            _linkOtomoto = otomotoUrl;

            var filteredCars = carService.GetFilteredCars(
                brand,
                model,
                generation,
                null, // Year
                null, // Engine Capacity
                selectedTransmissionType, // Przekazuje null, jeśli brak wartości
                null, // Mileage
                null, // Average Price
                fuelType,
                selectedEngineType
            );

            try
            {
                var carValueService = new CarValueService(); // Utwórz instancję CarValueService
                var (offersCount, prices) = await carValueService.CountOtomotoOffersAsync(otomotoUrl);

                double averagePrice = prices.Any() ? prices.Average() : 0;

                AveragePriceLabel.Content = $"Liczba ogłoszeń: {offersCount}, Średnia cena: {Math.Round(averagePrice, 2)} zł";

                UpdateResultsListBoxWithCarDetails(filteredCars, engine);
            }
            catch (Exception ex)
            {
                AveragePriceLabel.Content = $"Błąd: {ex.Message}";
            }
        }
        private void CheckIfApplyFiltersButtonShouldBeEnabled()
        {
            bool isBrandSelected = BrandComboBox.SelectedItem != null;
            bool isModelSelected = ModelComboBox.SelectedItem != null;
            bool isGenerationSelected = GenerationComboBox.SelectedItem != null;
            bool isFuelTypeSelected = FuelTypeComboBox.SelectedItem != null;

            ApplyFiltersButton.IsEnabled = isBrandSelected && isModelSelected && isGenerationSelected && isFuelTypeSelected;
        }
        private Engine GetEngineDetails(string brand, string model, string generation, string engineType, FuelType fuelType)
        {
            var engines = CarModelHelper.GetEnginesForModel(brand, model, generation, fuelType);
            CheckIfApplyFiltersButtonShouldBeEnabled();
            var engine = engines.FirstOrDefault(e => e.Type == engineType);

            return engine;
        }
        private void UpdateResultsListBoxWithCarDetails(List<Car> cars, Engine selectedEngine)
        {
            ResultsListBox.Items.Clear();

            foreach (var car in cars)
            {
                var carDetails = new StringBuilder();

                carDetails.AppendLine($"Marka: {car.Brand}");
                carDetails.AppendLine($"Model: {car.Model}");
                carDetails.AppendLine($"Generacja: {car.Generation}");
                carDetails.AppendLine($"Rok produkcji: {car.ProductionYear}");
                carDetails.AppendLine($"Typ paliwa: {car.FuelType}");
                carDetails.AppendLine($"Skrzynie: {string.Join(", ", car.Transmissions)}");


                // Dodaj szczegóły wybranego silnika, jeśli istnieje
                if (selectedEngine != null && car.Engines.Any(e => e.Type == selectedEngine.Type))
                {
                    carDetails.AppendLine("Wybrany silnik:");
                    carDetails.AppendLine($"  Typ: {selectedEngine.Type}");
                    carDetails.AppendLine($"  Pojemność: {selectedEngine.Capacity}");
                    carDetails.AppendLine($"  Moc: {selectedEngine.Power} KM");
                }
                else
                {
                    carDetails.AppendLine("Brak wybranego silnika w tym samochodzie.");
                }

                ResultsListBox.Items.Add(new ListBoxItem
                {
                    Content = carDetails.ToString(),
                    Margin = new Thickness(0, 0, 0, 10)
                });
            }
        }
        private void OnCopyLinkClicked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_linkOtomoto))
            {
                Clipboard.SetText(_linkOtomoto);
                MessageBox.Show("Link skopiowany do schowka.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Brak linku do skopiowania.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnOpenLinkClicked(object sender, RoutedEventArgs e)
        {
            var link = _linkOtomoto;
            if (!string.IsNullOrEmpty(link))
            {
                try
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = link,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Nie udało się otworzyć linku. Błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Brak linku do otwarcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnResetSearchClicked(object sender, RoutedEventArgs e)
        {
            BrandComboBox.SelectedIndex = -1;
            ModelComboBox.SelectedIndex = -1;
            GenerationComboBox.SelectedIndex = -1;
            EngineComboBox.SelectedIndex = -1;
            FuelTypeComboBox.SelectedIndex = -1;
            TransmissionComboBox.SelectedIndex = -1;
            AveragePriceLabel.Content = "";

            ResultsListBox.Items.Clear();

            _linkOtomoto = null; 
        }

        private void OnToggleMenuClicked(object sender, RoutedEventArgs e)
        {
            if (isMenuExpanded)
            {
                CollapseMenu();
            }
            else
            {
                ExpandMenu();
            }
        }
        private void ExpandMenu()
        {
            var widthAnimation = new DoubleAnimation
            {
                From = MenuPanel.Width,
                To = 200,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            MenuPanel.BeginAnimation(Grid.WidthProperty, widthAnimation);

            foreach (var child in MenuItemsPanel.Children)
            {
                if (child is Button btn && btn.Content is StackPanel stackPanel)
                {
                    foreach (var innerChild in stackPanel.Children)
                    {
                        if (innerChild is TextBlock textBlock)
                        {
                            textBlock.Visibility = Visibility.Visible;
                        }
                    }
                }
            }

            isMenuExpanded = true;
        }
        private void CollapseMenu()
        {
            var widthAnimation = new DoubleAnimation
            {
                From = MenuPanel.Width,
                To = 60,
                Duration = new Duration(TimeSpan.FromMilliseconds(300))
            };

            MenuPanel.BeginAnimation(Grid.WidthProperty, widthAnimation);

            foreach (var child in MenuItemsPanel.Children)
            {
                if (child is Button btn && btn.Content is StackPanel stackPanel)
                {
                    foreach (var innerChild in stackPanel.Children)
                    {
                        if (innerChild is TextBlock textBlock)
                        {
                            textBlock.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }

            isMenuExpanded = false;
        }
        private void OnExitClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnFileMenuClicked(object sender, RoutedEventArgs e)
        {

        }
        private void OnCreateClassMenuItemClicked(object sender, RoutedEventArgs e)
        {
            var createCarClassWindow = new CreateCarClassWindow();
            createCarClassWindow.ShowDialog();
        }
        private void OnHelpMenuClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
