using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你两个按 非递减顺序 排列的整数数组nums1 和 nums2，另有两个整数 m 和 n ，分别表示 nums1 和 nums2 中的元素数目。
 * 请你 合并 nums2 到 nums1 中，使合并后的数组同样按 非递减顺序 排列。
 */
public class LeetCode_032
{
    public static void Test()
    {
        LeetCode_032 obj = new LeetCode_032();
        var arr1 = new[] { 1, 2, 3, 0, 0, 0 };
        var arr2 = new[] { 2, 5, 6 };
        obj.Merge2(arr1,3,arr2,3);
        Util.Tools.PrintArr(arr1);
    }
    
    // 思路一:先合并再排序
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int index = 0;
        for (int i = m; i < m+n; i++)
        {
            nums1[i] = nums2[index++];
        }
        
        Array.Sort(nums1);
    }

    // 思路二:双指针,利用nums2交换
    public void Merge2(int[] nums1, int m, int[] nums2, int n)
    {
        int index = m + n - 1;
        int nums1Index = m - 1;
        int nums2Index = n - 1;

        while (nums2Index >= 0)
        {
            nums1[index--] = (nums1Index >= 0 &&nums1[nums1Index] > nums2[nums2Index]) ? nums1[nums1Index--] : nums2[nums2Index--];
        }
    }
}