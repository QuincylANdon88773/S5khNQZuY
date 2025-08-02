// 代码生成时间: 2025-08-03 04:05:27
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

// MemoryUsageAnalyzer is a WPF application that displays the memory usage of the system.
public partial class MainWindow : Window
{
    private readonly PerformanceCounter _memoryPerformanceCounter;
    private DispatcherTimer _timer;

    public MainWindow()
    {
        InitializeComponent();

        // Initialize the PerformanceCounter for memory usage.
        _memoryPerformanceCounter = new PerformanceCounter("Memory", "Available MBytes");

        // Set up a timer to refresh the memory usage data at regular intervals.
        _timer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += OnTimerTick;
        _timer.Start();
    }

    // This method is called every time the timer ticks, updating the memory usage display.
    private void OnTimerTick(object sender, EventArgs e)
    {
        try
        {
            // Read the current memory usage from the PerformanceCounter.
            float memoryAvailable = _memoryPerformanceCounter.NextValue();

            // Update the UI thread with the new memory usage value.
            MemoryUsageTextBlock.Text = $"Available Memory: {memoryAvailable:N2} MB";
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur while reading performance counter data.
            Debug.WriteLine($"Error retrieving memory usage: {ex.Message}");
        }
    }

    // Clean up resources when the application is closing.
    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        _timer.Stop();
        _memoryPerformanceCounter.Dispose();
    }
}
