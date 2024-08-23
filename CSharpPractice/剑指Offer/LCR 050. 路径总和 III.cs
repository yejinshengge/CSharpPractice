using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR050
{
    public static void Test()
    {
        LeetCode_LCR050 obj = new LeetCode_LCR050();
        Console.WriteLine(obj.PathSum(Tools.ConstructTree("10,5,-3,3,2,null,11,3,-2,null,1"),8));
        Console.WriteLine(obj.PathSum(Tools.ConstructTree("5,4,8,11,null,13,4,7,2,null,null,5,1"),22));
        Console.WriteLine(obj.PathSum(Tools.ConstructTree("1,-2,-3"),-1));
    }
    
    public int PathSum(TreeNode root, int targetSum)
    {
        var dic = new Dictionary<long, int>();
        dic[0] = 1;
        return _doPathSum(dic, root, targetSum, 0);
    }

    private int _doPathSum(Dictionary<long, int> dic, TreeNode node, int target,long prefixSum)
    {
        if (node == null) return 0;
        prefixSum += node.val;
        dic.TryGetValue(prefixSum - target, out int num);
        dic.TryAdd(prefixSum, 0);
        dic[prefixSum]++;
        num += _doPathSum(dic, node.left, target, prefixSum);
        num += _doPathSum(dic, node.right, target, prefixSum);
        dic[prefixSum]--;
        return num;
    }
}