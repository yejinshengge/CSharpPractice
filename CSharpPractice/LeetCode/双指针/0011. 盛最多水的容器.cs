namespace CSharpPractice.LeetCode.双指针;

/**
 * 给定一个长度为 n 的整数数组 height 。有 n 条垂线，第 i 条线的两个端点是 (i, 0) 和 (i, height[i]) 。

    找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

    返回容器可以储存的最大水量。

    说明：你不能倾斜容器。
 */
public class LeetCode_0011
{
    public static void Test()
    {
        LeetCode_0011 obj = new LeetCode_0011();
        Console.WriteLine(obj.MaxArea(new []{1,8,6,2,5,4,8,3,7}));
        Console.WriteLine(obj.MaxArea(new []{1,1}));
    }
    
    public int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1,maxS = 0;
        while (left < right)
        {
            maxS = height[left] < height[right]
                ? Math.Max(maxS, (right - left) * height[left++])
                : Math.Max(maxS, (right - left) * height[right--]);
        }

        return maxS;
    }
}