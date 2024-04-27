using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0653
{
    public static void Test()
    {
        LeetCode_0653 obj = new LeetCode_0653();
        Console.WriteLine(obj.FindTarget(Tools.ConstructTree("5,3,6,2,4,null,7"),9));
        Console.WriteLine(obj.FindTarget(Tools.ConstructTree("5,3,6,2,4,null,7"),28));
    }
    
    public bool FindTarget(TreeNode root, int k)
    {
        List<int> list = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode curNode = root;
        while (curNode != null || stack.Count > 0)
        {
            if (curNode != null)
            {
                stack.Push(curNode);
                curNode = curNode.left;
            }
            else
            {
                curNode = stack.Pop();
                list.Add(curNode.val);
                curNode = curNode.right;
            }
        }

        int left = 0, right = list.Count-1;
        while (left < right)
        {
            var sum = list[left] + list[right];
            if (sum > k)
                right--;
            else if (sum < k)
                left++;
            else
                return true;
        }

        return false;
    }
}