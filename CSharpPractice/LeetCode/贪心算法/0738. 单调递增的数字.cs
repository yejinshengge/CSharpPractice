namespace CSharpPractice.LeetCode.贪心算法;
/**
当且仅当每个相邻位数上的数字 x 和 y 满足 x <= y 时，我们称这个整数是单调递增的。
给定一个整数 n ，返回 小于或等于 n 的最大数字，且数字呈 单调递增 。
 */
public class LeetCode_0738
{
    public static void Test()
    {
        LeetCode_0738 obj = new LeetCode_0738();
        Console.WriteLine(obj.MonotoneIncreasingDigits(10));
        Console.WriteLine(obj.MonotoneIncreasingDigits(1234));
        Console.WriteLine(obj.MonotoneIncreasingDigits(332));
    }
    
    public int MonotoneIncreasingDigits2(int n)
    {
        string strNum = n.ToString();
        int res = 0;
        unsafe
        {
            fixed (char* point = strNum)
            {
                int flag = strNum.Length;
                for (int i = strNum.Length-1; i > 0; i--)
                {
                    if (point[i] < point[i - 1])
                    {
                        point[i-1]--;
                        flag = i;
                    }
                }

                for (int i = flag; i < strNum.Length; i++)
                {
                    point[i] = '9';
                }

                res = int.Parse(strNum);
            }
        }

        return res;
    }

    public int MonotoneIncreasingDigits(int n)
    {
        char[] strNum = n.ToString().ToCharArray();
        int res = 0;

        int flag = strNum.Length;
        for (int i = strNum.Length-1; i > 0; i--)
        {
            if (strNum[i] < strNum[i - 1])
            {
                strNum[i-1]--;
                flag = i;
            }
        }

        for (int i = flag; i < strNum.Length; i++)
        {
            strNum[i] = '9';
        }

        res = int.Parse(strNum);
        
        return res;
    }
}