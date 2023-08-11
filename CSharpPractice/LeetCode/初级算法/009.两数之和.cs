using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
给定一个整数数组 nums和一个整数目标值 target，请你在该数组中找出 和为目标值 target 的那两个整数，并返回它们的数组下标。
你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
你可以按任意顺序返回答案。

 */
public class LeetCode_009 {

    public static void LeetCode_009Main()
    {
        LeetCode_009 obj = new LeetCode_009();
        Util.Tools.PrintArr(obj.TwoSum(new []{1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1},11));
    }
    
    // 定义一个字典,key为当前元素与target的差值,value为元素下标
    // 需要注意key重复
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(nums[i]))
            {
                return new[] {dic[nums[i]],i};
            }
            dic[target - nums[i]]=i;
        }
        return new []{0,0};
    }
}