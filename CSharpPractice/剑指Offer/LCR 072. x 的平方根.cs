namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR072
{
    public static void Test()
    {
        LeetCode_LCR072 obj = new LeetCode_LCR072();
        Console.WriteLine(obj.MySqrt(4));
        Console.WriteLine(obj.MySqrt(3));
        Console.WriteLine(obj.MySqrt(8));
        Console.WriteLine(obj.MySqrt(0));
        Console.WriteLine(obj.MySqrt(int.MaxValue));
    }
    
    public int MySqrt(int x)
    {
        int left = 1, right = (x >> 1) + 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (mid <= x / mid)
            {
                if ((mid + 1) > x/(mid + 1))
                    return mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        return 0;
    }
}