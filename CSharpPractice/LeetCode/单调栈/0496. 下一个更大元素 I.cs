using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.单调栈;

/**
nums1 中数字 x 的 下一个更大元素 是指 x 在 nums2 中对应位置 右侧 的 第一个 比 x 大的元素。

给你两个 没有重复元素 的数组 nums1 和 nums2 ，下标从 0 开始计数，其中nums1 是 nums2 的子集。

对于每个 0 <= i < nums1.length ，找出满足 nums1[i] == nums2[j] 的下标 j ，并且在 nums2 确定 nums2[j] 的 
下一个更大元素 。如果不存在下一个更大元素，那么本次查询的答案是 -1 。

返回一个长度为 nums1.length 的数组 ans 作为答案，满足 ans[i] 是如上所述的 下一个更大元素 。
 */
public class LeetCode_0496
{
    public static void Test()
    {
        LeetCode_0496 obj = new LeetCode_0496();
        Tools.PrintArr(obj.NextGreaterElement(new []{4,1,2},new []{1,3,4,2}));
        Tools.PrintArr(obj.NextGreaterElement(new []{2,4},new []{1,2,3,4}));
        Tools.PrintArr(obj.NextGreaterElement(new []{2},new []{2}));
    }
    
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Stack<int> stack = new Stack<int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int[] res = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            dic[nums1[i]] = i;
            res[i] = -1;
        }
        stack.Push(0);
        for (int i = 1; i < nums2.Length; i++)
        {
            while (stack.Count > 0 && nums2[i] > nums2[stack.Peek()])
            {
                var pop = stack.Pop();
                if (dic.TryGetValue(nums2[pop], out var index))
                {
                    res[index] = nums2[i];
                }
            }
            stack.Push(i);
        }

        return res;
    }
}