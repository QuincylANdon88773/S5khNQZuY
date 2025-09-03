// 代码生成时间: 2025-09-03 15:05:17
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PerformanceTestWpfApp
{
    /// <summary>
    /// Interaction logic for PerformanceTestScript.xaml
    /// </summary>
    public partial class PerformanceTestScript : Window
    {
        private Stopwatch stopwatch;

        public PerformanceTestScript()
        {
            InitializeComponent();
        }

        private async void StartTestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Reset stopwatch and start
                stopwatch = Stopwatch.StartNew();

                // Perform the performance test
                await PerformPerformanceTestAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Stop the stopwatch
                stopwatch.Stop();
                // Display the elapsed time
                ResultsTextBlock.Text = $"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms";
            }
        }

        /// <summary>
        /// Asynchronously performs a performance test.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task PerformPerformanceTestAsync()
        {
            // Simulate a time-consuming operation
            for (int i = 0; i < 1000; i++)
            {
                await Task.Delay(10); // Simulate work with a delay
            }
        }
    }
}