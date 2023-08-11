using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

public class QuickSort {

    public static void QuickSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        QuickSortFunc2(arr,0,arr.Length-1);
        Util.Tools.PrintArr(arr);
    }

    public static void QuickSortFunc<T>(T[] arr, int left, int right) where T : IComparable
    {
        if(left >= right)
            return;
        int random = new Random().Next(left, right + 1);
        Swap(arr,random,right);
        var partition = Partition(arr, left, right);
        QuickSortFunc<T>(arr,left,partition[0]);
        QuickSortFunc<T>(arr,partition[1],right);
    }

    private static int[] Partition<T>(T[] arr,int left,int right)where T : IComparable
    {
        // 小于区指针
        int smallPointer = left - 1;
        int bigPointer = right;

        while (bigPointer > left)
        {
            // 当前数小于划分值,将其与小于区下一个数交换,小于区左扩,当前指针++
            if (arr[left].CompareTo(arr[right]) < 0)
            {
                Swap(arr,left++,++smallPointer);
            }
            // 当前数大于划分值,将其与大于区上一个数交换,大于区右扩,当前指针不动
            else if (arr[left].CompareTo(arr[right]) > 0)
            {
                Swap(arr,left,--bigPointer);
            }
            // 相等只移动当前指针
            else
            {
                left++;
            }
        }
        // 最后将划分值与大于区第一个元素交换
        Swap(arr,right,bigPointer++);
        return new[] {smallPointer, bigPointer};
    }

    private static void Swap<T>(T[] arr, int index1, int index2)
    {
        (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
    }

    public static void QuickSortFunc2<T>(T[] arr, int left, int right) where T : IComparable
    {
        if(left >= right)
            return;
        // 随机取划分值
        int random = new Random().Next(left, right + 1);
        Swap(arr,right,random);
        // 进行划分
        var partition2 = Partition2(arr, left, right);
        // 分别处理大于区和小于区
        QuickSortFunc2<T>(arr,left,partition2[0]);
        QuickSortFunc2<T>(arr,partition2[1],right);
    }

    public static int[] Partition2<T>(T[] arr, int left, int right)where T : IComparable
    {
        // 小于区、大于区指针
        int smallPointer = left - 1;
        int bigPointer = right;

        while (left < bigPointer)
        {
            // 当前数大于划分值,与大于区前一个值交换,大于区左扩,当前指针不动
            if (arr[left].CompareTo(arr[right]) > 0)
                Swap(arr,left,--bigPointer);
            // 当前数小于划分值,与小于区后一个值交换,小于区右扩,当前指针右移
            else if (arr[left].CompareTo(arr[right]) < 0)
                Swap(arr, left++, ++smallPointer);
            // 当前数等于划分值,当前指针右移
            else
                left++;
        }
        // 将划分值与大于区第一个元素交换
        Swap(arr,right,bigPointer++);
        return new[] {smallPointer, bigPointer};
    }
}