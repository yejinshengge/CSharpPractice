using CSharpPractice.Util;

namespace CSharpPractice.数据结构.练习;

public class BasicSort {

    public static void BasicSortMain()
    {
        int[] arr = Util.Tools.RandomArr(10, 0, 100);
        // SelectSort(arr);
        // InsertSort(arr);
        BubbleSort(arr);
        Util.Tools.PrintArr(arr);
    }

    /// <summary>
    /// 选择排序
    /// </summary>
    /// <param name="arr"></param>
    public static void SelectSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                    (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }

    /// <summary>
    /// 插入排序
    /// </summary>
    /// <param name="arr"></param>
    public static void InsertSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i-1; j >= 0; j--)
            {
                if(arr[j] > arr[j+1])
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                else
                    break;
            }
        }
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    /// <param name="arr"></param>
    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length-i-1; j++)
            {
                if(arr[j] > arr[j+1])
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
            }
        }
    }
}