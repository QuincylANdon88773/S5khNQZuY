// 代码生成时间: 2025-08-10 02:17:29
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ConfigFileManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadConfigFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open a file dialog to select the configuration file
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.DefaultExt = ".txt";
                openFileDialog.Filter = "Configuration Files (*.config)|*.config";

                if (openFileDialog.ShowDialog() == true)
                {
                    string configContent = File.ReadAllText(openFileDialog.FileName);
                    ConfigContentTextBox.Text = configContent;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the configuration file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveConfigFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Open a file dialog to save the configuration file
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.DefaultExt = ".config";
                saveFileDialog.Filter = "Configuration Files (*.config)|*.config";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, ConfigContentTextBox.Text);
                    MessageBox.Show("Configuration file saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the configuration file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
