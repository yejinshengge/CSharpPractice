using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR113
{
    public static void Test()
    {
        LeetCode_LCR113 obj = new LeetCode_LCR113();
        Tools.PrintArr(obj.FindOrder(2,Tools.ConstructTArray("[[1,0]]")));
        Tools.PrintArr(obj.FindOrder(4,Tools.ConstructTArray("[[1,0],[2,0],[3,1],[3,2]]")));
        Tools.PrintArr(obj.FindOrder(1,Tools.ConstructTArray("[]")));
        Tools.PrintArr(obj.FindOrder(2,Tools.ConstructTArray("[]")));
    }
    
    public int[] FindOrder1(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, HashSet<int>> graph = new();

        for (int i = 0; i < numCourses; i++)
        {
            graph.TryAdd(i, new HashSet<int>());
        }
        
        foreach (var prerequisite in prerequisites)
        {
            var to = prerequisite[0];
            var from = prerequisite[1];

            graph.TryAdd(from, new HashSet<int>());
            graph.TryAdd(to, new HashSet<int>());
            graph[to].Add(from);
        }

        int[] res = new int[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            int node = -1;
            foreach (var (key, value) in graph)
            {
                if (value.Count == 0)
                    node = key;
            }

            if (node == -1) return Array.Empty<int>();
            res[i] = node;
            graph.Remove(node);
            foreach (var (key, value) in graph)
            {
                if (value.Contains(node))
                    value.Remove(node);
            }
        }

        return res;
    }

    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // 建图
        Dictionary<int, List<int>> graph = new();
        for (int i = 0; i < numCourses; i++)
        {
            graph.Add(i,new List<int>());
        }
        // 统计入度
        int[] inSight = new int[numCourses];
        foreach (var prerequisite in prerequisites)
        {
            var to = prerequisite[0];
            var from = prerequisite[1];
            
            graph[from].Add(to);
            inSight[to]++;
        }
        // 找到入度为0的节点
        Queue<int> queue = new();
        for (int i = 0; i < numCourses; i++)
        {
            if(inSight[i] == 0)
                queue.Enqueue(i);
        }
        List<int> res = new List<int>();
        while (queue.Count > 0)
        {
            // 删除入度为0的节点,继续寻找其他入度为0的节点
            var node = queue.Dequeue();
            res.Add(node);
            foreach (var next in graph[node])
            {
                inSight[next]--;
                if(inSight[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return res.Count == numCourses ? res.ToArray() : Array.Empty<int>();
    }
}