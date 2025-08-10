// 代码生成时间: 2025-08-11 00:23:26
using System;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceTestApp
{
    /// <summary>
    /// Interaction logic for PerformanceTestScript.xaml
    /// </summary>
    public partial class PerformanceTestScript : Window
    {
        private Stopwatch stopwatch;
        private int iterations;
        private int currentIteration;
        private bool isRunning;

        public PerformanceTestScript()
        {
            InitializeComponent();
            this.stopwatch = new Stopwatch();
            this.iterations = 0;
            this.currentIteration = 0;
            this.isRunning = false;
        }

        /// <summary>
        /// Start the performance test
        /// </summary>
        private void StartTest()
        {
            if (isRunning) return;

            this.currentIteration = 0;
            this.iterations = int.Parse(IterationsTextBox.Text);
            this.isRunning = true;
            this.stopwatch.Start();

            // Perform the test in a separate task to prevent UI blocking
            Task.Run(() => PerformTest());
        }

        /// <summary>
        /// Perform the actual test logic
        /// </summary>
        private void PerformTest()
        {
            try
            {
                for (; currentIteration < iterations; currentIteration++)
                {
                    // Here you would add the code to test the performance of your application
                    // For demonstration purposes, we're just using Thread.Sleep to simulate work
                    Thread.Sleep(100); // Simulate work with a sleep
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the test
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Stop the stopwatch and update the UI on the main thread
                Application.Current.Dispatcher.Invoke(() =>
                {
                    this.stopwatch.Stop();
                    this.isRunning = false;
                    ResultsTextBox.Text = $"Total Time: {stopwatch.ElapsedMilliseconds} ms";
                });
            }
        }

        /// <summary>
        /// Stop the performance test
        /// </summary>
        private void StopTest()
        {
            if (!isRunning) return;

            this.isRunning = false;
            this.stopwatch.Stop();
        }

        // XAML event handlers and other UI logic would go here
    }
}
