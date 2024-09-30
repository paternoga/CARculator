using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using CARculator.DynamicServices;
using CARculator.Models;

namespace CARculator.Views
{
    public partial class CreateCarClassWindow : Window
    {
        public CreateCarClassWindow()
        {
            InitializeComponent();
            LoadFuelTypes();
            DisplayDynamicCars();
        }

        private void LoadFuelTypes()
        {
            FuelTypeComboBox.ItemsSource = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
        }

        private void OnRefreshCarsClicked(object sender, RoutedEventArgs e)
        {
            DisplayDynamicCars();
        }
        private void OnCreateClassClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var className = ClassNameTextBox.Text;
                var brand = BrandTextBox.Text;
                var model = ModelTextBox.Text;
                var generation = GenerationTextBox.Text;
                var productionYear = ProductionYearTextBox.Text;
                var mileage = int.Parse(MileageTextBox.Text);
                var averagePrice = decimal.Parse(AveragePriceTextBox.Text);
                var fuelType = (FuelType)FuelTypeComboBox.SelectedItem;

                var transmissions = TransmissionsTextBox.Text.Split(',')
                    .Select(t => Enum.Parse<TransmissionType>(t.Trim(), true))
                    .ToList();

                var engines = EnginesTextBox.Text.Split(',')
                    .Select(e =>
                    {
                        var parts = e.Split('|');
                        return new Engine
                        {
                            Type = parts[0].Trim(),
                            Capacity = parts[1].Trim(),
                            Power = int.Parse(parts[2].Trim())
                        };
                    })
                    .ToList();

                var generator = new DynamicClassGenerator();
                var carType = generator.CreateCarClass(className);

                var carInstance = CarInitializer.CreateAndInitializeCar(carType);

                DynamicCarStorage.Instance.AddCarType(carType);
                DynamicCarStorage.Instance.AddCar(carInstance);

                MessageBox.Show($"Class {className} created and added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnSaveClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var className = ClassNameTextBox.Text;
                var brand = BrandTextBox.Text;
                var model = ModelTextBox.Text;
                var generation = GenerationTextBox.Text;
                var productionYear = ProductionYearTextBox.Text;
                var mileage = int.Parse(MileageTextBox.Text);
                var averagePrice = decimal.Parse(AveragePriceTextBox.Text);
                var fuelType = FuelTypeComboBox.SelectedItem.ToString();
                var transmissions = TransmissionsTextBox.Text;
                var engines = EnginesTextBox.Text;

                var savePath = "CarClasses.txt";
                var classData = $"Class Name: {className}\n" +
                                $"Brand: {brand}\n" +
                                $"Model: {model}\n" +
                                $"Generation: {generation}\n" +
                                $"Production Year: {productionYear}\n" +
                                $"Mileage: {mileage}\n" +
                                $"Average Price: {averagePrice}\n" +
                                $"Fuel Type: {fuelType}\n" +
                                $"Transmissions: {transmissions}\n" +
                                $"Engines: {engines}\n";

                File.AppendAllText(savePath, classData + "\n\n");

                MessageBox.Show("Class data saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayDynamicCars()
        {
            var cars = DynamicCarStorage.Instance.GetCars();
            CarListView.ItemsSource = cars;
        }

    }
}
