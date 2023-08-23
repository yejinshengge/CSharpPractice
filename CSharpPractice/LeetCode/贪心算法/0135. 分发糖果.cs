namespace CSharpPractice.LeetCode.贪心算法;

/**
n 个孩子站成一排。给你一个整数数组 ratings 表示每个孩子的评分。

你需要按照以下要求，给这些孩子分发糖果：

每个孩子至少分配到 1 个糖果。
相邻两个孩子评分更高的孩子会获得更多的糖果。
请你给每个孩子分发糖果，计算并返回需要准备的 最少糖果数目 。


 */
public class LeetCode_0135
{
    public static void Test()
    {
        LeetCode_0135 obj = new LeetCode_0135();
        Console.WriteLine(obj.Candy(new []{1,0,2}));
        Console.WriteLine(obj.Candy(new []{1,2,2}));
        Console.WriteLine(obj.Candy(new []{1,2,3,4}));
        Console.WriteLine(obj.Candy(new []{4,3,2,1}));
        Console.WriteLine(obj.Candy(new []{4,3,2,1,2,3,4}));
        Console.WriteLine(obj.Candy(new []{4,2,3,1,5}));
        Console.WriteLine(obj.Candy(new []{1,3,4,5,2}));
    }
    
    public int Candy(int[] ratings)
    {
        int[] values = new int[ratings.Length];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = 1;
        }

        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i] > ratings[i - 1])
                values[i] = values[i - 1] + 1;
        }

        for (int i = ratings.Length-2; i >=0; i--)
        {
            if (ratings[i] > ratings[i + 1] && values[i] <= values[i+1])
                values[i] = values[i + 1] + 1;
        }

        int res = 0;
        for (int i = 0; i < values.Length; i++)
        {
            res += values[i];
        }

        return res;
    }
}