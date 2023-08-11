namespace CSharpPractice.LeetCode.初级算法;

// 给定整数 n ，返回 所有小于非负整数 n 的质数的数量 。
public class LeetCode_041
{
    public static void Test()
    {
        LeetCode_041 obj = new LeetCode_041();
        Console.WriteLine(obj.CountPrimes3(1));
    }
    
    // 枚举
    public int CountPrimes(int n)
    {
        int res = 0;
        for (int i = 2; i < n; i++)
        {
            if (IsPrim1(i))
            {
                res++;
                Console.Write(i+" ");
            }
        }

        return res;
    }

    private bool IsPrim1(int n)
    {
        if (n <= 2) return true;
        int sqrt = (int)Math.Sqrt(n) + 1;
        
        for (int i = 2; i <= sqrt; i++)
        {
            if (n % i == 0) return false;
            
        }
        return true;
    }

    // 埃氏筛法
    public int CountPrimes2(int n)
    {
        // 是否是合数
        bool[] isCom = new bool[n];

        for (int i = 2; i <= n/i; i++)
        {
            if (!isCom[i])
            {
                // 从2开始按倍数筛
                for (int j = i*i; j < n; j+=i)
                {
                    isCom[j] = true;
                }
            }
        }

        int res = 0;
        for (int i = 2; i < n; i++)
        {
            if (!isCom[i]) res++;
        }

        return res;
    }

    // 欧拉筛
    public int CountPrimes3(int n)
    {
        // 存储素数
        int[] primes = new int[n];
        // 是否是合数
        bool[] isCom = new bool[n];
        int index = 0;

        for (int i = 2; i < n; i++)
        {
            // 如果是素数,直接存入数组
            if (!isCom[i]) primes[++index] = i;
            for (int j = 1; primes[j] * i < n; j++)
            {
                // 素数的倍数一定是合数
                isCom[i * primes[j]] = true;
                // 第一次与质数取余得零,代表这个质数一定是最小质因子,所以跳出
                if(i % primes[j] == 0) break;
            }
        }

        return index;
    }
}