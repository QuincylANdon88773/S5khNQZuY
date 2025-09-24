// 代码生成时间: 2025-09-24 12:30:30
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;

// 定义ApiResponseFormatterTool类，用于处理API响应格式化工具功能
public class ApiResponseFormatterTool
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;
    private readonly string _responseFormat;

    // 构造函数，初始化HttpClient和API URL
    public ApiResponseFormatterTool(string apiUrl, string responseFormat)
    {
        _httpClient = new HttpClient();
        _apiUrl = apiUrl;
        _responseFormat = responseFormat;
    }

    // 异步方法，用于发送HTTP请求并格式化响应
    public async Task<string> FormatResponseAsync()
    {
        try
        {
            // 发送GET请求到API
            HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);
            response.EnsureSuccessStatusCode();

            // 读取响应内容
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // 根据预定义的响应格式进行格式化
            switch (_responseFormat)
            {
                case "json":
                    return FormatJson(jsonResponse);
                default:
                    return jsonResponse;
            }
        }
        catch (HttpRequestException e)
        {
            // 错误处理，记录异常信息
            Console.WriteLine("An error occurred while sending a request: " + e.Message);
            return null;
        }
    }

    // 方法，用于格式化JSON响应
    private string FormatJson(string jsonResponse)
    {
        // 使用System.Text.Json.JsonSerializerOptions进行格式化
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(JsonSerializer.Deserialize(jsonResponse, typeof(object)), options);
    }
}

// 定义MainWindow类，作为WPF应用的主窗口
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 按钮点击事件，用于触发API响应格式化
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        ApiResponseFormatterTool formatter = new ApiResponseFormatterTool("https://api.example.com/data", "json");
        string formattedResponse = await formatter.FormatResponseAsync();

        if (!string.IsNullOrEmpty(formattedResponse))
        {
            // 显示格式化后的响应
            txtResponse.Text = formattedResponse;
        }
        else
        {
            // 显示错误信息
            MessageBox.Show("Failed to format API response.");
        }
    }
}
