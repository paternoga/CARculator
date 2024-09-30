using System.Windows;
using System.Collections.Generic;
using System.Linq;
using CARculator.TEST2.Services;
using CARculator.TEST2.Models.AudiA4;

namespace CARculator
{
    public partial class MainWindow : Window
    {
        private CarService carService;
        private List<AudiA4> audiA4Generations;
        private AudiA4 selectedGeneration;

        public MainWindow()
        {
            InitializeComponent();
            carService = new CarService();
            audiA4Generations = carService.GetAudiA4Generations();
            PopulateGenerationComboBox();
        }

        private void PopulateGenerationComboBox()
        {
            GenerationComboBox.ItemsSource = audiA4Generations.Select(g => g.Model).ToList();
        }

        private void GenerationComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (GenerationComboBox.SelectedItem != null)
            {
                var selectedModel = GenerationComboBox.SelectedItem.ToString();
                selectedGeneration = carService.GetAudiA4ByModel(selectedModel);
                PopulateEngineComboBox();
                EngineComboBox.IsEnabled = true;
                CarInfoTextBox.Text = selectedGeneration?.DisplayInfo();
            }
        }

        private void PopulateEngineComboBox()
        {
            if (selectedGeneration != null)
            {
                EngineComboBox.ItemsSource = selectedGeneration.Engines.Select(e => $"{e.Type} ({e.Capacity}L, {e.Power} KM)").ToList();
            }
        }

        private void EngineComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (EngineComboBox.SelectedItem != null && selectedGeneration != null)
            {
                var selectedEngine = EngineComboBox.SelectedItem.ToString();
                var engineInfo = selectedGeneration.Engines
                    .FirstOrDefault(e => $"{e.Type} ({e.Capacity}L, {e.Power} KM)" == selectedEngine);
                if (engineInfo != null)
                {
                    CarInfoTextBox.Text = $"{selectedGeneration.DisplayInfo()}\nSelected Engine:\n- {engineInfo.Type}: {engineInfo.Capacity}L, {engineInfo.Power} KM";
                }
            }
        }
    }
}
