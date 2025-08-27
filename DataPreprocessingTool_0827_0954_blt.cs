// 代码生成时间: 2025-08-27 09:54:46
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace DataPreprocessingWpfApp
{
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartDataPreprocessingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rawDataPath = RawDataPathTextBox.Text;
                string processedDataPath = ProcessedDataPathTextBox.Text;

                if (string.IsNullOrEmpty(rawDataPath) || string.IsNullOrEmpty(processedDataPath))
                {
                    throw new ArgumentException("Both raw data path and processed data path must be provided.");
                }

                List<string> processedData = DataPreprocessing(rawDataPath);
                SaveProcessedData(processedData, processedDataPath);
                MessageBox.Show("Data preprocessing completed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Data preprocessing logic
        private List<string> DataPreprocessing(string rawDataPath)
        {
            List<string> processedData = new List<string>();
            if (!File.Exists(rawDataPath))
            {
                throw new FileNotFoundException("Raw data file not found.");
            }

            string[] lines = File.ReadAllLines(rawDataPath);
            foreach (string line in lines)
            {
                // Implement data cleaning and preprocessing steps here
                // For example, remove unwanted characters, normalize text, etc.
                string cleanedLine = line.Trim();
                processedData.Add(cleanedLine);
            }

            return processedData;
        }

        // Save processed data to a file
        private void SaveProcessedData(List<string> data, string processedDataPath)
        {
            File.WriteAllLines(processedDataPath, data);
        }
    }
}
