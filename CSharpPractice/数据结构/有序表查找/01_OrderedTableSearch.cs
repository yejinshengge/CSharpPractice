namespace CSharpPractice.数据结构.有序表查找;

public class OrderedTableSearch {

    public static void OrderedTableSearchMain()
    {
        OrderedTableSearch obj = new OrderedTableSearch();
        int[] arr = new int[] {0, 1, 16, 24, 35, 47, 59, 62, 73, 88, 99};
        Console.WriteLine(obj.BinarySearch(arr,0));
    }

    /// <summary>
    /// 二分查找
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="target"></param>
    private int BinarySearch<T>(T[] arr,T target) where T:IComparable<T>
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            // 中间大于目标值,查左侧
            if (arr[mid].CompareTo(target) > 0)
            {
                right = mid-1;
            }
            // 中间小于目标值,查右侧
            else if (arr[mid].CompareTo(target) < 0)
            {
                left = mid+1;
            }
            else
            {
                return mid;
            }
        }
        return -1;
    }
}