// 代码生成时间: 2025-09-17 14:17:35
using System;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiResponseFormatterTool
{
# FIXME: 处理边界情况
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
# 添加错误处理
    public partial class MainWindow : Window
    {
        public MainWindow()
# FIXME: 处理边界情况
        {
            InitializeComponent();
        }

        private void FormatButton_Click(object sender, RoutedEventArgs e)
        {
# 扩展功能模块
            try
            {
                var apiResponseTextBox = FindName("ApiResponseTextBox") as TextBox;
                var formattedResponseTextBox = FindName("FormattedResponseTextBox") as TextBox;
# 改进用户体验
                if (apiResponseTextBox != null && formattedResponseTextBox != null)
                {
# NOTE: 重要实现细节
                    var jsonResponse = apiResponseTextBox.Text;
                    var parsedResponse = JToken.Parse(jsonResponse);
                    var formattedJson = JsonConvert.SerializeObject(parsedResponse, Formatting.Indented);
                    formattedResponseTextBox.Text = formattedJson;
                }
                else
                {
                    MessageBox.Show("Error: TextBox not found.", "Error");
                }
            }
            catch (JsonReaderException jsonEx)
            {
                MessageBox.Show($"Error parsing JSON: {jsonEx.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
    }
}
# 添加错误处理
