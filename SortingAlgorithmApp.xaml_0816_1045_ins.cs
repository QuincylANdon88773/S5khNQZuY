// 代码生成时间: 2025-08-16 10:45:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// MainWindow.xaml.cs
namespace SortingAlgorithmApp
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

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // Error handling
            try
            {
                // Retrieve the list of numbers to sort from the text box
                string[] numbers = NumberTextBox.Text.Split(',');
                var numberList = numbers.Select(n => int.Parse(n.Trim())).ToList();

                // Sort the list of numbers
                numberList = SortNumbers(numberList);

                // Display the sorted numbers in the result text box
                ResultTextBox.Text = string.Join(", ", numberList);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integers separated by commas.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Sorts a list of integers using a simple bubble sort algorithm.
        /// </summary>
        /// <param name="numbers">The list of integers to sort.</param>
        /// <returns>A sorted list of integers.</returns>
        private List<int> SortNumbers(List<int> numbers)
        {
            // Bubble sort algorithm implementation
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        // Swap the elements
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            return numbers;
        }
    }
}