using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你一个整数数组 nums ，设计算法来打乱一个没有重复元素的数组。打乱后，数组的所有排列应该是等可能的。
 * 实现 Solution class:
 * 
 * Solution(int[] nums) 使用整数数组 nums 初始化对象
 * int[] reset() 重设数组到它的初始状态并返回
 * int[] shuffle() 返回数组随机打乱后的结果
 */
public class LeetCode_038
{
    public static void Test()
    {
        Solution so = new Solution(new []{1, 2, 3});
        Util.Tools.PrintArr(so.Shuffle());
        Util.Tools.PrintArr(so.Reset());
        Util.Tools.PrintArr(so.Shuffle());
    }

    private class Solution
    {
        private int[] _randomArr;
        private int[] _nums;

        public Solution(int[] nums)
        {
            _nums = nums;
            _randomArr = new int[nums.Length];
        }
    
        public int[] Reset()
        {
            return _nums;
        }

        public int[] Shuffle() {
            Array.Copy(_nums,_randomArr,_nums.Length);

            for (int i = 1; i < _randomArr.Length; i++)
            {
                int random = new Random().Next(0, i+1);
                (_randomArr[i], _randomArr[random]) = (_randomArr[random], _randomArr[i]);
            }
            return _randomArr;
        }
    }
}