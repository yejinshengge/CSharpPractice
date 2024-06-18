using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_08
{
    public static void Test()
    {
        LeetCode_05_08 obj = new LeetCode_05_08();
        Tools.PrintArr(obj.DrawLine(1,32,30,31,0));
    }
    
    public int[] DrawLine(int length, int w, int x1, int x2, int y)
    {
        int[] res = new int[length];
        int high = (w * y + x1) / 32;
        int low = (w * y + x2) / 32;
        for (int i = high; i <= low; i++)
        {
            res[i] = -1;
        }

        res[high] >>>= x1%32;
        res[low] &= int.MinValue >> x2 % 32;
        return res;
    }
}