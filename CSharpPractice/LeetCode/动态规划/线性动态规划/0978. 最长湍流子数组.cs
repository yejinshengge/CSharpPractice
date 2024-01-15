namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给定一个整数数组 arr ，返回 arr 的 最大湍流子数组的长度 。
    
    如果比较符号在子数组中的每个相邻元素对之间翻转，则该子数组是 湍流子数组 。
    
    更正式地来说，当 arr 的子数组 A[i], A[i+1], ..., A[j] 满足仅满足下列条件时，我们称其为湍流子数组：
    
    若 i &lt;= k &lt; j ：
    当 k 为奇数时， A[k] &gt; A[k+1]，且
    当 k 为偶数时，A[k] &lt; A[k+1]；
    或 若 i &lt;= k &lt; j ：
    当 k 为偶数时，A[k] &gt; A[k+1] ，且
    当 k 为奇数时， A[k] &lt; A[k+1]。
 */
public class LeetCode_0978
{
    public static void Test()
    {
        LeetCode_0978 obj = new LeetCode_0978();
        Console.WriteLine(obj.MaxTurbulenceSize(new []{9,4,2,10,7,8,8,1,9}));
        Console.WriteLine(obj.MaxTurbulenceSize(new []{4,8,12,16}));
        Console.WriteLine(obj.MaxTurbulenceSize(new []{100}));
        Console.WriteLine(obj.MaxTurbulenceSize(new []{100,101}));
        Console.WriteLine(obj.MaxTurbulenceSize(new []{2,0,2,4,2,5,0,1,2,3}));
    }
    
    public int MaxTurbulenceSize(int[] arr)
    {
        int maxLen = 1;
        int dpB = 1, dpS = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                dpB = dpS + 1;
                dpS = 1;
            }
            else if (arr[i] < arr[i - 1])
            {
                dpS = dpB + 1;
                dpB = 1;
            }
            else
                dpB = dpS = 1;

            maxLen = Math.Max(maxLen, Math.Max(dpB, dpS));
        }

        return maxLen;
    }
}