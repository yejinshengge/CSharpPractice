using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给你一个整数数组 nums ，其中元素已经按 升序 排列，请你将其转换为一棵 高度平衡 二叉搜索树。
 * 高度平衡 二叉树是一棵满足「每个节点的左右两个子树的高度差的绝对值不超过 1 」的二叉树。
 */
public class LeetCode_031
{
    public static void Test()
    {
        LeetCode_031 obj = new LeetCode_031();

        var head = obj.SortedArrayToBST(new[] {1,3});
        Console.WriteLine(head);
    }
    
    // 因为是升序,所以每次将数组分成两份,取中间即可
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Process(nums, 0, nums.Length - 1);
    }

    private TreeNode Process(int[] nums,int left,int right)
    {
        if (left > right) return null;
        
        int mid = (left + right) >> 1;
        var root = new TreeNode(nums[mid]);
        root.left = Process(nums, left, mid - 1);
        root.right = Process(nums, mid + 1, right);
        return root;
    }
    
}