// 代码生成时间: 2025-09-22 15:05:36
using System;
using System.Windows;
using System.Windows.Controls;
# 添加错误处理
using System.Windows.Media;

// 定义一个ViewModel，用于主题切换
public class ThemeViewModel
{
    private ResourceDictionary _currentTheme;

    public ResourceDictionary CurrentTheme
    {
        get { return _currentTheme; }
        set { _currentTheme = value; OnPropertyChanged(); }
    }

    public ThemeViewModel()
    {
        // 默认主题
        CurrentTheme = new ResourceDictionary { Source = new Uri("/Themes/LightTheme.xaml", UriKind.Relative) };
    }

    // 方法：切换主题
    public void SwitchTheme(string themeName)
    {
        try
        {
            // 尝试加载新的主题资源
# 改进用户体验
            var newTheme = new ResourceDictionary { Source = new Uri($"/Themes/{themeName}.xaml", UriKind.Relative) };

            // 切换主题
            Application.Current.Resources.MergedDictionaries.Remove(CurrentTheme);
# 添加错误处理
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
            CurrentTheme = newTheme;
        }
        catch (Exception ex)
        {
            // 错误处理
            MessageBox.Show($"Error switching theme: {ex.Message}", "Theme Switcher Error");
        }
    }

    // 依赖属性通知
    public event Action PropertyChanged;
    protected virtual void OnPropertyChanged() => PropertyChanged?.Invoke();
}

// 主窗体
public partial class MainWindow : Window
{
    private ThemeViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new ThemeViewModel();
        DataContext = _viewModel;
    }
# 扩展功能模块

    private void SwitchThemeButton_Click(object sender, RoutedEventArgs e)
    {
        // 获取用户选择的主题
        var themeName = ((Button)sender).Tag as string;
# 扩展功能模块

        // 调用ViewModel的方法来切换主题
        _viewModel.SwitchTheme(themeName);
    }
}
# 添加错误处理
