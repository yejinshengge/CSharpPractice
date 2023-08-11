using CSharpPractice.Util;

namespace CSharpPractice.数据结构.练习;

public class AdvancedSort {

    public static void AdvancedSortMain()
    {
        int[] arr = Util.Tools.RandomArr(10, 0, 100);
        // MergeSort(arr,0,arr.Length-1);
        // QuickSort(arr,0,arr.Length-1);
        HeapSort(arr);
        Util.Tools.PrintArr(arr);
    }

    /// <summary>
    /// 归并排序
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public static void MergeSort(int[] arr,int from,int to)
    {
        if(from >= to) return;
        int mid = (from + to) / 2;
        MergeSort(arr,from,mid);
        MergeSort(arr,mid+1,to);
        Merge(arr, from, mid, to);
    }

    public static void Merge(int[] arr,int from,int mid,int to)
    {
        int[] temp = new int[to-from+1];

        //temp指针
        int index = 0;
        int p1 = from;
        int p2 = mid + 1;

        while (p1 <= mid && p2 <= to)
        {
            temp[index++] = arr[p1] < arr[p2] ? arr[p1++] : arr[p2++];
        }

        while (p1 <= mid)
        {
            temp[index++] = arr[p1++];
        }
        
        while (p2 <= to)
        {
            temp[index++] = arr[p2++];
        }

        index = 0;
        for (int i = from; i <= to; i++)
        {
            arr[i] = temp[index++];
        }

    }

    public static void QuickSort(int[] arr, int from, int to)
    {
        if(from >= to) return;
        int random = new Random().Next(from, to + 1);
        (arr[random], arr[to]) = (arr[to], arr[random]);

        var res = Partition(arr, from, to);
        QuickSort(arr,from,res[0]);
        QuickSort(arr,res[1],to);
    }

    public static int[] Partition(int[] arr, int from, int to)
    {
        // 小于区指针
        int smallPointer = from - 1;
        // 大于区指针
        int bigPointer = to;

        while (from < bigPointer)
        {
            // 当前元素小于划分值,小于区右扩
            if (arr[from] < arr[to])
            {
                smallPointer++;
                (arr[from], arr[smallPointer]) = (arr[smallPointer], arr[from]);
                from++;
            }
            // 当前元素大于划分值,大于区左扩
            else if (arr[from] > arr[to])
            {
                bigPointer--;
                (arr[from], arr[bigPointer]) = (arr[bigPointer], arr[from]);
            }
            // 当前元素等于划分值
            else
            {
                from++;
            }
        }
        
        // 把划分值与大于区第一个元素交换
        (arr[to], arr[bigPointer]) = (arr[bigPointer], arr[to]);
        bigPointer++;
        return new[] {smallPointer, bigPointer};
    }


    public static void HeapSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            HeapInsert(arr,i);
        }

        int heapSize = arr.Length;
        while (heapSize > 0)
        {
            heapSize--;
            Util.Tools.Swap(arr,heapSize,0);
            Heapify(arr,0,heapSize);
        }

    }

    // 上浮
    public static void HeapInsert(int[] arr,int index)
    {
        int parent = (index - 1) / 2;
        while (arr[index] > arr[parent])
        {
            Util.Tools.Swap(arr,index,parent);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    // 下沉
    public static void Heapify(int[] arr, int index, int heapSize)
    {
        // 左孩子
        int left = index * 2 + 1;
        while (left < heapSize)
        {
            int largest = left;
            if (left + 1 < heapSize && arr[left + 1] > arr[left])
                largest = left + 1;
            if (arr[index] > arr[largest])
            {
                return;
            }
            Util.Tools.Swap(arr,index,largest);
            index = largest;
            left = index * 2 + 1;
        }
    }
}