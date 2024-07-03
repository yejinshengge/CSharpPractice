using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_16_01
{
    public static void Test()
    {
        LeetCode_16_01 obj = new LeetCode_16_01();
        Tools.PrintArr(obj.SwapNumbers(new []{1,2}));
        Tools.PrintArr(obj.SwapNumbers(new []{-2147483647,2147483647}));
    }
    
    public int[] SwapNumbers(int[] numbers)
    {
        numbers[0] ^= numbers[1];
        numbers[1] ^= numbers[0];
        numbers[0] ^= numbers[1];
        return numbers;
    }
}