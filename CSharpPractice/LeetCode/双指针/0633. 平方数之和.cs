namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0633
{
    public static void Test()
    {
        LeetCode_0633 obj = new LeetCode_0633();
        Console.WriteLine(obj.JudgeSquareSum(int.MaxValue));
        Console.WriteLine(obj.JudgeSquareSum(5));
        Console.WriteLine(obj.JudgeSquareSum(3));
        Console.WriteLine(obj.JudgeSquareSum(2));
    }
    
    public bool JudgeSquareSum(int c)
    {
        long right = (long)Math.Sqrt(c);
        long left = 0;
        while (left <= right)
        {
            var sum = right * right + left * left;
            if (sum > c)
                right--;
            else if (sum < c)
                left++;
            else
                return true;
        }
        return false;
    }
}