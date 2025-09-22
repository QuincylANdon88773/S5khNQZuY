// 代码生成时间: 2025-09-22 11:16:03
 * The application is designed to help users organize their folder structure by moving files into
 * predefined categories or subfolders.
 */

using System;
using System.IO;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

namespace FolderOrganizerApp
{
    public partial class FolderOrganizerApp : MetroWindow
    {
        public FolderOrganizerApp()
        {
            InitializeComponent();
        }

        /*
         * Method to start organizing the folders.
         * It prompts the user to select a directory and then organizes the files within.
         */
        private async void OrganizeFoldersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var selectedFolderPath = folderBrowser.SelectedPath;
                    await OrganizeFolderContentsAsync(selectedFolderPath);
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", $"An error occurred: {ex.Message}");
            }
        }

        /*
         * Method to organize the contents of a folder.
         * It moves files into subfolders based on their extensions.
         */
        private async Task OrganizeFolderContentsAsync(string folderPath)
        {
            foreach (var file in Directory.GetFiles(folderPath))
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var targetFolderPath = Path.Combine(folderPath, extension.TrimStart('.'));

                if (!Directory.Exists(targetFolderPath))
                {
                    Directory.CreateDirectory(targetFolderPath);
                }

                var targetFilePath = Path.Combine(targetFolderPath, fileInfo.Name);
                if (!File.Exists(targetFilePath))
                {
                    File.Move(file, targetFilePath);
                    await this.ShowMessageAsync("Info", $"Moved {fileInfo.Name} to {targetFolderPath}");
                }
                else
                {
                    await this.ShowMessageAsync("Info", $"Skipped {fileInfo.Name}, file already exists in {targetFolderPath}");
                }
            }
        }
    }
}