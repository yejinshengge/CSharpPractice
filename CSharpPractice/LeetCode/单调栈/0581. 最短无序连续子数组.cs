namespace CSharpPractice.LeetCode.单调栈;

/**
 * 给你一个整数数组 nums ，你需要找出一个 连续子数组 ，如果对这个子数组进行升序排序，那么整个数组都会变为升序排序。
    请你找出符合题意的 最短 子数组，并输出它的长度。
 */
public class LeetCode_0581
{
    public static void Test()
    {
        LeetCode_0581 obj = new LeetCode_0581();
        Console.WriteLine(obj.FindUnsortedSubarray(new []{2,6,4,8,10,9,15}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{1,2,3,4}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{0}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{4,5,3,2,1}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{5,4,3,2,1}));
        Console.WriteLine(obj.FindUnsortedSubarray(new []{1,3,2,2,2}));
    }
    
    public int FindUnsortedSubarray(int[] nums)
    {
        Stack<int> stack = new Stack<int>();
        int left = nums.Length,right = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
            {
                left = Math.Min(left, stack.Pop());
            }
            stack.Push(i);
        }
        stack.Clear();
        for (int i = nums.Length-1; i >=0; i--)
        {
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
            {
                right = Math.Max(right, stack.Pop());
            }
            stack.Push(i);
        }

        return right>left ?right - left + 1:0;
    }
}