namespace CSharpPractice.LeetCode.数组篇;

/**
给你一个正整数 num 。如果 num 是一个完全平方数，则返回 true ，否则返回 false 。
完全平方数 是一个可以写成某个整数的平方的整数。换句话说，它可以写成某个整数和自身的乘积。
不能使用任何内置的库函数，如 sqrt 。

 */
public class LeetCode_0367
{
    public static void Test()
    {
        LeetCode_0367 obj = new LeetCode_0367();
        // Console.WriteLine(obj.IsPerfectSquare(16));
        // Console.WriteLine(obj.IsPerfectSquare(14));
        // Console.WriteLine(obj.IsPerfectSquare(1));
        Console.WriteLine(obj.IsPerfectSquare(5));

    }

    public bool IsPerfectSquare(int num)
    {
        int left = 1, right = num;
        
        while (left <= right)
        {
            int mid = (right - left) / 2 + left;
            var res = num/mid;
            
            if (mid  < res)
            {
                left = mid + 1;
            }
            else if (mid > res)
            {
                right = mid - 1;
            }
            else
            {
                if(num%mid == 0)
                    return true;
                left = mid + 1;
            }
        }

        return false;
    }
}