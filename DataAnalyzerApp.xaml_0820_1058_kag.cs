// 代码生成时间: 2025-08-20 10:58:39
using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// 统计数据分析器
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 在按钮点击事件中处理数据分析
    private void AnalyzeDataButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取文件路径
            string filePath = txtFilePath.Text;

            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 读取文件内容
            string fileContent = File.ReadAllText(filePath);

            // 分析数据（这里需要根据实际数据格式进行解析）
            List<double> data = ParseData(fileContent);

            // 计算统计数据
            double average = CalculateAverage(data);
            double max = data.Max();
            double min = data.Min();
            double stdDeviation = CalculateStandardDeviation(data);

            // 显示结果
            txtResult.Text = $"Average: {average}, Max: {max}, Min: {min}, Standard Deviation: {stdDeviation}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 解析数据文件
    private List<double> ParseData(string fileContent)
    {
        // 这里需要根据实际数据格式进行解析
        // 假设数据文件是CSV格式，每行一个数字
        List<double> data = new List<double>();
        foreach (string line in fileContent.Split('
'))
        {
            if (double.TryParse(line, out double value))
            {
                data.Add(value);
            }
            else
            {
                throw new FormatException("Invalid data format.")
            }
        }
        return data;
    }

    // 计算平均值
    private double CalculateAverage(List<double> data)
    {
        return data.Average();
    }

    // 计算标准差
    private double CalculateStandardDeviation(List<double> data)
    {
        double mean = CalculateAverage(data);
        double sumOfSquares = data.Sum(d => Math.Pow(d - mean, 2));
        return Math.Sqrt(sumOfSquares / data.Count);
    }
}