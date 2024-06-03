using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_04_01
{
    public static void Test()
    {
        LeetCode_04_01 obj = new LeetCode_04_01();
        Console.WriteLine(obj.FindWhetherExistsPath(3,Tools.ConstructTArray("[[0, 1], [0, 2], [1, 2], [1, 2]]"),0,2));
    }
    
    // 广度优先
    public bool FindWhetherExistsPath2(int n, int[][] graph, int start, int target)
    {
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < graph.Length; i++)
        {
            if (!dic.ContainsKey(graph[i][0]))
                dic[graph[i][0]] = new List<int>();
            dic[graph[i][0]].Add(graph[i][1]);
        }

        if (!dic.ContainsKey(start))
            return false;
        bool[] visit = new bool[n];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == target)
                return true;
            visit[node] = true;
            if(!dic.ContainsKey(node))
                continue;
            var list = dic[node];
            for (int i = 0; i < list.Count; i++)
            {
                if(!visit[list[i]])
                    queue.Enqueue(list[i]);
            }
        }

        return false;
    }

    // 深度优先
    public bool FindWhetherExistsPath(int n, int[][] graph, int start, int target)
    {
        return _dfs(new bool[n], graph, start, target);
    }

    private bool _dfs(bool[] visit,int[][] graph, int start, int target)
    {
        if (start == target) return true;
        visit[start] = true;
        for (int i = 0; i < graph.Length; i++)
        {
            if(visit[graph[i][1]])continue;
            if (_dfs(visit, graph, graph[i][1], target))
                return true;
        }

        return false;
    }
}