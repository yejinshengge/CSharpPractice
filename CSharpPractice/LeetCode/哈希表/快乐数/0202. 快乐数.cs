namespace CSharpPractice.LeetCode.哈希表篇.快乐数;
/**
编写一个算法来判断一个数 n 是不是快乐数。
「快乐数」定义为：
对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和。
然后重复这个过程直到这个数变为 1，也可能是 无限循环 但始终变不到 1。
如果这个过程 结果为1，那么这个数就是快乐数。
如果 n 是 快乐数 就返回 true ；不是，则返回 false 。
 */
public class LeetCode_0202
{
    public static void Test()
    {
        LeetCode_0202 obj = new LeetCode_0202();
        Console.WriteLine(obj.IsHappy(19));
        Console.WriteLine(obj.IsHappy(2));
        Console.WriteLine(obj.IsHappy(1));
    }

    public bool IsHappy(int n)
    {
        Dictionary<int, int> powDic = new Dictionary<int, int>()
        {
            [1] = 1,
            [2] = 4,
            [3] = 9,
            [4] = 16,
            [5] = 25,
            [6] = 36,
            [7] = 49,
            [8] = 64,
            [9] = 81,
            [0] = 0
        };
        HashSet<int> res = new HashSet<int>();
        while (n != 1)
        {
            int sum = 0;
            while (n>0)
            {
                sum += powDic[n % 10];
                n /= 10;
            }

            if (res.Contains(sum))
                return false;
            res.Add(sum);
            n = sum;
        }

        return true;
    }

}