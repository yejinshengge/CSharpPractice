namespace CSharpPractice.LeetCode.双指针;

public class LeetCode_0016
{
    public static void Test()
    {
        LeetCode_0016 obj = new LeetCode_0016();
        Console.WriteLine(obj.ThreeSumClosest(new []{-1,2,1,-4},1));
        Console.WriteLine(obj.ThreeSumClosest(new []{0,0,0},1));
        Console.WriteLine(obj.ThreeSumClosest(new []{4,0,5,-5,3,3,0,-4,-5},-2));
    }
    
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int diff = int.MaxValue;
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if(i > 0 && nums[i] == nums[i-1]) continue;
            int j = i+1,k = nums.Length - 1;
            while (j < k)
            {
                // 计算差值
                int sum = nums[i] + nums[j] + nums[k];
                if (Math.Abs(sum - target) < diff)
                {
                    diff = Math.Abs(sum - target);
                    res = sum;
                }

                if (sum == target)
                    return sum;
                // k继续左移只会更小,所以j右移
                else if (sum < target)
                    j++;
                else
                    k--;
            }
        }

        return res;
    }
}