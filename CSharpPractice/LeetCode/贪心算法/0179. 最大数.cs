using System.Text;

namespace CSharpPractice.LeetCode.贪心算法;

public class LeetCode_0179
{
    public static void Test()
    {
        LeetCode_0179 obj = new LeetCode_0179();
        Console.WriteLine(obj.LargestNumber(new []{10,2}));
        Console.WriteLine(obj.LargestNumber(new []{3,30,34,5,9}));
        Console.WriteLine(obj.LargestNumber(new []{0}));
    }
    
    public string LargestNumber(int[] nums)
    {
        string[] strs = new string[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            strs[i] = nums[i] + "";
        }
        Array.Sort(strs, (a, b) 
            => String.Compare(b + a, a+b, StringComparison.Ordinal));
        StringBuilder res = new StringBuilder();
        foreach (var str in strs)
        {
            res.Append(str);
        }

        int zeroIndex = 0;
        while (zeroIndex < res.Length-1 && res[zeroIndex] == '0')
        {
            zeroIndex++;
        }

        return res.ToString(zeroIndex, res.Length - zeroIndex);
    }
}