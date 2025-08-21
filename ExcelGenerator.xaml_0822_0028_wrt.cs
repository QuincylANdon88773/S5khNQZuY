// 代码生成时间: 2025-08-22 00:28:31
using System;
using System.IO;
using System.Windows;
# 扩展功能模块
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
# 改进用户体验
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
# 优化算法效率
        }

        private void GenerateExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Define the file path to save the Excel file
                string filePath = @"C:\GeneratedExcel.xlsx";

                // Create a new Excel document
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // Add a WorkbookPart to the document
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // Add a WorksheetPart to the Workbook
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());
# 优化算法效率

                    // Add Sheets to the Workbook
# TODO: 优化性能
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    sheets.AppendChild(new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Sheet1"
                    });

                    // Save the document
                    workbookPart.Workbook.Save();
# 扩展功能模块
                }

                MessageBox.Show("Excel file generated successfully!");
            }
            catch (Exception ex)
# 改进用户体验
            {
                // Handle any exceptions that occur during the generation process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}