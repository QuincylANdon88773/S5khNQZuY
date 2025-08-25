// 代码生成时间: 2025-08-25 14:44:06
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace LogParserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string LogEntryPattern = "^(?<Timestamp>[^ ]+) (?<Level>[^ ]+) (?<Logger>[^ ]+) - (?<Message>.+)$";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Log files (*.log)|*.log";
            if (openFileDialog.ShowDialog() == true)
            {
                string logFilePath = openFileDialog.FileName;
                ParseLog(logFilePath);
            }
        }

        private void ParseLog(string logFilePath)
        {
            try
            {
                using (StreamReader reader = File.OpenText(logFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Match match = Regex.Match(line, LogEntryPattern);
                        if (match.Success)
                        {
                            ParsedLogEntry logEntry = new ParsedLogEntry
                            {
                                Timestamp = match.Groups["Timestamp"].Value,
                                Level = match.Groups["Level"].Value,
                                Logger = match.Groups["Logger"].Value,
                                Message = match.Groups["Message"].Value
                            };
                            // Add the log entry to the UI or process it further
                        }
                        else
                        {
                            // Handle invalid log entries
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing log file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayLogEntries(IEnumerable<ParsedLogEntry> logEntries)
        {
            // Display log entries in a ListView or other UI control
        }

        private class ParsedLogEntry
        {
            public string Timestamp { get; set; }
            public string Level { get; set; }
            public string Logger { get; set; }
            public string Message { get; set; }
        }
    }
}
