// 代码生成时间: 2025-08-22 12:46:10
using System;
using System.IO;
using System.Windows;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGeneratorWpfApp
{
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateExcelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 用户输入的文件名
                string fileName = "GeneratedExcel.xlsx";
                // 使用OpenXML创建Excel文件
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
                {
                    // 添加工作簿
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // 添加工作表
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // 创建工作簿的工作表关系
                    Sheets sheets = workbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Sheet1"
                    };
                    sheets.Append(sheet);

                    // 保存更改
                    document.Save();

                    MessageBox.Show("Excel文件已生成。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
    }
}
