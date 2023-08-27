using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

/**
给定一个二叉树，我们在树的节点上安装摄像头。

节点上的每个摄影头都可以监视其父对象、自身及其直接子对象。

计算监控树的所有节点所需的最小摄像头数量。
 */
public class LeetCode_0968
{
    public static void Test()
    {
        LeetCode_0968 obj = new LeetCode_0968();
        var tree = Tools.ConstructTree("0,0,null,0,null,0,null,null,0");
        Console.WriteLine(obj.MinCameraCover(tree));
    }

    public int MinCameraCover(TreeNode root)
    {
        res = 0;
        if (DoMinCameraCover(root) == Status.None)
        {
            res++;
        }
        return res;
    }

    private int res = 0;
    private Status DoMinCameraCover(TreeNode root)
    {
        if (root == null) return Status.Cover;
        var leftStatus = DoMinCameraCover(root.left);
        var rightStatus = DoMinCameraCover(root.right);
        // 左右孩子有一个未覆盖
        if (leftStatus == Status.None || rightStatus == Status.None)
        {
            res++;
            return Status.Camera;
        }
        // 左右孩子都被覆盖
        if (leftStatus == Status.Cover && rightStatus == Status.Cover)
            return Status.None;
        // 左右孩子有一个有摄像头
        if (leftStatus == Status.Camera || rightStatus == Status.Camera)
            return Status.Cover;
        return Status.Illegal;
    }

    private enum Status
    {
        Illegal,
        None,
        Cover,
        Camera
    }
}