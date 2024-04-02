namespace CSharpPractice.LeetCode.动态规划.序列动态规划;

/**
 * 你打算利用空闲时间来做兼职工作赚些零花钱。

这里有 n 份兼职工作，每份工作预计从 startTime[i] 开始到 endTime[i] 结束，报酬为 profit[i]。

给你一份兼职工作表，包含开始时间 startTime，结束时间 endTime 和预计报酬 profit 三个数组，请你计算并返回可以获得的最大报酬。

注意，时间上出现重叠的 2 份工作不能同时进行。

如果你选择的工作在时间 X 结束，那么你可以立刻进行在时间 X 开始的下一份工作。
 */
public class LeetCode_1235
{
    public static void Test()
    {
        LeetCode_1235 obj = new LeetCode_1235();
        Console.WriteLine(obj.JobScheduling(new []{1,2,3,3},new []{3,4,5,6},new []{50,10,40,70}));
        Console.WriteLine(obj.JobScheduling(new []{1,2,3,4,6},new []{3,5,10,6,9},new []{20,20,100,70,60}));
        Console.WriteLine(obj.JobScheduling(new []{1,1,1},new []{2,3,4},new []{5,6,4}));
    }
    
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        JobData[] jobs = new JobData[startTime.Length];
        for (int i = 0; i < startTime.Length; i++)
        {
            jobs[i].startTime = startTime[i];
            jobs[i].endTime = endTime[i];
            jobs[i].profit = profit[i];
        }
        Array.Sort(jobs, (a, b) => a.endTime - b.endTime);
        int[] dp = new int[jobs.Length+1];

        for (int i = 1; i <= jobs.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1],jobs[i-1].profit);
            int left = 0, right = i - 1;
            while (left < right)
            {
                int mid = (left + right+1) >> 1;
                if (jobs[mid].endTime <= jobs[i - 1].startTime)
                    left = mid;
                else
                    right = mid - 1;
            }

            if (jobs[left].endTime <= jobs[i - 1].startTime)
                dp[i] = Math.Max(dp[left + 1] + jobs[i-1].profit, dp[i]);
        }

        return dp[jobs.Length];
    }

    private struct JobData
    {
        public int startTime;
        public int endTime;
        public int profit;
    }
    
}