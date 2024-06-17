namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_03
{
    public static void Test()
    {
        LeetCode_05_03 obj = new LeetCode_05_03();
        Console.WriteLine(obj.ReverseBits(1775));
        Console.WriteLine(obj.ReverseBits(7));
        // 1111111111111111111111111111110
        Console.WriteLine(obj.ReverseBits(2147483646));
        // 10101110011011011000110000
        Console.WriteLine(obj.ReverseBits(45725232));
        Console.WriteLine(obj.ReverseBits(-1));
    }
    
    // 双指针
    public int ReverseBits1(int num)
    {
        int left = 0, right = 0, index = -1,len = 0;
        for (int i = 0; i < 32; i++)
        {
            int cur = num & (1<<i);
            if (cur != 0)
            {
                left++;
            }
            else if (index == -1)
            {
                index = left;
                left++;
            }
            else
            {
                len = Math.Max(left - right, len);
                right = index + 1;
                index = -1;
                i--;
            }
        }
        len = Math.Max(len, left - right );
        return len;
    }

    // 动态规划
    public int ReverseBits2(int num)
    {
        int[] curArr = new int[33];
        int[] reverseArr = new int[33];

        int max = 0;
        for (int i = 1; i <= 32; i++)
        {
            int cur = num & (1 << i-1);
            if (cur != 0)
            {
                curArr[i] = curArr[i - 1] + 1;
                reverseArr[i] = reverseArr[i - 1] + 1;
            }
            else
            {
                curArr[i] = 0;
                reverseArr[i] = curArr[i - 1] + 1;
            }

            max = Math.Max(reverseArr[i],max);
        }
        
        return max;
    }
    
    // 动态规划优化
    public int ReverseBits(int num)
    {
        int cur = 0, reverse = 0, max = 0;
        for (int i = 1; i <= 32; i++)
        {
            int curBit = num & (1 << i-1);
            if (curBit != 0)
            {
                reverse++;
                cur++;
            }
            else
            {
                reverse = cur+1;
                cur = 0;
            }

            max = Math.Max(max, reverse);
        }

        return max;
    }
}