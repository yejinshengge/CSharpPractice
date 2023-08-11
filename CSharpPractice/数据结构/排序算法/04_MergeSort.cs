using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

public class MergeSort {
    public static void MergeSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        MergeSortFunc2(arr,0,arr.Length-1);
        Util.Tools.PrintArr(arr);
    }

    public static void MergeSortFunc<T>(T[] arr,int left,int right) where T : IComparable
    {
        if(left == right)
            return;
        // 中点
        int mid = ((right - left) >> 1) + left;
        MergeSortFunc<T>(arr,left,mid);
        MergeSortFunc<T>(arr,mid+1,right);
        Merge(arr,left,mid,right);
    }

    private static void Merge<T>(T[] arr, int left, int mid, int right) where T : IComparable
    {
        // 临时数组
        T[] temp = new T[right-left+1];
        // 临时数组指针
        int i = 0;
        int p1 = left;
        int p2 = mid + 1;

        while (p1 <= mid && p2 <= right)
        {
            temp[i++] = arr[p1].CompareTo(arr[p2]) > 0 ? arr[p2++] : arr[p1++];
        }
        
        // 把剩余的元素写入
        while (p1<=mid)
        {
            temp[i++] = arr[p1++];
        }
        while (p2<=right)
        {
            temp[i++] = arr[p2++];
        }
        // 把临时数组中的元素复制到原数组
        i = 0;
        for (int j = left; j <= right; j++)
        {
            arr[j] = temp[i++];
        }
    }


    public static void MergeSortFunc2<T>(T[] arr, int left, int right) where T : IComparable
    {
        if(left == right) return;

        int mid = ((right - left) >> 1) + left;
        MergeSortFunc2<T>(arr,left,mid);
        MergeSortFunc2<T>(arr,mid+1,right);
        Merge2(arr, left, mid, right);
    }

    public static void Merge2<T>(T[] arr, int left, int mid, int right) where T : IComparable
    {
        T[] temp = new T[right - left + 1];
        int index = 0;

        int p1 = left;
        int p2 = mid + 1;

        while (p1 <= mid && p2 <= right)
        {
            temp[index++] = arr[p1].CompareTo(arr[p2]) > 0 ? arr[p2++] : arr[p1++];
        }

        while (p1 <= mid)
        {
            temp[index++] = arr[p1++];
        }
        while (p2 <= right)
        {
            temp[index++] = arr[p2++];
        }

        index = 0;
        for (int i = left; i <= right; i++)
        {
            arr[i] = temp[index++];
        }
    }
}