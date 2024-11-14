namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR092
{
    public static void Test()
    {
        LeetCode_LCR092 obj = new LeetCode_LCR092();
        Console.WriteLine(obj.MinFlipsMonoIncr("00110"));//1
        Console.WriteLine(obj.MinFlipsMonoIncr("010110"));//2
        Console.WriteLine(obj.MinFlipsMonoIncr("00011000"));//2
        Console.WriteLine(obj.MinFlipsMonoIncr("00000"));//0
        Console.WriteLine(obj.MinFlipsMonoIncr("11111"));//0
        Console.WriteLine(obj.MinFlipsMonoIncr("0"));//0
        Console.WriteLine(obj.MinFlipsMonoIncr("1"));//0
        Console.WriteLine(obj.MinFlipsMonoIncr("0001111"));//0
        Console.WriteLine(obj.MinFlipsMonoIncr("1111000"));//3
        
    }
    
    public int MinFlipsMonoIncr(string s)
    {
        int dp1 = 0,dp2 = 0;
        for (int i = 1; i <= s.Length; i++)
        {
            int tmp1 = dp1 + (s[i - 1] == '0' ? 0 : 1);
            int tmp2 = Math.Min(dp1, dp2) + (s[i - 1] == '1' ? 0 : 1);
            dp1 = tmp1;
            dp2 = tmp2;
        }

        return Math.Min(dp1, dp2);
    }
}