namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 给你一个数组 target ，包含若干 互不相同 的整数，以及另一个整数数组 arr ，arr 可能 包含重复元素。

每一次操作中，你可以在 arr 的任意位置插入任一整数。比方说，如果 arr = [1,4,1,2] ，那么你可以在中间添加 3 得到 [1,4,3,1,2] 。你可以在数组最开始或最后面添加整数。

请你返回 最少 操作次数，使得 target 成为 arr 的一个子序列。

一个数组的 子序列 指的是删除原数组的某些元素（可能一个元素都不删除），同时不改变其余元素的相对顺序得到的数组。比方说，[2,7,4] 是 [4,2,3,7,2,1,4] 的子序列（加粗元素），但 [2,4,2] 不是子序列。
 */
public class LeetCode_1713
{
    public static void Test()
    {
        LeetCode_1713 obj = new LeetCode_1713();
        Console.WriteLine(obj.MinOperations(new []{5,1,3},new []{9,4,2,3,4}));
        Console.WriteLine(obj.MinOperations(new []{6,4,8,1,3,2},new []{4,7,6,2,3,8,6,1}));
    }
    
    public int MinOperations(int[] target, int[] arr)
    {
        // 记录target元素对应下标
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < target.Length; i++)
        {
            dic[target[i]] = i;
        }
        // 找出arr中元素对应target的下标
        List<int> subList = new List<int>();
        foreach (var num in arr)
        {
            if(dic.TryGetValue(num, out var value)) 
                subList.Add(value);
        }
        // 计算最长上升子序列长度
        int piles = 0;
        int[] top = new int[subList.Count];

        for (int i = 0; i < subList.Count; i++)
        {
            int curNum = subList[i];
            int left = 0;
            int right = piles;
            while (left < right)
            {
                int mid = (left + right) >> 1;
                // 找到第一个堆顶比自己大的堆
                if (top[mid] >= curNum)
                    right = mid;
                else
                    left = mid + 1;
            }

            if (left == piles) piles++;
            top[left] = curNum;
        }

        return target.Length - piles;
    }
}