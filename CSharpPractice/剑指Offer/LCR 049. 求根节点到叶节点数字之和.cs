using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR049
{
    public static void Test()
    {
        LeetCode_LCR049 obj = new LeetCode_LCR049();
        Console.WriteLine(obj.SumNumbers(Tools.ConstructTree("4,9,0,5,1")));
    }
    
    public int SumNumbers(TreeNode root)
    {
        int res = 0;
        int curNum = 0;
        Stack<TreeNode> stack = new();
        TreeNode cur = root;
        TreeNode pre = null;
        while (cur != null || stack.Count > 0)
        {
            while (cur != null)
            {
                stack.Push(cur);
                curNum = curNum * 10 + cur.val;
                cur = cur.left;
            }
            
            cur = stack.Pop();
            if (cur.left == null && cur.right == null)
                res += curNum;
            if (cur.right != null && cur.right != pre)
            {
                stack.Push(cur);
                cur = cur.right;
            }
            else
            {
                curNum /= 10;
                pre = cur;
                cur = null;
            }
        }

        return res;
    }
}