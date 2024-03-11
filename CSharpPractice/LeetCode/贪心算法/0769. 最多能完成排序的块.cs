namespace CSharpPractice.LeetCode.贪心算法;

/**
 * 给定一个长度为 n 的整数数组 arr ，它表示在 [0, n - 1] 范围内的整数的排列。
    
    我们将 arr 分割成若干 块 (即分区)，并对每个块单独排序。将它们连接起来后，使得连接的结果和按升序排序后的原数组相同。
    
    返回数组能分成的最多块数量。
 */
public class LeetCode_0769
{
    public static void Test()
    {
        LeetCode_0769 obj = new LeetCode_0769();
        Console.WriteLine(obj.MaxChunksToSorted(new []{4,3,2,1,0}));
        Console.WriteLine(obj.MaxChunksToSorted(new []{1,0,2,3,4}));
    }
    
    public int MaxChunksToSorted(int[] arr)
    {
        int res = 0;
        int max = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            max = Math.Max(max, arr[i]);
            if (max == i)
                res++;
        }

        return res;
    }
}