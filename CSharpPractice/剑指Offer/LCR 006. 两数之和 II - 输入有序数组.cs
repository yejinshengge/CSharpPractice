using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR006
{
    public static void Test()
    {
        LeetCode_LCR006 obj = new LeetCode_LCR006();
        Tools.PrintArr(obj.TwoSum(new []{1,2,4,6,10},8));
        Tools.PrintArr(obj.TwoSum(new []{2,3,4},6));
        Tools.PrintArr(obj.TwoSum(new []{-1,0},-1));
    }
    
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0, right = numbers.Length-1;
        while (left < right)
        {
            // 如果两数之和大于target，则右指针左移
            if (numbers[left] + numbers[right] > target)
                right--;
            // 如果两数之和小于target，则左指针右移
            else if (numbers[left] + numbers[right] < target)
                left++;
            else
                return new[] { left, right };
        }
        return null;
    }
}