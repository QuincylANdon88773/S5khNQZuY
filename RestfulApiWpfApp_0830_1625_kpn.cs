// 代码生成时间: 2025-08-30 16:25:41
using System.Windows;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace RestfulApiWpfApp
{
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 使用HttpClient发送GET请求
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://api.example.com/data");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    // 将JSON响应转换为C#对象
                    dynamic data = JsonConvert.DeserializeObject(responseData);

                    // 显示响应数据
                    ResultsTextBox.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
                }
                else
                {
                    // 处理非成功状态码
                    MessageBox.Show("There was an error with your request: " + response.StatusCode.ToString(), "Error");
                }
            }
            catch (HttpRequestException httpEx)
            {
                // 处理网络相关异常
                MessageBox.Show("Error reaching the server: " + httpEx.Message, "Exception");
            }
            catch (Exception ex)
            {
                // 处理其他异常
                MessageBox.Show("An error occurred: " + ex.Message, "Exception");
            }
        }
    }
}

// 可以在App.xaml.cs中配置全局异常处理和服务初始化等