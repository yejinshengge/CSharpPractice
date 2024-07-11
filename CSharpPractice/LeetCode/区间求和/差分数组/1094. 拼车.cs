using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.前缀和;

public class LeetCode_1094
{
    public static void Test()
    {
        LeetCode_1094 obj = new LeetCode_1094();
        //Console.WriteLine(obj.CarPooling(Tools.ConstructTArray("[[2,1,5],[3,3,7]]"),4));
        Console.WriteLine(obj.CarPooling(Tools.ConstructTArray("[[2,1,5],[3,5,7]]"),3));
    }
    
    public bool CarPooling(int[][] trips, int capacity)
    {
        int[] c = new int[1010];
        foreach (var trip in trips)
        {
            int start = trip[1], end = trip[2], num = trip[0];
            c[start+1] += num;
            c[end+1] -= num;
        }

        for (int i = 1; i <= 1000; i++)
        {
            c[i] += c[i - 1];
            if (c[i] > capacity)
                return false;
        }

        return true;
    }
}