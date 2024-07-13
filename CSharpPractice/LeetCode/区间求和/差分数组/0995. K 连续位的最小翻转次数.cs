namespace CSharpPractice.LeetCode.数组篇.前缀和;

public class LeetCode_0995
{
    public static void Test()
    {
        LeetCode_0995 obj = new LeetCode_0995();
        Console.WriteLine(obj.MinKBitFlips(new []{0,1,0},1));
        Console.WriteLine(obj.MinKBitFlips(new []{1,1,0},2));
        Console.WriteLine(obj.MinKBitFlips(new []{0,0,0,1,0,1,1,0},3));
        Console.WriteLine(obj.MinKBitFlips(new []{0,1,1},2));
    }
    
    public int MinKBitFlips(int[] nums, int k)
    {
        int res = 0;
        int[] arr = new int[nums.Length + 1];
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += arr[i];
            if ((nums[i] + sum) % 2 == 0)
            {
                if (i + k > nums.Length)
                    return -1;
                arr[i]++;
                arr[i + k]--;
                res++;
                sum++;
            }
        }
        return res;
    }  
}