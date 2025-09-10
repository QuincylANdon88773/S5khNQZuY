// 代码生成时间: 2025-09-10 20:50:23
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfHttpRequestProcessor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async Task SendHttpRequestAsync()
        {
            try
            {
                string url = "http://example.com/api/data"; // Specify the URL here
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Use the response body as needed
                // For example, display it in a text box or process the data
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Error: " + e.Message, "HTTP Request Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show("An unexpected error occurred: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Example method to handle button click event
        private void OnSendRequestButtonClick(object sender, RoutedEventArgs e)
        {
            SendHttpRequestAsync();
        }
    }
}
