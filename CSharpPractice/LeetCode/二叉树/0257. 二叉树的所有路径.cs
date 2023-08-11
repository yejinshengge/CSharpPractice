using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

//给你一个二叉树的根节点 root ，按 任意顺序 ，返回所有从根节点到叶子节点的路径。
public class LeetCode_0257
{
    public static void Test()
    {
        LeetCode_0257 obj = new LeetCode_0257();
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.left.left = new TreeNode(15);
        root.left.right = new TreeNode(7);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(7);
        Util.Tools.PrintEnumerator(obj.BinaryTreePaths(root));
    }

    public IList<string> BinaryTreePaths(TreeNode root)
    {
        List<string> res = new List<string>();
        List<int> path = new List<int>();
        if (root == null) return res;
        GetPath(root,path,res);
        return res;
    }
    
    private void GetPath(TreeNode root, List<int> path,List<string> res)
    {
        path.Add(root.val);
        // 如果当前是叶子节点
        if (root.left == null && root.right == null)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < path.Count-1; i++)
            {
                builder.Append(path[i]);
                builder.Append("->");
            }

            builder.Append(path[^1]);
            res.Add(builder.ToString());
            return;
        }
        // 非叶子节点
        if (root.left != null)
        {
            GetPath(root.left, path, res);
            path.RemoveAt(path.Count-1);
        }

        if (root.right != null)
        {
            GetPath(root.right, path, res);
            path.RemoveAt(path.Count-1);
        }
    }
}