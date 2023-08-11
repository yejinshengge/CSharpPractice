using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.栈与队列;

/**
给你一个整数数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。
你只可以看到在滑动窗口内的 k 个数字。滑动窗口每次只向右移动一位。
返回 滑动窗口中的最大值 。
 */
public class LeetCode_0239
{
    public static void Test()
    {
        LeetCode_0239 obj = new LeetCode_0239();
        Util.Tools.PrintArr(obj.MaxSlidingWindow(new []{1,3,-1,-3,5,3,6,7},3));
        Util.Tools.PrintArr(obj.MaxSlidingWindow(new []{1},1));
    }

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        MonotonicQueue queue = new MonotonicQueue();
        int[] res = new int[nums.Length - k+1];
        for (int i = 0; i < k; i++)
        {
            queue.Push(nums[i]);
        }

        res[0] = queue.GetMax();
        int left = 1, right = k;
        while (right < nums.Length)
        {
            queue.Pop(nums[left-1]);
            queue.Push(nums[right]);
            res[left] = queue.GetMax();
            left++;
            right++;
        }

        return res;
    }
}

public class MonotonicQueue
{
    private LinkedList<int> _linkedList;

    public MonotonicQueue()
    {
        _linkedList = new LinkedList<int>();
    }
    
    public void Pop(int val)
    {
        if (_linkedList.Count > 0 && _linkedList.First.Value == val)
            _linkedList.RemoveFirst();
    }

    public void Push(int val)
    {
        while (_linkedList.Count>0&&_linkedList.Last.Value < val)
        {
            _linkedList.RemoveLast();
        }
        _linkedList.AddLast(val);
    }

    public int GetMax()
    {
        return _linkedList.First.Value;
    }
}