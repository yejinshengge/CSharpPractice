using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR051
{
    public static void Test()
    {
        LeetCode_LCR051 obj = new LeetCode_LCR051();
        Console.WriteLine(obj.MaxPathSum(Tools.ConstructTree("1,2,3")));
        Console.WriteLine(obj.MaxPathSum(Tools.ConstructTree("-10,9,20,null,null,15,7")));
        Console.WriteLine(obj.MaxPathSum(Tools.ConstructTree("-3")));
    }
    
    public int MaxPathSum(TreeNode root)
    {
        _maxSum = int.MinValue;
        MaxGain(root);
        return _maxSum;
    }

    private int _maxSum = int.MinValue;
    private int MaxGain(TreeNode root)
    {
        if (root == null) return 0;
        int left = Math.Max(MaxGain(root.left), 0);
        int right = Math.Max(MaxGain(root.right), 0);
        // 以当前节点为拐点的最长路径
        _maxSum = Math.Max(_maxSum, left + right + root.val);
        // 以当前节点为根节点的最长路径
        return Math.Max(left, right) + root.val;
    }
}