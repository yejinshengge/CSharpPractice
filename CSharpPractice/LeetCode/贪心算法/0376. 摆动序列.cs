namespace CSharpPractice.LeetCode.贪心算法;

/**
 * 如果连续数字之间的差严格地在正数和负数之间交替，则数字序列称为 摆动序列 。
 * 第一个差（如果存在的话）可能是正数或负数。仅有一个元素或者含两个不等元素的序列也视作摆动序列。
 *
 * 子序列 可以通过从原始序列中删除一些（也可以不删除）元素来获得，剩下的元素保持其原始顺序。
 * 给你一个整数数组 nums ，返回 nums 中作为 摆动序列 的 最长子序列的长度 。
 */
public class LeetCode_0376
{
    public static void Test()
    {
        LeetCode_0376 obj = new LeetCode_0376();
        Console.WriteLine(obj.WiggleMaxLength(new[] { 1, 7, 4, 9, 2, 5 }));
        Console.WriteLine(obj.WiggleMaxLength(new[] { 1,17,5,10,13,15,10,5,16,8 }));
        Console.WriteLine(obj.WiggleMaxLength(new[] { 1,2,3,4,5,6,7,8,9 }));
    }

    public int WiggleMaxLength(int[] nums)
    {
        int preDif = 0, curDif = 0;
        int maxLen = 1;

        for (int i = 0; i < nums.Length-1; i++)
        {
            curDif = nums[i + 1] - nums[i];
            if ((preDif <= 0 && curDif > 0) || (preDif >= 0 && curDif < 0))
            {
                maxLen++;
                preDif = curDif;
            }
        }

        return maxLen;
    }
}