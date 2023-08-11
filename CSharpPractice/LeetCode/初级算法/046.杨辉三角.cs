namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给定一个非负整数 numRows，生成「杨辉三角」的前 numRows 行。
 * 在「杨辉三角」中，每个数是它左上方和右上方的数的和。
 */
public class LeetCode_046
{
    public static void Test()
    {
        LeetCode_046 obj = new LeetCode_046();
        var res = obj.Generate(5);
        Console.WriteLine(res);
    }
    
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> res = new List<IList<int>>(numRows);
        res.Add(new List<int>());
        res[0].Add(1);
        for (int i = 1; i < numRows; i++)
        {
            res.Add(new List<int>(i+1));
            res[i].Add(1);
            for (int j = 1; j < i; j++)
            {
                res[i].Add(res[i-1][j-1] + res[i-1][j]);
            }
            res[i].Add(1);
        }
        return res;
    }
}