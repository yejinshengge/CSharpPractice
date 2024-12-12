using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.栈与队列;

public class LeetCode_2931
{
    public static void Test()
    {
        LeetCode_2931 obj = new LeetCode_2931();
        Console.WriteLine(obj.MaxSpending(Tools.ConstructTArray("[[8,5,2],[6,4,1],[9,7,3]]")));
        Console.WriteLine(obj.MaxSpending(Tools.ConstructTArray("[[10,8,6,4,2],[9,7,5,3,2]]")));
        Console.WriteLine(obj.MaxSpending(Tools.ConstructTArray("[[1]]")));
    }
    
    public long MaxSpending(int[][] values)
    {
        Queue<int>[] queues = new Queue<int>[values.Length];
        for (var i = 0; i < values.Length; i++)
        {
            queues[i] = new Queue<int>();
            for (var j = values[i].Length-1; j >= 0; j--)
            {
                queues[i].Enqueue(values[i][j]);
            }
        }

        int day = 1;
        int totalDay = values.Length * values[0].Length;
        long totalCost = 0;
        for (int i = 0; i < totalDay; i++)
        {
            long minValue = int.MaxValue;
            int index = 0;
            for (int j = 0; j < queues.Length; j++)
            {
                if (queues[j].Count > 0 && queues[j].Peek() < minValue)
                {
                    minValue = queues[j].Peek();
                    index = j;
                }
            }

            totalCost += minValue * day;
            queues[index].Dequeue();
            day++;
        }

        return totalCost;
    }
}