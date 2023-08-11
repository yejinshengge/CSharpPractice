using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

/// <summary>
/// 选择排序
/// </summary>
public class SelectionSort {
    
    public static void SelectionSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        SelectionSortFunc(arr);
        Util.Tools.PrintArr(arr);
        
    }

    public static void SelectionSortFunc(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[j] < arr[i])
                    (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }
}