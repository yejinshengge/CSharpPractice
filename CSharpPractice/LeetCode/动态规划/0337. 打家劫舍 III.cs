using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
小偷又发现了一个新的可行窃的地区。这个地区只有一个入口，我们称之为 root 。
除了 root 之外，每栋房子有且只有一个“父“房子与之相连。
一番侦察之后，聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。 
如果 两个直接相连的房子在同一天晚上被打劫 ，房屋将自动报警。

给定二叉树的 root 。返回 在不触动警报的情况下 ，小偷能够盗取的最高金额 。
 */
public class LeetCode_0337
{
    public static void Test()
    {
        LeetCode_0337 obj = new LeetCode_0337();
        var tree = Tools.ConstructTree("3,4,5,1,3,null,1");
        Console.WriteLine(obj.Rob(tree));
    }
    
    public int Rob(TreeNode root)
    {
        var res = OnRob(root);
        return Math.Max(res[0], res[1]);
    }

    private int[] OnRob(TreeNode root)
    {
        int[] res = new int[2];
        if (root == null) return res;
        var left = OnRob(root.left);
        var right = OnRob(root.right);
        
        // 偷当前节点
        int stolen = root.val + left[0] + right[0];
        // 不偷当前节点
        int unStolen = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
        res[0] = unStolen;
        res[1] = stolen;
        return res;
    }
}