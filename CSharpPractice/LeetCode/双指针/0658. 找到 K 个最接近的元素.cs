using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0658
{
    public static void Test()
    {
        LeetCode_0658 obj = new LeetCode_0658();
        Tools.PrintEnumerator(obj.FindClosestElements(new []{1,2,3,4,5},4,3));
        Tools.PrintEnumerator(obj.FindClosestElements(new []{1,2,3,4,5},4,-1));
        Tools.PrintEnumerator(obj.FindClosestElements(new []{-2,-1,1,2,3,4,5},7,3));
        Tools.PrintEnumerator(obj.FindClosestElements(new []{1,2,3,4,5},4,3));
        Tools.PrintEnumerator(obj.FindClosestElements(new []{0,2,2,3,4,6,7,8,9,9},4,5));
        Tools.PrintEnumerator(obj.FindClosestElements(new []{1,3},1,2));
        Tools.PrintEnumerator(obj.FindClosestElements(new []{1,1,1,10,10,10},1,9));
    }
    
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        // 二分找到目标值
        int left = 0, right = arr.Length - 1;
        while (left<right)
        {
            int mid = left + right + 1 >> 1;
            if (arr[mid] <= x)
                left = mid;
            else
                right = mid - 1;
        }

        right = right + 1 < arr.Length && Math.Abs(arr[right + 1] - x) 
            < Math.Abs(arr[right] - x) ? right + 1 : right;
        // 双指针找出符合条件的元素
        List<int> res = new List<int>();
        res.Add(arr[right]);
        left=right-1;
        right=right+1;
        for (int i = 0; i < k-1; i++)
        {
            if (left >= 0 && right < arr.Length)
            {
                if (Math.Abs(arr[left] - x) > Math.Abs(arr[right] - x))
                    res.Add(arr[right++]);
                else
                    res.Add(arr[left--]);
            }
            else if(left >= 0)
                res.Add(arr[left--]);
            else
                res.Add(arr[right++]);
        }
        res.Sort();
        return res;
    }
}