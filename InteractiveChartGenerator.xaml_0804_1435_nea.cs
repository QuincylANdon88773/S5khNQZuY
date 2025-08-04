// 代码生成时间: 2025-08-04 14:35:37
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Windows;
using System.Windows.Controls;

// This is a sample code for an interactive chart generator using CSharp and WPF framework.
// The code should be part of a larger project with necessary references to OxyPlot.

// The namespace should match your project's namespace
namespace InteractiveChartGenerator
{
    public partial class MainWindow : Window
    {
        private PlotModel plotModel;

        public MainWindow()
        {
            InitializeComponent();
            InitializePlotModel();
        }

        private void InitializePlotModel()
        {
            plotModel = new PlotModel("Interactive Chart")
            {
                // Set the plot model title
                Title = "Interactive Chart Generator",
                // Enable the interactive tools like zooming and panning
                IsLegendVisible = true
            };
            plotModel.Series.Add(new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Blue,
                // Add some sample points
                ItemsSource = new double[] { 1, 2, 3, 4, 5 }
            });
            // Bind the plot model to the PlotView
            MyPlotView.Model = plotModel;
        }

        // This method is called when the user wants to add data points to the chart
        private void AddDataPointButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (plotModel == null)
                {
                    throw new InvalidOperationException("PlotModel has not been initialized.");
                }

                // Add a new data point to the series
                // This example assumes a LineSeries, but can be extended to other series types
                if (plotModel.Series[0] is LineSeries lineSeries)
                {
                    lineSeries.Points.Add(new DataPoint(lineSeries.Points.Count + 1, new Random().NextDouble() * 10));
                }
                else
                {
                    throw new InvalidOperationException("The first series is not a LineSeries.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // This method is called when the user wants to clear the chart
        private void ClearChartButton_Click(object sender, RoutedEventArgs e)
        {
            plotModel.Series.Clear();
        }

        // Additional interactive features can be added here
    }
}
