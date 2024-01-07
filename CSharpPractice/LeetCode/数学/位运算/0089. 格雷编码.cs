using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.位运算;

/**
 * n 位格雷码序列 是一个由 2n 个整数组成的序列，其中：
    每个整数都在范围 [0, 2n - 1] 内（含 0 和 2n - 1）
    第一个整数是 0
    一个整数在序列中出现 不超过一次
    每对 相邻 整数的二进制表示 恰好一位不同 ，且
    第一个 和 最后一个 整数的二进制表示 恰好一位不同
    给你一个整数 n ，返回任一有效的 n 位格雷码序列 。
 */
public class LeetCode_0089
{
    public static void Test()
    {
        LeetCode_0089 obj = new LeetCode_0089();
        Tools.PrintEnumerator(obj.GrayCode(2));
        Tools.PrintEnumerator(obj.GrayCode(1));
    }
    
    public IList<int> GrayCode(int n)
    {
        List<int> res = new List<int>(){0};
        int head = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = res.Count-1; j >= 0; j--)
            {
                res.Add(head+res[j]);
            }

            head <<= 1;
        }

        return res;
    }
}