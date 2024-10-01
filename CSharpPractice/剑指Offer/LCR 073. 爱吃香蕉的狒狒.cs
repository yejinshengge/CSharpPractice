namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR073
{
    public static void Test()
    {
        LeetCode_LCR073 obj = new LeetCode_LCR073();
        Console.WriteLine(obj.MinEatingSpeed(new int[]{3,6,7,11},8));
        Console.WriteLine(obj.MinEatingSpeed(new int[]{30,11,23,4,20},5));
        Console.WriteLine(obj.MinEatingSpeed(new int[]{30,11,23,4,20},6));
    }
    
    public int MinEatingSpeed(int[] piles, int h)
    {
        var max = piles.Max();
        int left = 1, right = max;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int totalHours = 0;
            foreach (var pile in piles)
            {
                totalHours += (int)Math.Ceiling((double)pile / mid);
            }

            if (totalHours <= h)
                right = mid;
            else
                left = mid + 1;
        }

        return right;
    }
}