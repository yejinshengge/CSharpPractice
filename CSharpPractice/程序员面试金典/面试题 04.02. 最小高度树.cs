using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_02
{
    public static void Test()
    {
        LeetCode_04_02 obj = new LeetCode_04_02();
        Tools.SequenceTraversalTree(obj.SortedArrayToBST(new []{-10,-3,0,5,9}));
    }
    
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return ConstructTree(nums, 0, nums.Length - 1);
    }

    private TreeNode ConstructTree(int[] nums,int left,int right)
    {
        if (left > right) return null;
        if (left == right)
        {
            return new TreeNode(nums[left]);
        }

        int mid = (left + right) / 2;
        TreeNode root = new TreeNode(nums[mid]);
        root.left = ConstructTree(nums, left, mid-1);
        root.right = ConstructTree(nums, mid+1, right);
        return root;
    }
}