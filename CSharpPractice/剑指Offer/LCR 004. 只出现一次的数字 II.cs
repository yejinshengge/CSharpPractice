namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR004
{
    public static void Test()
    {
        LeetCode_LCR004 obj = new LeetCode_LCR004();
        Console.WriteLine(obj.SingleNumber(new []{2,2,3,2}));
        Console.WriteLine(obj.SingleNumber(new []{0,1,0,1,0,1,100}));
    }
    
    public int SingleNumber1(int[] nums)
    {
        int[] arr = new int[32];
        foreach (var num in nums)
        {
            for (int i = 0; i < 32; i++)
            {
                if ((num & (1 << i)) != 0)
                    arr[i]++;
            }
        }

        int res = 0;
        for (int i = 0; i < 32; i++)
        {
            if (arr[i] % 3 == 1)
                res += 1 << i;
        }

        return res;
    }

    public int SingleNumber(int[] nums)
    {
        int a = 0, b = 0;
        foreach (var num in nums)
        {
            int aNext = (~a & b & num) | (a & ~b & ~num);
            int bNext = (~a & ~b & num) | (~a & b & ~num);
            a = aNext;
            b = bNext;
        }

        return b;
    }
}