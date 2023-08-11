namespace CSharpPractice.LeetCode;

public class Offer015HammingWeight
{
    public int HammingWeight(uint n)
    {
        int res = 0;
        while (n != 0)
        {
            if ((n & 1) == 1)
                res++;
            n >>= 1;
        }

        return res;
    }

    public int HammingWeight2(uint n)
    {
        int res = 0;
        uint flag = 1;
        for (int i = 0; i < 32; i++)
        {
            if ((n & flag) != 0)
                res++;
            flag <<= 1;
        }
        return res;
    }
    public int HammingWeight3(uint n)
    {
        int res = 0;
        while (n != 0)
        {
            res++;
            n = (n - 1) & n;
        }
        return res;
    }

    public static void Offer015HammingWeightMain()
    {
        Offer015HammingWeight obj = new();
        Console.WriteLine(obj.HammingWeight(11));
        Console.WriteLine(obj.HammingWeight(128));
        Console.WriteLine(obj.HammingWeight(4294967293));
        
        Console.WriteLine(obj.HammingWeight2(11));
        Console.WriteLine(obj.HammingWeight2(128));
        Console.WriteLine(obj.HammingWeight2(4294967293));
        
        Console.WriteLine(obj.HammingWeight3(11));
        Console.WriteLine(obj.HammingWeight3(128));
        Console.WriteLine(obj.HammingWeight3(4294967293));
    }
}