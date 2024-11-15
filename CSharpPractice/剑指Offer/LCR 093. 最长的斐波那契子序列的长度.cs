namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR093
{
    public static void Test()
    {
        LeetCode_LCR093 obj = new LeetCode_LCR093();
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,2,3,4,5,6,7,8}));// 5
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,3,7,11,12,14,18}));// 3
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,2,3}));// 3
        Console.WriteLine(obj.LenLongestFibSubseq(new []{1,4,7}));// 0
    }
    
    public int LenLongestFibSubseq(int[] arr)
    {
        Dictionary<int, int> dic = new();
        for (var i = 0; i < arr.Length; i++)
        {
            dic.Add(arr[i],i);
        }
        int[,] dp = new int[arr.Length,arr.Length];
        int maxLen = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int index = dic.GetValueOrDefault(arr[i] - arr[j], -1);
                dp[i, j] = index >= 0 && index < j ? dp[j, index] + 1 : 2;
                maxLen = Math.Max(maxLen, dp[i, j]);
            }
        }

        return maxLen == 2 ? 0 : maxLen;
    }
}