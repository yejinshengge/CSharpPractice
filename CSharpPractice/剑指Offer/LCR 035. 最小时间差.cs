namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR035
{
    public static void Test()
    {
        LeetCode_LCR035 obj = new LeetCode_LCR035();
        Console.WriteLine(obj.FindMinDifference(new List<string>(){"23:59","00:00"}));
        Console.WriteLine(obj.FindMinDifference(new List<string>(){"00:00","23:59","00:00"}));
        Console.WriteLine(obj.FindMinDifference(new List<string>(){"12:30","23:59","00:00"}));
    }
    
    public int FindMinDifference1(IList<string> timePoints)
    {
        int[] arr = new int[timePoints.Count];
        for (int i = 0; i < timePoints.Count; i++)
        {
            var timePoint = timePoints[i];
            var nums = timePoint.Split(":");
            arr[i] = int.Parse(nums[0]) * 60 + int.Parse(nums[1]);
        }
        Array.Sort(arr);
        int min = int.MaxValue;
        for (int i = 1; i < arr.Length; i++)
        {
            min = Math.Min(arr[i] - arr[i - 1], min);
        }
        min = Math.Min(1440 - arr[^1] + arr[0], min);
        return min;
    }
    
    public int FindMinDifference(IList<string> timePoints)
    {
        bool[] arr = new bool[1440];
        for (int i = 0; i < timePoints.Count; i++)
        {
            var timePoint = timePoints[i];
            var nums = timePoint.Split(":");
            var target = int.Parse(nums[0]) * 60 + int.Parse(nums[1]);
            if (arr[target])
                return 0;
            arr[target] = true;
        }
        int min = int.MaxValue;
        int cur = -1, pre = -1, first = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (first == -1 && arr[i])
                first = i;
            if (pre == -1 && arr[i])
                pre = i;
            else if(arr[i])
            {
                cur = i;
                min = Math.Min(min, cur - pre);
                pre = i;
            }
        }
        min = Math.Min(1440 - cur + first, min);
        return min;
    }
}