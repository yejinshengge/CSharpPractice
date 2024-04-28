namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0004
{
    public static void Test()
    {
        LeetCode_0004 obj = new LeetCode_0004();
        Console.WriteLine(obj.FindMedianSortedArrays(new []{1,3},new []{2}));
        Console.WriteLine(obj.FindMedianSortedArrays(new []{1,2},new []{3,4}));
        Console.WriteLine(obj.FindMedianSortedArrays(new []{3,4},new []{1,2}));
        Console.WriteLine(obj.FindMedianSortedArrays(new []{1,2,3,4},new []{10}));
    }
    
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int totalLen = nums1.Length + nums2.Length;
        if (totalLen % 2 == 0)
            return (_find(nums1, 0, nums2, 0, totalLen / 2) + 
                   _find(nums1, 0, nums2, 0, totalLen / 2 + 1)) / 2.0;
        return _find(nums1, 0, nums2, 0, totalLen / 2+1);
    }

    private int _find(int[] nums1, int index1, int[] nums2, int index2, int k)
    {
        if (nums1.Length-index1 > nums2.Length-index2) return _find(nums2, index2, nums1, index1, k);
        if (index1 >= nums1.Length) return nums2[index2 + k - 1];
        if (k == 1)
            return Math.Min(nums1[index1], nums2[index2]);
        int curIndex1 = Math.Min(nums1.Length, index1 + (k / 2));
        int curIndex2 = index2 + k - k / 2;

        if (nums1[curIndex1-1] <= nums2[curIndex2-1])
            return _find(nums1, curIndex1, nums2, index2, k - (curIndex1 - index1));
        return _find(nums1, index1, nums2, curIndex2, k - (curIndex2 - index2));
    }
}