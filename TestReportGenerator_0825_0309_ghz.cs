// 代码生成时间: 2025-08-25 03:09:57
using System;
using System.Windows;
using System.IO;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using DocumentFormat.OpenXml.Packaging;

namespace TestReportGenerator
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

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XPS Document|*.xps";
                saveFileDialog.DefaultExt = ".xps";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    GenerateTestReport(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }

        private void GenerateTestReport(string filePath)
        {
            // Create a new XPS document
            Package package = Package.Open(filePath, FileMode.Create);
            XpsDocument doc = new XpsDocument(package, CompressionOption.Maximum);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

            // Add a fixed document
            writer.Write(
                CreateFixedDocument(),
                PrintTicket.CreatePrintTicket());

            // Close the XPS document
            doc.Close();
            package.Close();
            MessageBox.Show("Test report generated successfully at: " + filePath);
        }

        private FixedDocument CreateFixedDocument()
        {
            // Create a FixedDocument
            FixedDocument fixedDocument = new FixedDocument();
            DocumentPaginator paginator = new DocumentPaginator();

            // Add a page to the document
            FixedPage page = new FixedPage();
            page.Width = 800;
            page.Height = 600;
            page.Margin = new Thickness(10);

            // Add a paragraph to the page
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run("Test Report"));
            paragraph.FontSize = 24;
            paragraph.FontWeight = FontWeights.Bold;
            paragraph.Margin = new Thickness(10);
            page.Children.Add(paragraph);

            // Add more content to the page as needed
            // ...

            // Add the page to the document
            fixedDocument.Pages.Add(page);

            // Return the FixedDocument
            return fixedDocument;
        }
    }
}
