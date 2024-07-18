namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR003
{
    public static void Test()
    {
        LeetCode_LCR003 obj = new LeetCode_LCR003();
    }
    
    public int[] CountBits1(int n)
    {
        int[] res = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            // i & (i-1)将i最右侧的1变为0
            // 所以i比i & (i-1)多一个1
            res[i] = res[i & (i - 1)] + 1;
        }

        return res;
    }

    public int[] CountBits(int n)
    {
        int[] res = new int[n + 1];
        for (int i = 1; i <=n; i++)
        {
            // 如果i是偶数,最低位是0,1的数量与i>>1相同
            // 如果i是奇数,最低位是1,1的数量比1>>1多1
            res[i] = res[i >> 1] + (i & 1);
        }

        return res;
    }
}