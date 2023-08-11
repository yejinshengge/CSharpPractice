using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer032LevelOrder
{
    public static void Offer032LevelOrderMain()
    {
        Offer032LevelOrder obj = new();
        TreeNode root = new(3);
        root.left = new(9);
        root.right = new(20);
        root.right.left = new(15);
        root.right.right = new(7);
        int[] res = obj.LevelOrder(root);
        Console.WriteLine(res);
    }

    public int[] LevelOrder(TreeNode root)
    {
        if (root == null)
            return new int[]{};
        int[] arr = new int[1000];
        int num = 0;
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var treeNode = queue.Dequeue();
            arr[num++] = treeNode.val;
            if(treeNode.left != null)
                queue.Enqueue(treeNode.left);
            if(treeNode.right != null)
                queue.Enqueue(treeNode.right);
        }

        int[] res = new int[num];
        for (int i = 0; i < num; i++)
        {
            res[i] = arr[i];
        }
        return res;
    }
}