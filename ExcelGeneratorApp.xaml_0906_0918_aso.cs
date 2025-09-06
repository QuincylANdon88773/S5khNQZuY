// 代码生成时间: 2025-09-06 09:18:54
using System;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace ExcelGeneratorApp
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

        private void GenerateExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Define the path for the new Excel file
                string filePath = "GeneratedExcel.xlsx";

                // Check if the file already exists
                if (File.Exists(filePath))
                {
                    File.Delete(filePath); // Delete the existing file
                }

                // Create the SpreadsheetDocument with the new Excel file
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // Add a WorkbookPart to the document
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // Add Sheets to the Workbook
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    sheets.AppendChild(new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Sheet1"
                    });

                    // Save the changes to the document
                    workbookPart.Workbook.Save();
                }

                MessageBox.Show("Excel file generated successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process
                MessageBox.Show($"An error occurred while generating the Excel file: {ex.Message}");
            }
        }
    }
}