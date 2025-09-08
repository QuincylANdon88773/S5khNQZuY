// 代码生成时间: 2025-09-08 22:41:19
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

// 定义一个API响应格式化工具的类
public class ApiResponseFormatterTool
{
    // 定义一个HttpClient实例用于发起网络请求
    private readonly HttpClient _httpClient;

    // 构造函数，初始化HttpClient实例
    public ApiResponseFormatterTool()
    {
        _httpClient = new HttpClient();
    }

    // 异步方法，用于发送HTTP请求并格式化API响应
    public async Task<string> FormatApiResponseAsync(string url)
    {
        try
        {
            // 发送GET请求
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // 确保响应状态码为200（成功）
            if (response.IsSuccessStatusCode)
            {
                // 读取响应内容作为字符串
                string responseContent = await response.Content.ReadAsStringAsync();

                // 使用JsonSerializerOptions格式化JSON响应
                var options = new JsonSerializerOptions { WriteIndented = true };
                string formattedResponse = JsonSerializer.Serialize(JsonSerializer.Deserialize(responseContent, typeof(object)), options);

                // 返回格式化后的JSON字符串
                return formattedResponse;
            }
            else
            {
                // 抛出异常，表示非200响应状态码
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            // 捕获和处理HTTP请求异常
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}

// 定义一个WPF窗口类，用于显示格式化后的API响应
public partial class MainWindow : Window
{
    private ApiResponseFormatterTool _formatterTool;

    // 构造函数，初始化工具类实例
    public MainWindow()
    {
        InitializeComponent();
        _formatterTool = new ApiResponseFormatterTool();
    }

    // 按钮点击事件处理程序，调用格式化工具并显示结果
    private async void FormatButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string apiUrl = ApiUrlTextBox.Text; // 从UI控件获取API URL
            string formattedResponse = await _formatterTool.FormatApiResponseAsync(apiUrl);
            ResultsTextBox.Text = formattedResponse; // 显示格式化后的响应
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
