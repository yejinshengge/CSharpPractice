using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

public class BubbleSort {
    public static void BubbleSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        BubbleSortFunc(arr);
        Util.Tools.PrintArr(arr);
    }

    public static void BubbleSortFunc<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length-1-i; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }
    }
}