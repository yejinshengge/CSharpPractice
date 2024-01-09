using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划;

/**
 * 给你一个整数 n ，请你生成并返回所有由 n 个节点组成且节点值从 1 到 n 互不相同的不同 二叉搜索树 。可以按 任意顺序 返回答案。
 */
public class LeetCode_0095
{
    public static void Test()
    {
        LeetCode_0095 obj = new LeetCode_0095();
        var trees = obj.GenerateTrees2(3);
        foreach (var tree in trees)
        {
            Tools.PreorderTree(tree);
            Console.WriteLine();
        }
    }
    
    public IList<TreeNode> GenerateTrees(int n)
    {
        return _doGenerateTrees(1, n);
    }

    private List<TreeNode> _doGenerateTrees(int start,int end)
    {
        List<TreeNode> allTrees = new List<TreeNode>();
        if (start > end)
        {
            allTrees.Add(null);
            return allTrees;
        }

        for (int i = start; i <= end; i++)
        {
            List<TreeNode> leftTrees = _doGenerateTrees(start, i-1);
            List<TreeNode> rightTrees = _doGenerateTrees(i+1, end);

            foreach (var leftTree in leftTrees)
            {
                foreach (var rightTree in rightTrees)
                {
                    TreeNode curNode = new TreeNode(i);
                    curNode.left = leftTree;
                    curNode.right = rightTree;
                    allTrees.Add(curNode);
                }
            }
        }

        return allTrees;
    }

    public IList<TreeNode> GenerateTrees2(int n)
    {
        List<TreeNode>[,] dp = new List<TreeNode>[n+2,n+2];
        //初始状态
        for (int i = 0; i <= n+1; i++)
        {
            for (int j = 0; j <= n+1; j++)
            {
                dp[i, j] = new List<TreeNode>();
                if(j<i)
                    dp[i,j].Add(null);
            }
        }
        
        // 枚举子树长度
        for (int len = 1; len <= n; len++)
        {
            // 枚举起止范围
            for (int start = 1; start <= n-len+1; start++)
            {
                int end = start + len - 1;
                // 枚举根结点
                for (int root = start; root <= end; root++)
                {
                    // 遍历左右子树
                    foreach (var leftTree in dp[start,root-1])
                    {
                        foreach (var rightTree in dp[root+1,end])
                        {
                            TreeNode curNode = new TreeNode(root);
                            curNode.left = leftTree;
                            curNode.right = rightTree;
                            dp[start,end].Add(curNode);
                        }
                    }
                }
            }
        }

        return dp[1, n];
    }
    
}