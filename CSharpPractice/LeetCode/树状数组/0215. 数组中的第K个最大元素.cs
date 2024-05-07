namespace CSharpPractice.LeetCode.树状数组;

public class LeetCode_0215
{
    public static void Test()
    {
        LeetCode_0215 obj = new LeetCode_0215();
        //Console.WriteLine(obj.FindKthLargest(new []{3,2,1,5,6,4},2));
        Console.WriteLine(obj.FindKthLargest(new []{3,2,3,1,2,4,5,5,6},4));
    }
    
    public int FindKthLargest(int[] nums, int k) {
        foreach (var num in nums)
        {
            _add(num+MAX_LEN);
        }

        int left = 0, right = _arr.Length-1;
        while (left < right)
        {
            int mid = left + right + 1 >> 1;
            if (_query(_arr.Length-1) - _query(mid-1) >= k)
                left = mid;
            else
                right = mid - 1;
        }

        return right - MAX_LEN;
    }

    private const int MAX_LEN = 10010;
    private int[] _arr = new int[MAX_LEN * 2];

    private int _lowbit(int x)
    {
        return x & -x;
    }

    private void _add(int x)
    {
        for (int i = x; i < _arr.Length; i+=_lowbit(i))
        {
            _arr[i]++;
        }
    }

    private int _query(int n)
    {
        int res = 0;
        for (int i = n; i > 0; i-=_lowbit(i))
        {
            res += _arr[i];
        }

        return res;
    }
}