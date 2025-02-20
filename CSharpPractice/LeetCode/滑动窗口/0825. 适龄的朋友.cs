namespace CSharpPractice.LeetCode.二分;

public class LeetCode_0825
{
    public static void Test()
    {
        LeetCode_0825 obj = new LeetCode_0825();
        Console.WriteLine(obj.NumFriendRequests2(new []{16,16}));
        Console.WriteLine(obj.NumFriendRequests2(new []{16,17,18}));
        Console.WriteLine(obj.NumFriendRequests2(new []{20,30,100,110,120}));
    }
    
    public int NumFriendRequests(int[] ages) {
        //Array.Sort(ages);
        var n = ages.Length;
        int total = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(i == j) continue;
                if (ages[i] <= 0.5 * ages[j] + 7 || ages[i] > ages[j] || (ages[i] > 100 && ages[j] < 100))
                    continue;
                total++;
            }
        }

        return total;
    }
    
    
    public int NumFriendRequests2(int[] ages) {
        Array.Sort(ages);
        var n = ages.Length;
        int total = 0;
        // 0.5x+7 < y <= x
        // 窗口一定向右移动
        int left = 0, right = 0;
        for (int i = 0; i < n; i++)
        {
            // 14及以下都不可能满足
            if(ages[i] < 15) continue;
            // 左指针右移到第一个大于0.5x+7的地方
            while (ages[left] <= 0.5 * ages[i] + 7)
            {
                left++;
            }
            // 右指针右移到最后一个小于等于x的地方
            while (right + 1 < n && ages[right+1] <= ages[i] )
            {
                right++;
            }

            total += right - left;
        }

        return total;
    }


}