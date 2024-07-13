namespace CSharpPractice.LeetCode.数组篇.前缀和;

public class LeetCode_0798
{
    public static void Test()
    {
        LeetCode_0798 obj = new LeetCode_0798();
        Console.WriteLine(obj.BestRotation(new []{2,3,1,4,0}));
        Console.WriteLine(obj.BestRotation(new []{1,3,0,2,4}));
    }
    
    public int BestRotation(int[] nums)
    {
        var n = nums.Length;
        int[] arr = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            int left = (i - n + 1 + n) % n;
            int right = (i - nums[i] + n) % n;
            if (left <= right)
            {
                arr[left]++;
                arr[right + 1]--;
            }
            else
            {
                arr[0]++;
                arr[right + 1]--;
                arr[left]++;
                arr[n]--;
            }
        }

        for (int i = 1; i <= n; i++)
            arr[i] += arr[i - 1];
        int index = 0;
        for (int i = 1; i <= n; i++)
        {
            if (arr[i] > arr[index])
                index = i;
        }

        return index;
    }
}