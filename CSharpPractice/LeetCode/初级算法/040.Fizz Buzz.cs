namespace CSharpPractice.LeetCode.初级算法;

/**
    给你一个整数 n ，找出从 1 到 n 各个整数的 Fizz Buzz 表示，并用字符串数组 answer（下标从 1 开始）返回结果，其中：
    answer[i] == "FizzBuzz" 如果 i 同时是 3 和 5 的倍数。
    answer[i] == "Fizz" 如果 i 是 3 的倍数。
    answer[i] == "Buzz" 如果 i 是 5 的倍数。
    answer[i] == i （以字符串形式）如果上述条件全不满足。
 */
public class LeetCode_040
{
    public static void Test()
    {
        LeetCode_040 obj = new LeetCode_040();
        var buzz = obj.FizzBuzz(5);
        Console.WriteLine(buzz);
    }

    public IList<string> FizzBuzz(int n)
    {
        List<string> res = new List<string>(n+1);
        for (int i = 1; i <= n; i++)
        {
            if (i % 15 == 0)
                res.Add("FizzBuzz");
            else if(i % 3 == 0)
                res.Add("Fizz");
            else if(i % 5 == 0)
                res.Add("Buzz");
            else
                res.Add(i.ToString());
        }

        return res;
    }
}