using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.哈希表篇.数组交集;
/**
给你两个整数数组nums1 和 nums2 ，请你以数组形式返回两数组的交集。
返回结果中每个元素出现的次数，应与元素在两个数组中都出现的次数一致（如果出现次数不一致，则考虑取较小值）。
可以不考虑输出结果的顺序。
 */
public class LeetCode_0350
{
    public static void Test()
    {
        LeetCode_0350 obj = new LeetCode_0350();
        Util.Tools.PrintArr(obj.Intersect(new []{1,2,2,1},new []{2,2}));
        Util.Tools.PrintArr(obj.Intersect(new []{4,9,5},new []{9,4,9,8,4}));
        Util.Tools.PrintArr(obj.Intersect(new []{4},new []{9}));
    }
    
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        List<int> res = new List<int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            dic.TryAdd(nums1[i], 0);
            dic[nums1[i]]++;
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dic.ContainsKey(nums2[i]) && dic[nums2[i]] > 0)
            {
                res.Add(nums2[i]);
                dic[nums2[i]]--;
            }
        }

        return res.ToArray();
    }
}