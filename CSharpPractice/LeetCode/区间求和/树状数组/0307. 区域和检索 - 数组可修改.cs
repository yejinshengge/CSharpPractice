namespace CSharpPractice.LeetCode.树状数组;

public class LeetCode_0307
{
    public static void Test()
    {
        NumArray arr = new NumArray(new []{1,3,5});
        Console.WriteLine(arr.SumRange(0,2));
        arr.Update(1,2);
        Console.WriteLine(arr.SumRange(0,2));
    }
}

public class NumArray
{
    private int[] _arr;
    private int[] _nums;
    public NumArray(int[] nums)
    {
        _arr = new int[nums.Length+1];
        for (int i = 0; i < nums.Length; i++)
        {
            _add(i+1,nums[i]);
        }
        _nums = nums;
    }
    
    public void Update(int index, int val) {
        _add(index+1,val - _nums[index]);
        _nums[index] = val;
    }
    
    public int SumRange(int left, int right)
    {
        return _query(right+1) - _query(left);
    }

    private int _lowbit(int x)
    {
        return x & -x;
    }

    private int _query(int n)
    {
        int res = 0;
        for (int i = n; i > 0; i-= _lowbit(i))
        {
            res += _arr[i];
        }

        return res;
    }

    private void _add(int n, int val)
    {
        for (int i = n; i < _arr.Length; i+=_lowbit(i))
        {
            _arr[i] += val;
        }
    }
}