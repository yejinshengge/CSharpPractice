using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
 * 给定一个整数数组 nums，将数组中的元素向右轮转 k 个位置，其中 k 是非负数。
 */
public class LeetCode_003
{
    public static void LeetCode_003Main()
    {
        LeetCode_003 obj = new LeetCode_003();

        for (int i = 1; i < 1000; i++)
        {
            int k = new Random().Next(1, i);
            var randomArr1 = Util.Tools.RandomArr(i, 0, 1000);
            var randomArr2 = new int[i];
            var randomArr3 = new int[i];
            Array.Copy(randomArr1,randomArr2,i);
            Array.Copy(randomArr1,randomArr3,i);
            obj.Rotate1(randomArr1,k);
            obj.Rotate3(randomArr2,k);

            if (!Util.Tools.Equals(randomArr1, randomArr2))
            {
                Console.WriteLine($"第{i}次结果与预期不一致！");
                Util.Tools.PrintArr(randomArr3);
                Util.Tools.PrintArr(randomArr2);
                break;
            }
        }
    }
    // 思路一:单指针+额外数组。
    public void Rotate1(int[] nums, int k)
    {
        int[] arr = new int[nums.Length];
        int index = nums.Length - k%nums.Length;

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = nums[index % nums.Length];
            index++;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = arr[i];
        }
    }

    // 思路二:环形旋转,从第一个元素最终的位置开始推算,逐步计算每个元素的最终位置
    public void Rotate2(int[] nums, int k)
    {
        int hold = nums[0];
        int index = 0;
        int length = nums.Length;
        bool[] visited = new bool[length];

        for (int i = 0; i < length; i++)
        {
            index = (index + k) % length;
            // 如果没访问过
            if (!visited[index])
            {
                (nums[index], hold) = (hold, nums[index]);
                visited[index] = true;
            }
            // 访问过,直接从下一个元素开始
            else
            {
                index = (index + 1) % length;
                hold = nums[index];
                i--;
            }
        }
    }

    // 思路三:分多次反转,先整体反转,再反转前k个,再反转后面的
    public void Rotate3(int[] nums, int k)
    {
        k %= nums.Length;
        Array.Reverse(nums);
        Array.Reverse(nums,0,k);
        Array.Reverse(nums,k,nums.Length-k);
    }
    

}