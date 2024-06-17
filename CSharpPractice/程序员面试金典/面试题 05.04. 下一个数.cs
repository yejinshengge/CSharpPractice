namespace CSharpPractice.程序员面试金典;

public class LeetCode_05_04
{
    public static void Test()
    {
        LeetCode_05_04 obj = new LeetCode_05_04();
    }
    
    public int[] FindClosedNumbers(int num)
    {
        if (num == 1) return new[] { 2, -1 };
        if (num == int.MaxValue) return new[] { -1, -1 };
        int[] res = new int[2];
        res[0] = _getBigger(num);
        res[1] = _getSmaller(num);
        return res;
    }

    private int _getBigger(int num)
    {
        int lowBit = num & -num;
        int change = num + lowBit;
        return (((num ^ change) / lowBit) >> 2) | change;
    }

    private int _getSmaller(int num)
    {
        int lowBit = ~num & -~num;
        int change = ~num + lowBit;
        return (((~num ^ change) / lowBit) >> 2) ^ ~change;
    }
}