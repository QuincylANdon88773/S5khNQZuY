// 代码生成时间: 2025-07-31 01:40:57
using System;
using System.IO;
using System.Windows;

namespace ErrorLoggerApp
{
    /// <summary>
    /// Interaction logic for ErrorLoggerApp.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string logFilePath = @"C:\Logs\error.log"; // Define the log file path

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Logs an error message to a file.
        /// </summary>
        /// <param name="errorMessage">The error message to be logged.</param>
        public void LogError(string errorMessage)
        {
            try
            {
                // Append the error message to the log file
                File.AppendAllText(logFilePath, $"{errorMessage}
");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during logging
                MessageBox.Show($"Error logging to file: {ex.Message}");
            }
        }

        private void btnLogError_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = txtErrorMessage.Text; // Get the error message from the text box
            if (string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Please enter an error message to log.");
                return;
            }

            // Log the error message
            LogError(errorMessage);

            // Display a confirmation message
            MessageBox.Show("Error logged successfully.");
        }
    }
}