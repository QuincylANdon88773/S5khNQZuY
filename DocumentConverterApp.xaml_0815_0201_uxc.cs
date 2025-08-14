// 代码生成时间: 2025-08-15 02:01:22
using System;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DocumentConverterApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Word Documents|*.docx"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    // Convert the document to a new format
                    ConvertDocument(filePath);
                    MessageBox.Show("Conversion successful!");
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during conversion
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void ConvertDocument(string filePath)
        {
            // Open the document for reading
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                // Ensure the document is not empty
                if (mainPart.Document.Body == null)
                {
                    throw new InvalidOperationException("The document is empty.");
                }

                // Perform the conversion logic here (this is a placeholder)
                // For example, you could convert the document to a different format

                // Save the changes to the document
                mainPart.Document.Save();
            }
        }
    }
}
