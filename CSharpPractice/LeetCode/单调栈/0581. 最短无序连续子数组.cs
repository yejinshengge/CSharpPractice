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
        // left记录需要排序的最左边界，right记录最右边界
        int left = nums.Length, right = 0;
        
        // 第一次遍历：从左到右，找最左边界
        for (int i = 0; i < nums.Length; i++)
        {
            // 当栈不为空，且栈顶元素大于当前元素时
            // 说明找到了一个逆序对，需要更新left
            while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
            {
                left = Math.Min(left, stack.Pop());
            }
            stack.Push(i);
        }
        
        stack.Clear();
        // 第二次遍历：从右到左，找最右边界
        for (int i = nums.Length-1; i >= 0; i--)
        {
            // 当栈不为空，且栈顶元素小于当前元素时
            // 说明找到了一个逆序对，需要更新right
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
            {
                right = Math.Max(right, stack.Pop());
            }
            stack.Push(i);
        }

        // 如果right > left说明找到了需要排序的子数组
        // 否则说明数组已经有序
        return right > left ? right - left + 1 : 0;
    }
}