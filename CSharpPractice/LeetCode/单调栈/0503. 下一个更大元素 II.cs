using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.单调栈;

/**
给定一个循环数组 nums （ nums[nums.length - 1] 的下一个元素是 nums[0] ），
返回 nums 中每个元素的 下一个更大元素 。
数字 x 的 下一个更大的元素 是按数组遍历顺序，这个数字之后的第一个比它更大的数，
这意味着你应该循环地搜索它的下一个更大的数。如果不存在，则输出 -1 。
 */
public class LeetCode_0503
{
    public static void Test()
    {
        LeetCode_0503 obj = new LeetCode_0503();
        Tools.PrintArr(obj.NextGreaterElements(new []{1,2,1}));
        Tools.PrintArr(obj.NextGreaterElements(new []{1,2,3,4,3}));
        Tools.PrintArr(obj.NextGreaterElements(new []{1}));
    }
    
    public int[] NextGreaterElements(int[] nums)
    {
        Stack<int> stack = new Stack<int>();
        int[] res = new int[nums.Length];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = -1;
        }
        stack.Push(0);
        for (int i = 1; i < nums.Length*2; i++)
        {
            var index = i%nums.Length;
            while (stack.Count > 0 && nums[stack.Peek()] < nums[index])
            {
                var pop = stack.Pop();
                res[pop] = nums[index];
            }
            stack.Push(index);
        }

        return res;
    }
}