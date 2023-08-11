using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你两个整数数组nums1 和 nums2 ，请你以数组形式返回两数组的交集。返回结果中每个元素出现的次数，
 * 应与元素在两个数组中都出现的次数一致（如果出现次数不一致，则考虑取较小值）。可以不考虑输出结果的顺序。
 */
public class LeetCode_006 {

    public static void LeetCode_006Main()
    {
        LeetCode_006 obj = new LeetCode_006();
        Util.Tools.PrintArr(obj.Intersect2(new []{4,9,5},new []{9,4,9,8,4}));
        Util.Tools.PrintArr(obj.Intersect1(new []{4,9,5},new []{9,4,9,8,4}));
    }
    // 思路1:字典
    public int[] Intersect1(int[] nums1, int[] nums2)
    {
        List<int> res = new List<int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            if (dic.ContainsKey(nums1[i]))
                dic[nums1[i]]++;
            else
                dic[nums1[i]] = 1;
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dic.ContainsKey(nums2[i]))
            {
                res.Add(nums2[i]);
                dic[nums2[i]]--;
                if (dic[nums2[i]] == 0) dic.Remove(nums2[i]);
            }
        }

        return res.ToArray();
    }

    // 思路2:排序+双指针
    public int[] Intersect2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        int index1 = 0;
        int index2 = 0;

        List<int> res = new List<int>();
        while (index1 < nums1.Length && index2 < nums2.Length)
        {
            if (nums1[index1] == nums2[index2])
            {
                res.Add(nums1[index1]);
                index1++;
                index2++;
            }
            
            else if (nums1[index1] < nums2[index2])
            {
                index1++;
            }
            
            else if (nums1[index1] > nums2[index2])
            {
                index2++;
            }
        }

        return res.ToArray();
    }
}