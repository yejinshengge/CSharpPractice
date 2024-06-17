namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_07
{
    public static void Test()
    {
        LeetCode_05_07 obj = new LeetCode_05_07();
        Console.WriteLine(obj.ExchangeBits(2));
        Console.WriteLine(obj.ExchangeBits(3));
    }
    
    public int ExchangeBits(int num)
    {
        int odd = num & 0x55555555;
        int even = (int)(num & 0xaaaaaaaa);

        return (odd << 1) | (even >> 1);
    }
}