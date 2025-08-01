// 代码生成时间: 2025-08-02 01:41:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SortingApp
{
    /// <summary>
    /// Interaction logic for SortingApp.xaml
    /// </summary>
    public partial class SortingApp : Window
    {
        public SortingApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sorts the list of integers using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="numbers">The list of integers to sort.</param>
        public void BubbleSort(List<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "The list of numbers cannot be null.");
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Swap the elements
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the click event of the "Sort" button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Assume TextBox for input and ListView for output
                List<int> numbers = new List<int>();
                string[] input = InputTextBox.Text.Split(',');
                foreach (string number in input)
                {
                    if (int.TryParse(number.Trim(), out int num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        throw new FormatException("One of the inputs is not a valid integer.");
                    }
                }

                BubbleSort(numbers);

                // Assuming a ListView named "SortedListView" to display the sorted numbers
                SortedListView.ItemsSource = numbers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}