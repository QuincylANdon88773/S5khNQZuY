// 代码生成时间: 2025-09-04 03:41:49
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

// DataCleaningTool.xaml.cs is the code-behind for the WPF application
// which provides a GUI for data cleaning and preprocessing tasks.
public partial class DataCleaningTool : Window
{
    // Constructor for the DataCleaningTool
    public DataCleaningTool()
    {
        InitializeComponent();
    }

    // Method to load data from a file
    private void LoadData(string filePath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist.");
                return;
            }

            // Read all text from the file and display it in the textbox
            string data = File.ReadAllText(filePath);
            DataTextBox.Text = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading the file: {ex.Message}");
        }
    }

    // Method to clean and preprocess data
    private void CleanData()
    {
        try
        {
            string rawData = DataTextBox.Text;

            // Example of a simple data cleaning operation: removing HTML tags
            string cleanedData = Regex.Replace(rawData, "<[^>]*>