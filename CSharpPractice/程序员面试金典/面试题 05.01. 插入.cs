namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_01
{
    public static void Test()
    {
        LeetCode_05_01 obj = new LeetCode_05_01();
        // Console.WriteLine(obj.InsertBits(1024,19,2,6));
        // Console.WriteLine(obj.InsertBits(0,31,0,4));
        Console.WriteLine(obj.InsertBits(2032243561,10,24,29));
    }
    
    public int InsertBits(int N, int M, int i, int j)
    {
        int k = ~((1 << j-i+1) - 1<<i);
        N &= k;
        M <<= i;
        return N|M;
    }
}