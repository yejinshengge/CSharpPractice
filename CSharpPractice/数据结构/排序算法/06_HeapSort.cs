using CSharpPractice.Util;

namespace CSharpPractice.数据结构.排序算法;

public class HeapSort {

    public static void HeapSortMain()
    {
        var arr = Util.Tools.RandomArr(10, 0, 10);
        Util.Tools.PrintArr(arr);
        HeapSortFunc2(arr);
        Util.Tools.PrintArr(arr);
    }

    public static void HeapSortFunc<T>(T[] arr) where T : IComparable
    {
        // 构成大根堆
        for (int i = 0; i < arr.Length; i++)
        {
            HeapInsert(arr,i);
        }

        int heapSize = arr.Length;
        while (heapSize > 0)
        {
            // 将根节点挪到最后,缩小堆,进行下沉
            Swap(arr,--heapSize,0);
            Heapify(arr,0,heapSize);
        }
    }

    /// <summary>
    /// 上浮
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    private static void HeapInsert<T>(T[] arr,int index) where T : IComparable
    {
        int parent = (index - 1) / 2;
        // 当前节点大于父节点,则交换
        while (arr[index].CompareTo(arr[parent])>0)
        {
            Swap(arr,index,parent);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    /// <summary>
    /// 下沉
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index"></param>
    /// <param name="heapSize"></param>
    /// <typeparam name="T"></typeparam>
    private static void Heapify<T>(T[] arr,int index,int heapSize)where T : IComparable
    {
        int leftChild = index * 2 + 1;
        while (leftChild < heapSize)
        {
            int large = leftChild;
            // 比较左右孩子
            if (leftChild + 1 < heapSize && arr[leftChild].CompareTo(arr[leftChild + 1]) < 0)
                large = leftChild + 1;
            // 与父节点比较
            if (arr[large].CompareTo(arr[index]) < 0)
                break;
            // 较大的孩子与父节点交换
            Swap(arr,large,index);
            index = large;
            leftChild = index * 2 + 1;
        }
    }
    
    private static void Swap<T>(T[] arr, int index1, int index2)
    {
        (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
    }


    public static void HeapSortFunc2<T>(T[] arr) where T : IComparable
    {
        int heapSize = arr.Length;
        // 构成大根堆
        for (int i = 0; i < heapSize; i++)
        {
            HeapInsert2(arr,i);
        }

        while (heapSize > 0)
        {
            // 把根节点挪到最后,缩小堆
            Swap(arr,0,--heapSize);
            // 重新堆化
            Heapify2(arr,0,heapSize);
        }
    }

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    private static void HeapInsert2<T>(T[] arr, int index) where T : IComparable
    {
        int parent = (index - 1) / 2;
        // 当前节点大于父节点,交换
        while (arr[index].CompareTo(arr[parent]) > 0)
        {
            Swap(arr,index,parent);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    /// <summary>
    /// 堆化
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index"></param>
    /// <param name="heapSize"></param>
    /// <typeparam name="T"></typeparam>
    private static void Heapify2<T>(T[] arr, int index, int heapSize) where T : IComparable
    {
        int leftChild = index * 2 + 1;
        while (leftChild < heapSize)
        {
            // 找到最大的孩子
            int large = leftChild;
            if (leftChild + 1 < heapSize && arr[leftChild + 1].CompareTo(arr[leftChild]) > 0)
                large = leftChild+1;
            // 比父节点小直接退出
            if(arr[index].CompareTo(arr[large]) > 0)
                break;
            // 交换父节点与最大孩子
            Swap(arr,large,index);
            index = large;
            leftChild = index * 2 + 1;
        }
    }
}