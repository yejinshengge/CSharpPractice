namespace CSharpPractice.LeetCode.初级算法;

/**
 * 你是产品经理，目前正在带领一个团队开发新的产品。不幸的是，你的产品的最新版本没有通过质量检测。由于每个版本都是基于之前的版本开发的，所以错误的版本之后的所有版本都是错的。
 * 假设你有 n 个版本 [1, 2, ..., n]，你想找出导致之后所有版本出错的第一个错误的版本。
 * 你可以通过调用bool isBadVersion(version)接口来判断版本号 version 是否在单元测试中出错。实现一个函数来查找第一个错误的版本。你应该尽量减少对调用 API 的次数。
 */
public class LeetCode_033
{
    public static void Test()
    {
        LeetCode_033 obj = new LeetCode_033();
        
        Console.WriteLine(obj.FirstBadVersion(2));
    }

    public int FirstBadVersion(int n)
    {
        int left = 1;
        int right = n;
        
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            var isBadVersion = IsBadVersion(mid);
            if (isBadVersion)
                right = mid;
            else
                left = mid+1;
        }

        return right;
    }

    private int Process(int start, int end)
    {
        int mid = (start + end) >> 1;
        if (start == end) return start;
        var isBadVersion = IsBadVersion(mid);

        return isBadVersion ? Process(start, mid) : Process(mid, end);
    }

    private bool IsBadVersion(int version)
    {
        return version >= 1;
    }
}