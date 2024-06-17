namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_06
{
    public static void Test()
    {
        LeetCode_05_06 obj = new LeetCode_05_06();
        Console.WriteLine(obj.ConvertInteger(29,15));
        Console.WriteLine(obj.ConvertInteger(1,2));
    }
    
    public int ConvertInteger(int a, int b)
    {
        int xor = a ^ b;
        int count = 0;
        while (xor != 0)
        {
            xor &= (xor - 1);
            count++;
        }

        return count;
    }
}