namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR076
{
    public static void Test()
    {
        LeetCode_LCR076 obj = new LeetCode_LCR076();
        Console.WriteLine(obj.FindKthLargest(new []{3,2,1,5,6,4},2));
        Console.WriteLine(obj.FindKthLargest(new []{3,2,3,1,2,4,5,5,6},4));
    }
    
    public int FindKthLargest(int[] nums, int k)
    {
        int target = nums.Length - k;
        int start = 0, end = nums.Length - 1;
        // 整体进行一次划分
        int index = _partition(nums, start, end);
        while (target!= index)
        {
            // 划多了，在左侧继续划分
            if (target < index)
                end = index-1;
            // 划少了，在右侧继续划分
            else if (target > index)
                start = index+1;
            index =  _partition(nums, start, end);
        }
        return nums[target];
    }

    private int _partition(int[] nums, int left, int right)
    {
        int cur = left;
        int smallP = left - 1;
        int bigP = right;
        // 随机取划分值,放在最右边
        int random = new Random().Next(cur, right);
        (nums[right], nums[random]) = (nums[random], nums[right]);

        while (cur < bigP)
        {
            // 当前元素大于划分值，与大于区前一个元素交换，大于区左移
            if (nums[cur] > nums[right])
            {
                (nums[cur], nums[bigP - 1]) = (nums[bigP - 1], nums[cur]);
                bigP--;
            }
            // 当前元素小于划分值，与小于区后一个元素交换，小于区右移，当前指针后移
            else if (nums[cur] < nums[right])
            {
                (nums[cur], nums[smallP + 1]) = (nums[smallP + 1], nums[cur]);
                smallP++;
                cur++;
            }
            // 当前元素等于划分值，当前指针后移
            else
                cur++;
        }
        // 划分值与大于区第一个元素交换
        (nums[bigP], nums[right]) = (nums[right], nums[bigP]);

        return smallP + 1;
    }
}