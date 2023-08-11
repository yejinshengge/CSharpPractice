using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer026IsSubStructure
{
    public static void Offer026IsSubStructureMain()
    {
        TreeNode node1 = new(3);
        node1.left = new(4);
        node1.left.left = new(1);
        node1.left.right = new(2);
        node1.right = new(5);
        
        TreeNode node2 = new(4);
        node2.left = new(1);

        Offer026IsSubStructure obj = new();
        Console.WriteLine(obj.IsSubStructure(node1,node2));

    }

    public bool IsSubStructure(TreeNode A, TreeNode B)
    {
        bool isSame = false;
        if (A == null || B == null)
            return isSame;
        if(A.val == B.val)
            isSame = IsSameTree(A, B);
        if (!isSame)
            isSame = IsSubStructure(A.left, B);
        if (!isSame)
            isSame = IsSubStructure(A.right, B);
        return isSame;
    }

    public bool IsSameTree(TreeNode A, TreeNode B)
    {
        if (B == null)
            return true;
        if (A == null)
            return false;
        if (A.val != B.val)
            return false;
        return IsSameTree(A.left, B.left)&&IsSameTree(A.right, B.right);
    }
}