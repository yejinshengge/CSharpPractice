namespace CSharpPractice.LeetCode.贪心算法;
/**
在一条环路上有 n 个加油站，其中第 i 个加油站有汽油 gas[i] 升。

你有一辆油箱容量无限的的汽车，从第 i 个加油站开往第 i+1 个加油站需要消耗汽油 cost[i] 升。你从其中的一个加油站出发，开始时油箱为空。

给定两个整数数组 gas 和 cost ，如果你可以按顺序绕环路行驶一周，则返回出发时加油站的编号，否则返回 -1 。如果存在解，则 保证 它是 唯一 的。
 */
public class LeetCode_0134
{
    public static void Test()
    {
        LeetCode_0134 obj = new LeetCode_0134();
        Console.WriteLine(obj.CanCompleteCircuit(new []{1,2,3,4,5},new []{3,4,5,1,2}));
        Console.WriteLine(obj.CanCompleteCircuit(new []{2,3,4},new []{3,4,3}));
    }
    
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int curSum = 0;
        int totalSum = 0;
        int index = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            curSum += gas[i] - cost[i];
            totalSum += gas[i] - cost[i];
            if (curSum < 0)
            {
                curSum = 0;
                index = i + 1;
            }
        }

        if (totalSum < 0) return -1;
        return index;
    }
}