namespace CSharpPractice.LeetCode.初级算法;

/**
 * 两个整数之间的 汉明距离 指的是这两个数字对应二进制位不同的位置的数目。
 * 给你两个整数 x 和 y，计算并返回它们之间的汉明距离。
 */
public class LeetCode_044
{
    public static void Test()
    {
        LeetCode_044 obj = new LeetCode_044();
        Console.WriteLine(obj.HammingDistance(0,0));
    }

    public int HammingDistance(int x, int y)
    {
        int res = x ^ y;
        int num = 0;
        while (res != 0)
        {
            if ((res & 1) == 1) num++;
            res >>= 1;
        }

        return num;
    }
}