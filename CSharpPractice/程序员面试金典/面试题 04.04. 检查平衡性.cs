using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_04
{
    public static void Test()
    {
        LeetCode_04_04 obj = new LeetCode_04_04();
    }
    
    public bool IsBalanced(TreeNode root)
    {
        if (root == null) return true;
        return _calHeight(root) >= 0;
    }

    private int _calHeight(TreeNode root)
    {
        if (root == null) return 0;
        var leftH = _calHeight(root.left);
        var rightH = _calHeight(root.right);

        if (leftH == -1 || rightH == -1 || Math.Abs(leftH - rightH) > 1)
            return -1;
        return Math.Max(leftH, rightH) + 1;
    }
}