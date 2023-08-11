namespace CSharpPractice.Class02.动态规划;

public class Password
{
    public static void PasswordMain()
    {
        Password obj = new Password();
        Console.WriteLine(obj.Process(1));
        Console.WriteLine(obj.Process(2));
        Console.WriteLine(obj.Process(3));
        Console.WriteLine(obj.Process(4));
    }
    private int Process(int total,int pre=0, int cur=0, int num=0)
    {
        if (num > 1 && (pre == cur || Math.Abs(pre - cur) > 2))
            return 0;
        if (num == total)
            return 1;
        return Process(total,cur, 1, num + 1) + 
               Process(total,cur, 2, num + 1) + 
               Process(total,cur, 3, num + 1) +
               Process(total,cur, 4, num + 1);
    }

    private Dictionary<int, int> _dictionary = new();
    private int Process2(int total,int pre=0, int cur=0, int num=0)
    {
        if (num > 1 && (pre == cur || Math.Abs(pre - cur) > 2))
            return 0;
        if (num == total)
            return 1;
        return Process2(total,cur, 1, num + 1) + 
               Process2(total,cur, 2, num + 1) + 
               Process2(total,cur, 3, num + 1) +
               Process2(total,cur, 4, num + 1);
    }
}