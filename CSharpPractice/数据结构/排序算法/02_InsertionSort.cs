using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

public class InsertionSort
{
    public static void InsertionSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        InsertSortFunc2(arr);
        Util.Tools.PrintArr(arr);
    }

    public static void InsertSortFunc<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (arr[j].CompareTo(arr[j+1]) > 0)
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                else
                    break;
            }
        }
    }

    public static void InsertSortFunc2<T>(T[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i -1; j >= 0; j--)
            {
                if (arr[j].CompareTo(arr[j+1]) > 0)
                    (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                else
                    break;
            }
        }
    }
}