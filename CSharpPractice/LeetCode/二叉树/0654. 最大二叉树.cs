using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

/**
给定一个不重复的整数数组 nums 。 最大二叉树 可以用下面的算法从 nums 递归地构建:

创建一个根节点，其值为 nums 中的最大值。
递归地在最大值 左边 的 子数组前缀上 构建左子树。
递归地在最大值 右边 的 子数组后缀上 构建右子树。
返回 nums 构建的 最大二叉树 。
 */
public class LeetCode_0654
{
    public static void Test()
    {
        LeetCode_0654 obj = new LeetCode_0654();

        var tree = obj.ConstructMaximumBinaryTree(new[] { 3, 2, 1, 6, 0, 5 });
        
    }

    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        return DoBuild(nums, 0, nums.Length - 1);
    }

    private TreeNode DoBuild(int[] nums, int start, int end)
    {
        if (end < start) return null;
        int max = int.MinValue, index = -1;
        
        for (int i = start; i <= end; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                index = i;
            }
        }

        TreeNode node = new TreeNode(max);
        node.left = DoBuild(nums, start, index - 1);
        node.right = DoBuild(nums, index+1, end);
        return node;
    }
}