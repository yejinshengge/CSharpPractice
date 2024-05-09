using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.线段树;

public class LeetCode_0239
{
    public static void Test()
    {
        LeetCode_0239 obj = new LeetCode_0239();
        Tools.PrintArr(obj.MaxSlidingWindow(new []{1,3,-1,-3,5,3,6,7},3));
        Tools.PrintArr(obj.MaxSlidingWindow(new []{1},1));
    }
    
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int[] res = new int[nums.Length - k + 1];
        _newSegmentTree(nums);
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = _query(0, 0, n - 1, i, i + k-1);
        }

        return res;
    }

    private int[] _tree;
    private int n;
    private void _newSegmentTree(int[] nums)
    {
        n = nums.Length;
        _tree = new int[n * 4];
        _buildTree(nums,0,0,n-1);
    }

    private void _buildTree(int[] nums,int index,int left,int right)
    {
        if (left == right)
        {
            _tree[index] = nums[left];
            return;
        }

        int mid = left + right >> 1;
        _buildTree(nums,index*2+1,left,mid);
        _buildTree(nums,index*2+2,mid+1,right);
        _tree[index] = Math.Max(_tree[index * 2 + 1] , _tree[index * 2 + 2]);
    }

    private int _query(int index, int curLeft, int curRight, int targetLeft, int targetRight)
    {
        if (targetLeft > curRight || targetRight < curLeft)
            return int.MinValue;
        if (curLeft >= targetLeft && curRight <= targetRight)
            return _tree[index];
        int mid = curLeft + curRight >> 1;
        return Math.Max(_query(index * 2 + 1, curLeft, mid, targetLeft, targetRight),
            _query(index * 2 + 2, mid + 1, curRight, targetLeft, targetRight));
    }
}