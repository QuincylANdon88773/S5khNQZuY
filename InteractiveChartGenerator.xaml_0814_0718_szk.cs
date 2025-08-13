// 代码生成时间: 2025-08-14 07:18:21
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for InteractiveChartGenerator.xaml
    /// </summary>
    public partial class InteractiveChartGenerator : UserControl
    {
        private SeriesCollection seriesCollection;

        public InteractiveChartGenerator()
        {
            InitializeComponent();
            InitializeChart();
        }

        private void InitializeChart()
        {
            // Initialize the series collection
            seriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 2, 3, 1, 6, 8 }
                }
            };

            // Assign the series collection to the chart
            myChart.Series = seriesCollection;
        }

        private void AddSeriesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newSeries = new LineSeries
                {
                    Title = "New Series",
                    Values = new ChartValues<double> { }
                };

                // Add new series to the series collection
                seriesCollection.Add(newSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding series: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveSeriesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (seriesCollection.Count > 0)
                {
                    // Remove the last series from the series collection
                    seriesCollection.RemoveAt(seriesCollection.Count - 1);
                }
                else
                {
                    MessageBox.Show("No series to remove.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing series: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddDataPointButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (seriesCollection.Count > 0)
                {
                    var lastSeries = seriesCollection[seriesCollection.Count - 1];
                    lastSeries.Values.Add(new ChartValues<double> { ChartHelper.GetRandomDouble(0, 10) });
                }
                else
                {
                    MessageBox.Show("No series available to add data point.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data point: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to get a random double
        private static class ChartHelper
        {
            public static double GetRandomDouble(double min, double max)
            {
                Random random = new Random();
                return random.NextDouble() * (max - min) + min;
            }
        }
    }
}