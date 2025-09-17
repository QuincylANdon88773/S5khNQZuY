// 代码生成时间: 2025-09-17 10:27:09
using System;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDataFormatterWpfApp
{
    /// <summary>
    /// Interaction logic for JsonDataFormatterWpfApp.xaml
    /// </summary>
    public partial class JsonDataFormatterWpfApp : Window
    {
        public JsonDataFormatterWpfApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the ConvertButton.
        /// Converts JSON data from the input TextBox to a formatted JSON string.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get JSON data from the input TextBox.
                string jsonData = InputJsonTextBox.Text;

                // Parse the JSON data to a JObject.
                JObject parsedJson = JObject.Parse(jsonData);

                // Format the JSON data to a readable string.
                string formattedJson = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

                // Display the formatted JSON in the output TextBox.
                OutputJsonTextBox.Text = formattedJson;
            }
            catch (JsonReaderException jsonEx)
            {
                // Handle JSON parsing errors.
                MessageBox.Show("Invalid JSON format: " + jsonEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions.
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}