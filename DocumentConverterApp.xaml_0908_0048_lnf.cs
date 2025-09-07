// 代码生成时间: 2025-09-08 00:48:12
using System;
using System.IO;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WpfDocumentConverterApp
{
    /// <summary>
    /// Interaction logic for DocumentConverterApp.xaml
    /// </summary>
    public partial class DocumentConverterApp : Window
    {
        public DocumentConverterApp()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputFilePath.Text) || string.IsNullOrEmpty(OutputFilePath.Text))
            {
                MessageBox.Show("Please enter both input and output file paths.");
                return;
            }

            string inputFilePath = InputFilePath.Text;
            string outputFilePath = OutputFilePath.Text;
            try
            {
                if (File.Exists(outputFilePath))
                {
                    MessageBox.Show("Output file already exists. Please choose a different path.");
                    return;
                }

                // Convert the document
                using (WordprocessingDocument wDoc = WordprocessingDocument.Open(inputFilePath, true))
                {
                    // Add your conversion logic here
                    // For example, converting DOCX to TXT
                    SaveAsText(wDoc, outputFilePath);
                }
                MessageBox.Show("Conversion successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Converts a Word document to plain text
        /// </summary>
        /// <param name="wDoc">The WordprocessingDocument to convert</param>
        /// <param name="outputFilePath">The path to save the converted text file</param>
        private void SaveAsText(WordprocessingDocument wDoc, string outputFilePath)
        {
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                foreach (var paragraph in wDoc.MainDocumentPart.Document.Body.Elements<Paragraph>())
                {
                    sw.WriteLine(paragraph.InnerText);
                }
            }
        }
    }
}