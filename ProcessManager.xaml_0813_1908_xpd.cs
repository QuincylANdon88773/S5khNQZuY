// 代码生成时间: 2025-08-13 19:08:51
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProcessManagerApp
{
    // MainWindow.xaml 的代码后台文件
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 刷新进程列表
        private void RefreshProcessList()
        {
            try
            {
                listViewProcesses.Items.Clear(); // 清空列表
                foreach (Process process in Process.GetProcesses())
                {
                    // 向列表视图中添加进程信息
                    listViewProcesses.Items.Add(new {
                        Id = process.Id,
                        Name = process.ProcessName,
                        Priority = process.PriorityClass.ToString(),
                        Threads = process.Threads.Count
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"An error occurred: {ex.Message}");
            }
        }

        // 当窗口加载时触发
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshProcessList();
        }

        // 点击刷新按钮时触发
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshProcessList();
        }

        // 点击终止进程按钮时触发
        private void btnKillProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listViewProcesses.SelectedItem is not null)
                {
                    var processInfo = (dynamic)listViewProcesses.SelectedItem;
                    Process process = Process.GetProcessById(processInfo.Id);
                    process.Kill();
                    MessageBox.Show($@"Process {processInfo.Name} (ID: {processInfo.Id}) has been terminated.");
                    RefreshProcessList();
                }
                else
                {
                    MessageBox.Show(@"Please select a process to kill.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"An error occurred: {ex.Message}");
            }
        }
    }
}
