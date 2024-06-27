namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_03
{
    public static void Test()
    {
        LeetCode_10_03 obj = new LeetCode_10_03();
        Console.WriteLine(obj.Search(new []{15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14},5));
        Console.WriteLine(obj.Search(new []{15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14},11));
    }
    
    public int Search(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;

            // 左侧升序
            if (arr[left] < arr[mid])
            {
                // 在左侧
                if (arr[mid] >= target && arr[left] <= target)
                    right = mid;
                else
                    left = mid + 1;
            }
            // 左侧非升序
            else if(arr[left] > arr[mid])
            {
                // 在左侧
                if (arr[left] <= target || arr[mid] >= target)
                    right = mid;
                else
                    left = mid + 1;
            }
            // 无法判断
            else
            {
                if (arr[left] != target)
                    left++;
                else
                    right = left;
            }

        }

        return left < arr.Length && arr[left] == target ? left : -1;
    }
}