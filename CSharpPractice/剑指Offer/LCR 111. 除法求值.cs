using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR111
{
    public static void Test()
    {
        LeetCode_LCR111 obj = new LeetCode_LCR111();
        
    }
    
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        // 建图
        Dictionary<string, Dictionary<string, double>> dic = new();

        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            var value = values[i];

            string a = equation[0];
            string b = equation[1];
            dic.TryAdd(a, new Dictionary<string, double>());
            dic.TryAdd(b, new Dictionary<string, double>());
            dic[a].Add(b,value);
            dic[b].Add(a,1/value);
        }

        double[] res = new double[queries.Count];
        for (var i = 0; i < queries.Count; i++)
        {
            var query = queries[i];
            res[i] = _dfs(dic, query[0], query[1], new HashSet<string>());
        }

        return res;
    }

    private double _dfs(Dictionary<string, Dictionary<string, double>> graph, string a, string b,
        HashSet<string> visited)
    {
        if (!graph.ContainsKey(a)) return -1;
        if (a == b) return 1;
        if (graph[a].ContainsKey(b)) return graph[a][b];
        visited.Add(a);
        foreach (var (key, value) in graph[a])
        {
            if(visited.Contains(key)) continue;
            var nextVal = _dfs(graph, key, b, visited);
            if (nextVal > 0)
                return value * nextVal;
        }

        visited.Remove(a);
        return -1;
    }
}