namespace CSharpPractice.LeetCode.数学.数组;

/**
 * 给你一个长度为 n 的整数数组，每次操作将会使 n - 1 个元素增加 1 。返回让数组所有元素相等的最小操作次数。
 */
public class LeetCode_0453
{
    public static void Test()
    {
        LeetCode_0453 obj = new LeetCode_0453();
        Console.WriteLine(obj.MinMoves(new []{1,2,3}));
        Console.WriteLine(obj.MinMoves(new []{1,1,1}));
    }
    
    public int MinMoves(int[] nums)
    {
        int minNum = nums.Min();
        int res = 0;
        foreach (var num in nums)
        {
            res += num - minNum;
        }

        return res;
    }
}