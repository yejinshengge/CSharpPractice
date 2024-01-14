namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个整数数组 nums ，你可以对它进行一些操作。
    
    每次操作中，选择任意一个 nums[i] ，删除它并获得 nums[i] 的点数。
    之后，你必须删除 所有 等于 nums[i] - 1 和 nums[i] + 1 的元素。
    
    开始你拥有 0 个点数。返回你能通过这些操作获得的最大点数。
 */
public class LeetCode_0740
{
    public static void Test()
    {
        LeetCode_0740 obj = new LeetCode_0740();
        Console.WriteLine(obj.DeleteAndEarn(new []{3,4,2}));
        Console.WriteLine(obj.DeleteAndEarn(new []{2,2,3,3,3,4}));
    }
    
    public int DeleteAndEarn(int[] nums) {
        // 处理数组，将相同的元素合并
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            max = Math.Max(max, nums[i]);
        }

        int[] records = new int[max + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            records[nums[i]] += nums[i];
        }
        
        // 进行动态规划
        int first = records[0];
        int second = Math.Max(records[1], first);

        for (int i = 2; i < records.Length; i++)
        {
            int tmp = second;
            second = Math.Max(first + records[i], second);
            first = tmp;
        }

        return second;
    }
}