namespace CSharpPractice.LeetCode.贪心算法;

/**
假设你是一位很棒的家长，想要给你的孩子们一些小饼干。但是，每个孩子最多只能给一块饼干。

对每个孩子 i，都有一个胃口值 g[i]，这是能让孩子们满足胃口的饼干的最小尺寸；
并且每块饼干 j，都有一个尺寸 s[j] 。如果 s[j] >= g[i]，我们可以将这个饼干 j 分配给孩子 i ，
这个孩子会得到满足。你的目标是尽可能满足越多数量的孩子，并输出这个最大数值。
 */
public class LeetCode_0455
{
    public static void Test()
    {
        LeetCode_0455 obj = new LeetCode_0455();
        var count = obj.FindContentChildren(new[] { 1, 2 }, new int[] { });
        Console.WriteLine(count);
    }
    
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);
        Array.Sort(s);

        int childIndex = 0;
        int cookieIndex = 0;

        while (childIndex < g.Length && cookieIndex < s.Length)
        {
            if (s[cookieIndex] >= g[childIndex])
            {
                cookieIndex++;
                childIndex++;
            }
            else
            {
                cookieIndex++;
            }
        }

        return childIndex;
    }
}