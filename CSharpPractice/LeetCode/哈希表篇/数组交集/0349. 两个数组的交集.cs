using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.哈希表篇.数组交集;

// 给定两个数组 nums1 和 nums2 ，返回 它们的交集 。
// 输出结果中的每个元素一定是 唯一 的。我们可以 不考虑输出结果的顺序 。
public class LeetCode_0349
{
    public static void Test()
    {
        LeetCode_0349 obj = new LeetCode_0349();
        Util.Tools.PrintArr(obj.Intersection(new []{1,2,2,1},new []{2,2}));
        Util.Tools.PrintArr(obj.Intersection(new []{4,9,5},new []{9,4,9,8,4}));
        Util.Tools.PrintArr(obj.Intersection(new []{1},new []{2}));
    }

    public int[] Intersection(int[] nums1, int[] nums2)
    {
        HashSet<int> dic = new HashSet<int>();
        HashSet<int> res = new HashSet<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            dic.Add(nums1[i]);
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dic.Contains(nums2[i]))
                res.Add(nums2[i]);
        }

        return res.ToArray();
    }
    
}