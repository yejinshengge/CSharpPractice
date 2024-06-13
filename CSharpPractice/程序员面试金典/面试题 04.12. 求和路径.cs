using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_12
{
    public static void Test()
    {
        LeetCode_04_12 obj = new LeetCode_04_12();
        //Console.WriteLine(obj.PathSum(Tools.ConstructTree("5,4,8,11,null,13,4,7,2,null,null,5,1"),22));
        Console.WriteLine(obj.PathSum(Tools.ConstructTree("1,2"),2));
    }

    #region 嵌套递归
    public int PathSum(TreeNode root, int sum)
    {
        if (root == null)
            return 0;
        _dfs(root,sum);
        PathSum(root.left, sum);
        PathSum(root.right, sum);
        return _num;
    }

    private int _num = 0;
    private void _dfs(TreeNode root,int num)
    {
        if(root == null) return;
        num -= root.val;
        if (num == 0) // 可能有负值,所以继续递归
            _num++;
        _dfs(root.left,num);
        _dfs(root.right,num);
    }
    #endregion
    
    private Dictionary<int, int> _prefixNum = new();
    public int PathSum1(TreeNode root, int sum)
    {
        _prefixNum[0] = 1;
        return _dfs(root, 0, sum);
    }

    private int _dfs(TreeNode root,int curNum,int target)
    {
        if (root == null) return 0;
        int res = 0;
        curNum += root.val;
        _prefixNum.TryGetValue(curNum - target,out var val);
        res += val;
        _prefixNum.TryAdd(curNum, 0);
        _prefixNum[curNum] ++;
        res += _dfs(root.left, curNum, target);
        res += _dfs(root.right, curNum, target);
        _prefixNum[curNum]--;
        return res;
    }
}