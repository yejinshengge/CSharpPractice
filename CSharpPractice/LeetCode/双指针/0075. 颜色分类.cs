namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0075
{
    public static void Test()
    {
        LeetCode_0075 obj = new LeetCode_0075();
    }
    
    public void SortColors(int[] nums) {
        int smallP = -1;
        int bigP = nums.Length;
        int num = 1;
        int index = 0;
        while (index < bigP)
        {
            if (nums[index] > num)
            {
                bigP--;
                (nums[index], nums[bigP]) = (nums[bigP], nums[index]);
            }
            else if (nums[index] < num)
            {
                smallP++;
                (nums[index], nums[smallP]) = (nums[smallP], nums[index]);
                index++;
            }
            else
            {
                index++;
            }
        }
    }
}