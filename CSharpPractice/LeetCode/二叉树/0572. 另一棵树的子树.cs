using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0572
{
    public static void Test()
    {
        LeetCode_0572 obj = new LeetCode_0572();
        TreeNode root1 = new TreeNode(3);
        // root1.left = new TreeNode(9);
        // root1.right = new TreeNode(20);
        // root1.right.left = new TreeNode(15);
        // root1.right.right = new TreeNode(7);
        
        TreeNode root2 = new TreeNode(3);
        // root2.left = new TreeNode(9);
        // root2.right = new TreeNode(20);
        //root2.right.left = new TreeNode(15);
        //root2.right.right = new TreeNode(7);
        
        Console.WriteLine(obj.IsSubtree(root1,root2));
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        List<int> res1 = new List<int>();
        List<int> res2 = new List<int>();
        Preorder(res1,root);
        Preorder(res2,subRoot);
        return Kmp(res1, res2);
    }

    private void Preorder(List<int> res, TreeNode root)
    {
        if (root == null)
        {
            res.Add(-10001);
            return;
        }
        res.Add(root.val);
        Preorder(res,root.left);
        Preorder(res,root.right);
    }

    private bool Kmp(List<int> arr1, List<int> arr2)
    {
        if (arr2.Count > arr1.Count) return false;
        if (arr2.Count == 1) return arr1.Contains(arr2[0]);
        
        int[] next = new int[arr2.Count];
        next[0] = -1;
        next[1] = 0;

        int left = 0, right = 1;
        while (right < next.Length)
        {
            if (arr2[left] == arr2[right])
            {
                left++;
                right++;
                next[right] = left;
            }
            else if (left > 0)
            {
                left = next[left];
            }
            else
            {
                right++;
            }
        }

        left = 0;
        right = 0;
        while (left < arr1.Count && right < arr2.Count)
        {
            if (arr1[left] == arr2[right])
            {
                left++;
                right++;
            }
            else if (right > 0)
            {
                right = next[right];
            }
            else
            {
                left++;
            }
        }

        return right == arr2.Count;
    }
}