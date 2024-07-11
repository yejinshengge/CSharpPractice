using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇.前缀和;

public class LeetCode_1109
{
    public static void Test()
    {
        LeetCode_1109 obj = new LeetCode_1109();
        Tools.PrintArr(obj.CorpFlightBookings(Tools.ConstructTArray("[[1,2,10],[2,3,20],[2,5,25]]"),5));
        Tools.PrintArr(obj.CorpFlightBookings(Tools.ConstructTArray("[[1,2,10],[2,2,15]]"),2));
    }
    
    public int[] CorpFlightBookings1(int[][] bookings, int n)
    {
        int[] res = new int[n];
        foreach (var booking in bookings)
        {
            for (int i = booking[0]; i <= booking[1]; i++)
            {
                res[i-1] += booking[2];
            }
        }

        return res;
    }

    // 差分+前缀和
    public int[] CorpFlightBookings(int[][] bookings, int n)
    {
        int[] c = new int[n+1];
        foreach (var booking in bookings)
        {
            int start = booking[0] - 1, end = booking[1] - 1, val = booking[2];
            c[start] += val;
            c[end + 1] -= val;
        }

        int[] res = new int[n];
        res[0] = c[0];
        for (int i = 1; i < n; i++)
        {
            res[i] = res[i - 1] + c[i];
        }

        return res;
    }
}