// 代码生成时间: 2025-08-11 21:06:59
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

// 定义排序算法的接口
public interface ISortAlgorithm
{
    int[] Sort(int[] array);
}

// 实现冒泡排序算法
public class BubbleSort : ISortAlgorithm
{
    public int[] Sort(int[] array)
    {
        int[] sortedArray = array;
        for (int i = 0; i < sortedArray.Length - 1; i++)
        {
            for (int j = 0; j < sortedArray.Length - 1 - i; j++)
            {
                if (sortedArray[j] > sortedArray[j + 1])
                {
                    int temp = sortedArray[j];
                    sortedArray[j] = sortedArray[j + 1];
                    sortedArray[j + 1] = temp;
                }
            }
        }
        return sortedArray;
    }
}

// 实现插入排序算法
public class InsertionSort : ISortAlgorithm
{
    public int[] Sort(int[] array)
    {
        int[] sortedArray = array;
        for (int i = 1; i < sortedArray.Length; i++)
        {
            int key = sortedArray[i];
            int j = i - 1;
            while (j >= 0 && sortedArray[j] > key)
            {
                sortedArray[j + 1] = sortedArray[j];
                j = j - 1;
            }
            sortedArray[j + 1] = key;
        }
        return sortedArray;
    }
}

// 实现快速排序算法
public class QuickSort : ISortAlgorithm
{
    public int[] Sort(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }
        int[] sortedArray = (int[])array.Clone();
        int left = 0;
        int right = sortedArray.Length - 1;
        int pivotIndex = GetPivotIndex(sortedArray, left, right);
        int pivotValue = sortedArray[pivotIndex];
        while (left < right)
        {
            while (sortedArray[left] < pivotValue)
                left++;
            while (sortedArray[right] > pivotValue)
                right--;
            if (left <= right)
            {
                int temp = sortedArray[left];
                sortedArray[left] = sortedArray[right];
                sortedArray[right] = temp;
                left++;
                right--;
            }
        }
        if (left > pivotIndex)
            right = pivotIndex;
        else
            left = pivotIndex;
        for (int i = 0; i <= right; i++)
            sortedArray[i] = Sort(sortedArray[i]);
        for (int i = left; i < sortedArray.Length; i++)
            sortedArray[i] = Sort(sortedArray[i]);
        return sortedArray;
    }

    private int GetPivotIndex(int[] array, int left, int right)
    {
        int pivot = array[(left + right) / 2];
        int low = left;
        int high = right;
        while (low <= high)
        {
            while (array[low] < pivot) low++;
            while (array[high] > pivot) high--;
            if (low <= high)
            {
                int temp = array[low];
                array[low] = array[high];
                array[high] = temp;
                low++;
                high--;
            }
        }
        return high;
    }
}

// MainWindow.xaml.cs - MainWindow的代码后台
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取输入数组
            int[] inputArray = GetInputArray();

            // 根据选择的排序算法进行排序
            ISortAlgorithm sortingAlgorithm = GetSortingAlgorithm();
            int[] sortedArray = sortingAlgorithm.Sort(inputArray);

            // 显示排序结果
            DisplaySortedArray(sortedArray);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private int[] GetInputArray()
    {
        // 这里应该添加代码来从用户界面获取输入数组
        // 这里只是一个示例，实际代码需要从界面控件中读取值
        return new int[] {3, 1, 4, 1, 5, 9, 2, 6, 5, 3};
    }

    private ISortAlgorithm GetSortingAlgorithm()
    {
        // 这里应该添加代码来根据用户选择返回对应的排序算法实现
        // 这里只是一个示例，实际代码需要根据界面控件的选择返回对应的算法实现
        return new BubbleSort();
    }

    private void DisplaySortedArray(int[] sortedArray)
    {
        // 这里应该添加代码来显示排序后的数组
        // 这里只是一个示例，实际代码需要更新界面控件以显示排序结果
        MessageBox.Show(string.Join(", ", sortedArray));
    }
}
