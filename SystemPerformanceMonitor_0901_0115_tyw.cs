// 代码生成时间: 2025-09-01 01:15:41
using System;
using System.Diagnostics;
using System.Windows;

// 表示系统性能监控工具
public partial class SystemPerformanceMonitor : Window
{
    // 性能计数器
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;

    // 构造函数
    public SystemPerformanceMonitor()
    {
        InitializeComponent();

        // 初始化性能计数器
        InitializeCounters();
    }

    // 初始化性能计数器
    private void InitializeCounters()
    {
        try
        {
            // 创建CPU使用率性能计数器
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            // 创建内存可用字节数性能计数器
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show("Error initializing performance counters: " + ex.Message);
        }
    }

    // 开始监控性能
    public void StartMonitoring()
    {
        // 定时器用于定期更新性能数据
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    // 定时器事件处理程序
    private void Timer_Tick(object sender, EventArgs e)
    {
        // 更新CPU使用率
        cpuUsageLabel.Content = cpuCounter.NextValue().ToString() + "%";
        // 更新可用内存
        ramUsageLabel.Content = ramCounter.NextValue().ToString() + " MB";
    }

    // 关闭窗口时停止监控
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (cpuCounter != null)
        {
            cpuCounter.Close();
        }
        if (ramCounter != null)
        {
            ramCounter.Close();
        }
    }
}

// XAML代码部分（SystemPerformanceMonitor.xaml）
// <Window x:Class="SystemPerformanceMonitor"
//         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//         Title="System Performance Monitor" Height="300" Width="300">
//     <Grid>
//         <Label x:Name="cpuUsageLabel" HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Content="CPU Usage: " />
//         <Label x:Name="ramUsageLabel" HorizontalAlignment="Left" Margin="10,40,0,0" VerticalAlignment="Top" Content="RAM Usage: " />
//     </Grid>
// </Window>