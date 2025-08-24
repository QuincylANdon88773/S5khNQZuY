// 代码生成时间: 2025-08-24 18:22:07
using System;
using System.IO;
using System.Windows;

// 定义一个简单的错误日志收集器WPF应用程序
namespace ErrorLogCollectorApp
{
    // MainWindow类，继承自Window类
    public partial class MainWindow : Window
    {
        private const string LogFilePath = "ErrorLog.txt"; // 日志文件路径

        public MainWindow()
        {
            InitializeComponent();
        }

        // 按钮点击事件处理，记录错误日志
        private void LogErrorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取用户输入的错误消息
                string errorMessage = ErrorMessageTextBox.Text;

                // 检查错误消息是否为空
                if (string.IsNullOrWhiteSpace(errorMessage))
                {
                    MessageBox.Show("Error message cannot be empty.");
                    return;
                }

                // 将错误消息添加到日志文件中
                AppendErrorToLogFile(errorMessage);
                MessageBox.Show("Error logged successfully.");
            }
            catch (Exception ex)
            {
                // 错误处理，显示异常信息
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // 将错误消息追加到日志文件
        private void AppendErrorToLogFile(string errorMessage)
        {
            // 确保日志文件路径存在
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }

            // 使用StreamWriter将错误消息追加到日志文件
            using (StreamWriter writer = File.AppendText(LogFilePath))
            {
                writer.WriteLine($"[{DateTime.Now}] {errorMessage}");
            }
        }
    }
}
