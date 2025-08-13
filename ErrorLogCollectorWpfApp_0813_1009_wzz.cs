// 代码生成时间: 2025-08-13 10:09:23
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ErrorLogCollectorApp
{
    /* Main class for the WPF application. */
    public partial class MainWindow : Window
    {
        private readonly ErrorLogManager logManager;

        public MainWindow()
        {
            InitializeComponent();
            logManager = new ErrorLogManager();
        }

        private void LogErrorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the error message from the user input
                string errorMessage = ErrorTextBox.Text;
                if (string.IsNullOrWhiteSpace(errorMessage))
                {
                    MessageBox.Show("Please enter an error message.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Log the error message using the ErrorLogManager
                logManager.LogError(errorMessage);
                MessageBox.Show("Error logged successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions and log them
                logManager.LogError($"Failed to log error: {ex.Message}");
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    /* ErrorLogManager class responsible for managing error logs. */
    public class ErrorLogManager
    {
        private const string LogFilePath = "error_log.txt";

        public void LogError(string message)
        {
            try
            {
                // Append the error message to the log file
                File.AppendAllText(LogFilePath, $"[{DateTime.Now}]: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Log any exception that occurs during the logging process
                // This could be to a secondary log file or system
                Console.WriteLine($"Error logging error: {ex.Message}");
            }
        }
    }
}
