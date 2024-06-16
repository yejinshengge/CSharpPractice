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
    public int ReverseBits(int num)
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
    
}