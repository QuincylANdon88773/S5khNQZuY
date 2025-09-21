// 代码生成时间: 2025-09-22 04:26:31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

// 定义统计数据类型
public class StatisticsData
{
    public double Mean { get; set; }
    public double Median { get; set; }
    public double Mode { get; set; }
    public double StandardDeviation { get; set; }
}

// 统计数据分析器
public partial class DataAnalyzerApp : Window
{
    private List<double> numbers;
    private StatisticsData statisticsData;

    public DataAnalyzerApp()
    {
        InitializeComponent();
        numbers = new List<double>();
        statisticsData = new StatisticsData();
    }

    // 加载数据
    public void LoadData(string data)
    {
        try
        {
            // 分割字符串并转换为double类型
            string[] numberStrings = data.Split(',');
            numbers = numberStrings.Select(n => double.Parse(n)).ToList();
        }
        catch (FormatException ex)
        {
            MessageBox.Show("Invalid data format. Please enter comma-separated numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (OverflowException ex)
        {
            MessageBox.Show("Data values are too large. Please enter valid numbers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 计算统计数据
    public void CalculateStatistics()
    {
        try
        {
            // 计算平均值
            statisticsData.Mean = numbers.Average();
            
            // 计算中位数
            var orderedNumbers = numbers.OrderBy(n => n).ToList();
            int middleIndex = orderedNumbers.Count / 2;
            statisticsData.Median = (orderedNumbers.Count % 2 == 0) ? 
                (orderedNumbers[middleIndex - 1] + orderedNumbers[middleIndex]) / 2 : 
                orderedNumbers[middleIndex];
            
            // 计算众数
            statisticsData.Mode = FindMode(numbers);
            
            // 计算标准差
            statisticsData.StandardDeviation = Math.Sqrt(numbers.Average(n => Math.Pow(n - statisticsData.Mean, 2)));
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while calculating statistics.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 查找众数
    private double FindMode(List<double> numbers)
    {
        var mode = numbers.GroupBy(n => n)
                         .OrderByDescending(g => g.Count())
                         .ThenBy(g => g.Key)
                         .Select(g => g.Key)
                         .FirstOrDefault();
        return mode;
    }

    // UI按钮点击事件处理
    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        string data = DataInputTextBox.Text;
        LoadData(data);
        CalculateStatistics();
        UpdateStatisticsDisplay();
    }

    // 更新UI显示统计数据
    private void UpdateStatisticsDisplay()
    {
        MeanLabel.Content = $"Mean: {statisticsData.Mean}";
        MedianLabel.Content = $"Median: {statisticsData.Median}";
        ModeLabel.Content = $"Mode: {statisticsData.Mode}";
        StandardDeviationLabel.Content = $"Standard Deviation: {statisticsData.StandardDeviation}";
    }
}
