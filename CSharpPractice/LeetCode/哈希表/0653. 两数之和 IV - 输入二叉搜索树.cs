using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.哈希表篇;

public class LeetCode_0635
{
    public static void Test()
    {
        LeetCode_0635 obj = new LeetCode_0635();
        Console.WriteLine(obj.FindTarget(Tools.ConstructTree("5,3,6,2,4,null,7"),9));
        Console.WriteLine(obj.FindTarget(Tools.ConstructTree("5,3,6,2,4,null,7"),28));
    }

    private HashSet<int> _set = new HashSet<int>();
    public bool FindTarget(TreeNode root, int k)
    {
        if (root == null) return false;
        if (_set.Contains(k - root.val))
            return true;
        _set.Add(root.val);
        return FindTarget(root.left, k) || FindTarget(root.right, k);
    }
}