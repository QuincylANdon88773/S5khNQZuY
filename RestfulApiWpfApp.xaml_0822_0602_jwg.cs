// 代码生成时间: 2025-08-22 06:02:47
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace RestfulApiWpfApp
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

        private async void GetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://api.example.com/data");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    // Process the content as needed
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Additional methods and event handlers can be added here for other HTTP methods like POST, PUT, DELETE etc.
    }
}
