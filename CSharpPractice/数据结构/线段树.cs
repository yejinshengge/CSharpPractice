namespace CSharpPractice.数据结构;

public class SegmentTree
{
    private int[] _tree;
    private int n;
    
    public SegmentTree(int[] nums)
    {
        n = nums.Length;
        _tree = new int[4 * n];
        _buildTree(nums,0,0,n-1);
    }
    
    private void _buildTree(int[] arr,int index,int left,int right)
    {
        if (left == right)
        {
            _tree[index] = arr[left];
            return;
        }
    
        int mid = left + right >> 1;
        // 左孩子
        _buildTree(arr,index * 2+1,left,mid);
        // 右孩子
        _buildTree(arr,index * 2+2,mid+1,right);
        _tree[index] = _tree[index * 2 + 1] + _tree[index * 2 + 2];
    }
    
    public int Query(int left, int right)
    {
        return _query(0, 0, n - 1, left, right);
    }
    
    private int _query(int index, int curLeft, int curRight, int targetLeft, int targetRight)
    {
        //超出了查询范围
        if (targetLeft > curRight || targetRight < curLeft)
            return 0;
        //区间恰好在查询范围内
        if (curLeft >= targetLeft && curRight <= targetRight)
            return _tree[index];
        int mid = curLeft + curRight >> 1;
        // 查询左右孩子
        return _query(index * 2 + 1, curLeft, mid, targetLeft, targetRight) +
               _query(index * 2 + 2, mid + 1, curRight, targetLeft, targetRight);
    }
    
    public void Update(int index, int val)
    {
        _update(0,0,n-1,index,val);
    }
    
    private void _update(int index, int curLeft, int curRight, int targetIndex, int targetVal)
    {
        if (curLeft == curRight)
        {
            _tree[index] = targetVal;
            return;
        }
    
        int mid = curLeft + curRight >> 1;
        // 修改点在左侧
        if(targetIndex <= mid)
            _update(2*index+1,curLeft,mid,targetIndex,targetVal);
        // 修改点在右侧
        else
            _update(2*index+2,mid+1,curRight,targetIndex,targetVal);
        _tree[index] = _tree[2 * index + 1] + _tree[2 * index + 2];
    }
    
    public static void Test()
    {
        SegmentTree st = new SegmentTree(new int[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("Test Query Whole Range: " + (st.Query(0, 4)));
        Console.WriteLine("Test Query Partial Range: " + (st.Query(1, 3)));
        
        SegmentTree st2 = new SegmentTree(new int[] { 1, 2, 3, 4, 5 });
        st2.Update(2, 10);
        Console.WriteLine("Test Single Update: " + (st2.Query(0, 4)));//1,2,10,4,5
        st2.Update(1, 7);
        st2.Update(4, 6);
        Console.WriteLine("Test Consecutive Updates: " + (st2.Query(0, 4)));// 1,7,10,4,6
        
        SegmentTree stSingle = new SegmentTree(new int[] { 10 });
        Console.WriteLine("Test Single Element: " + (stSingle.Query(0, 0) == 10));
        stSingle.Update(0, 15);
        Console.WriteLine("Test Update Single Element: " + (stSingle.Query(0, 0) == 15));
    }
}