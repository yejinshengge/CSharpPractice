namespace CSharpPractice.LeetCode;

public class Offer010NumWays
{
    private const int MOD = 1000000007;
    private Dictionary<int, int> _dic = new();
    public int NumWays(int n)
    {
        if (n == 0)
            return 1;
        if (n < 0)
            return 0;
        if (_dic.ContainsKey(n))
            return _dic[n];
        int res = (NumWays(n - 1) + NumWays(n - 2)) % MOD;
        _dic[n] = res;
        return res;
    }

    public int NumWays2(int n)
    {
        if (n == 0)
            return 1;
        int left = 0;
        int right = 1;
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res = (left + right) % MOD;
            left = right;
            right = res;
        }
        return res;
    }

    public static void Offer010NumWaysMain()
    {
        Offer010NumWays obj = new();
        Console.WriteLine(obj.NumWays(2));
        Console.WriteLine(obj.NumWays(7));
        Console.WriteLine(obj.NumWays(100));
        Console.WriteLine(obj.NumWays2(100));
        
    }
    
}