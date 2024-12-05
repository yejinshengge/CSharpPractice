using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_LCR115
{
    public static void Test()
    {
        LeetCode_LCR115 obj = new LeetCode_LCR115();
        // Console.WriteLine(obj.SequenceReconstruction(new []{1,2,3},Tools.ConstructTArray("[[1,2],[1,3]]")));
        // Console.WriteLine(obj.SequenceReconstruction(new []{1,2,3},Tools.ConstructTArray("[[1,2]]")));
        // Console.WriteLine(obj.SequenceReconstruction(new []{1,2,3},Tools.ConstructTArray("[[1,2],[1,3],[2,3]]")));
        // Console.WriteLine(obj.SequenceReconstruction(new []{4,1,5,2,6,3},Tools.ConstructTArray("[[5,2,6,3],[4,1,5,2]]")));
        Console.WriteLine(obj.SequenceReconstruction(new []{1},Tools.ConstructTArray("[[1]]")));
    }
    
    public bool SequenceReconstruction(int[] nums, int[][] sequences)
    {
        Dictionary<int, HashSet<int>> graph = new();
        Dictionary<int, int> inDegree = new();
        
        foreach (var sequence in sequences)
        {
            foreach (var num in sequence)
            {
                graph.TryAdd(num, new HashSet<int>());
                inDegree.TryAdd(num, 0);
            }

            for (var i = 0; i < sequence.Length-1; i++)
            {
                int from = sequence[i];
                int to = sequence[i+1];
                if (!graph[from].Contains(to))
                {
                    graph[from].Add(to);
                    inDegree[to]++;
                }
            }
        }

        List<int> topology = new();
        Queue<int> queue = new();
        foreach (var (key, value) in inDegree)
        {
            if(value == 0)
                queue.Enqueue(key);
        }

        if (queue.Count > 1) return false;

        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            topology.Add(cur);
            int count = 0;
            foreach (var next in graph[cur])
            {
                inDegree[next]--;
                if (inDegree[next] == 0)
                {
                    queue.Enqueue(next);
                    count++;
                }
            }

            if (count > 1) return false;
        }

        return nums.Length == topology.Count;
    }
}