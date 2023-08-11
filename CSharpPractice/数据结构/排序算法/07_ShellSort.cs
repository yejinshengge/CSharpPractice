using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

public class ShellSort {
    public static void ShellSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        ShellSortFunc(arr);
        Util.Tools.PrintArr(arr);
    }

    public static void ShellSortFunc<T>(T[] arr) where T : IComparable
    {
        for (int step = arr.Length/2; step>0; step/=2)
        {
            for (int right = step; right < arr.Length; right++)
            {
                int left = right-step;
                while (left >= 0 && arr[right].CompareTo(arr[left]) < 0)
                {
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                    left -= step;
                }
            }
        }
    }
}