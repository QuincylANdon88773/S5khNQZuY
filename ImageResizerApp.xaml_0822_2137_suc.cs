// 代码生成时间: 2025-08-22 21:37:43
using System;
using System.IO;
using System.Linq;
using System.Windows;
# TODO: 优化性能
using System.Windows.Controls;

// 命名空间包含图片尺寸批量调整器的主要逻辑
# 改进用户体验
namespace ImageResizerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
# 优化算法效率
        }

        // 选择文件夹并加载图片文件列表到界面
        private void SelectFolderAndLoadImages(object sender, RoutedEventArgs e)
        {
# NOTE: 重要实现细节
            try
# 改进用户体验
            {
                // 使用文件夹选择对话框选择文件夹
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var folderPath = dialog.SelectedPath;

                    // 获取文件夹内所有图片文件路径
                    var imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                        file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                        file.EndsWith(".png", StringComparison.OrdinalIgnoreCase));

                    // 将图片文件路径加载到ListBox控件中
# 添加错误处理
                    ImageFilesListBox.ItemsSource = imageFiles;
# FIXME: 处理边界情况
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
# 扩展功能模块

        // 调整选中图片的尺寸
        private void ResizeSelectedImages(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取用户输入的新尺寸
# FIXME: 处理边界情况
                int newWidth = int.Parse(WidthTextBox.Text);
                int newHeight = int.Parse(HeightTextBox.Text);

                // 遍历ListBox中的所有图片
                foreach (var imageFile in ImageFilesListBox.SelectedItems)
                {
                    string filePath = imageFile.ToString();
# 改进用户体验

                    // 调整图片尺寸
                    ResizeImage(filePath, newWidth, newHeight);
                }

                MessageBox.Show("Images resized successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // 实际调整图片尺寸的方法
        private void ResizeImage(string filePath, int newWidth, int newHeight)
        {
            using (var image = System.Drawing.Image.FromFile(filePath))
            {
                // 创建一个新的Bitmap对象，用于保存调整尺寸后的图片
                using (var resizedImage = new System.Drawing.Bitmap(newWidth, newHeight))
                {
                    using (var graphics = System.Drawing.Graphics.FromImage(resizedImage))
                    {
                        // 设置图片的高质量插值法
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        // 绘制调整后的图片
                        graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                    }

                    // 保存调整后的图片
                    string newFilePath = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar +
                                      Path.GetFileNameWithoutExtension(filePath) + "_resized" + Path.GetExtension(filePath);
                    resizedImage.Save(newFilePath, image.RawFormat);
# 扩展功能模块
                }
# 扩展功能模块
            }
        }
    }
}