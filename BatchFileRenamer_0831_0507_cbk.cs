// 代码生成时间: 2025-08-31 05:07:03
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BatchFileRenamer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryTextBox.Text = dialog.SelectedPath;
            }
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var directoryPath = DirectoryTextBox.Text;
                if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
                {
                    MessageBox.Show("Please select a valid directory.");
                    return;
                }

                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    var newFileName = Path.GetFileNameWithoutExtension(file) + "_renamed" + Path.GetExtension(file);
                    var newFilePath = Path.Combine(directoryPath, newFileName);
                    File.Move(file, newFilePath);
                }

                MessageBox.Show("Files have been renamed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}

// XAML Code for MainWindow.xaml
//<Window x:Class="BatchFileRenamer.MainWindow"
//        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
//        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
//        Title="Batch File Renamer" Height="200" Width="300">
//    <Grid>
//        <Grid.RowDefinitions>
//            <RowDefinition Height="Auto"/>
//            <RowDefinition Height="Auto"/>
//            <RowDefinition Height="Auto"/>
//        </Grid.RowDefinitions>
//        <Label Grid.Row="0" Content="Select Directory:"/>
//        <TextBox Name="DirectoryTextBox" Grid.Row="1" Margin="5"/>
//        <Button Name="BrowseButton" Content="Browse" Grid.Row="2" Margin="5" Click="BrowseButton_Click"/>
//        <Button Name="RenameButton" Content="Rename" Grid.Row="3" Margin="5" Click="RenameButton_Click"/>
//    </Grid>
//</Window>