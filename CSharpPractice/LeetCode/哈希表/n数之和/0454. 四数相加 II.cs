namespace CSharpPractice.LeetCode.哈希表篇.四数相加;

/**
给你四个整数数组 nums1、nums2、nums3 和 nums4 ，数组长度都是 n ，请你计算有多少个元组 (i, j, k, l) 能满足：
0 <= i, j, k, l < n
nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
 */
public class LeetCode_0454
{
    public static void Test()
    {
        LeetCode_0454 obj = new LeetCode_0454();
        Console.WriteLine(obj.FourSumCount2(new []{1,2},new []{-2,-1},new []{-1,2},new []{0,2}));
    }

    // 思路一:四层循环嵌套
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        int total = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                for (int k = 0; k < nums3.Length; k++)
                {
                    for (int l = 0; l < nums4.Length; l++)
                    {
                        if (nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0)
                            total++;
                    }
                }
            }
        }
        return total;
    }
    // 分成两个两数之和
    public int FourSumCount2(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                var sum = nums1[i] + nums2[j];
                dic.TryAdd(sum, 0);
                dic[sum]++;
            }
        }

        int total = 0;
        for (int i = 0; i < nums3.Length; i++)
        {
            for (int j = 0; j < nums4.Length; j++)
            {
                var sum = nums3[i] + nums4[j];
                if (dic.ContainsKey(-sum))
                    total += dic[-sum];
            }
        }

        return total;
    }
}