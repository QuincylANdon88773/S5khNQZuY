// 代码生成时间: 2025-09-07 12:33:46
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SystemPerformanceMonitor
{
    // 主窗口类
    public partial class MainWindow : Window
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter memCounter;
        private PerformanceCounter diskCounter;

        public MainWindow()
        {
            InitializeComponent();
            // 初始化性能计数器
            InitializeCounters();
            // 启动定时器来定期更新性能数据
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeCounters()
        {
            try
            {
                // 初始化CPU使用率计数器
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                // 初始化内存使用计数器
                memCounter = new PerformanceCounter("Memory", "Available MBytes");
                // 初始化磁盘I/O计数器
                diskCounter = new PerformanceCounter("LogicalDisk", "Disk Bytes/sec", "C:");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing performance counters: {ex.Message}");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 获取当前CPU使用率
                double cpuUsage = cpuCounter.NextValue();
                // 获取当前可用内存
                double availableMemory = memCounter.NextValue();
                // 获取当前磁盘I/O速率
                double diskIO = diskCounter.NextValue();

                // 更新UI元素
                CpuUsageLabel.Content = $"CPU Usage: {cpuUsage}%";
                MemoryAvailableLabel.Content = $"Memory: {availableMemory} MB";
                DiskIOLabel.Content = $"Disk I/O: {diskIO} bytes/s";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating performance data: {ex.Message}");
            }
        }
    }
}

// XAML代码位于 MainWindow.xaml
