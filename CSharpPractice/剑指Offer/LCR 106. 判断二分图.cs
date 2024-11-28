using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR106
{
    public static void Test()
    {
        LeetCode_LCR106 obj = new LeetCode_LCR106();
        Console.WriteLine(obj.IsBipartite(Tools.ConstructTArray("[[1,2,3],[0,2],[0,1,3],[0,2]]")));
        Console.WriteLine(obj.IsBipartite(Tools.ConstructTArray("[[1,3],[0,2],[1,3],[0,2]]")));
        Console.WriteLine(obj.IsBipartite(Tools.ConstructTArray("[[1],[0,3],[3],[1,2]]")));
        Console.WriteLine(obj.IsBipartite(Array.Empty<int[]>()));
    }
    
    public bool IsBipartite(int[][] graph)
    {
        int[] color = new int[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if(color[i] == 0)
                if(!_canSetColor(graph,color,0,i))
                    return false;
        }
        return true;
    }

    private bool _canSetColor(int[][] graph, int[] colorMap, int color,int node)
    {
        Queue<int> queue = new();
        queue.Enqueue(node);
        colorMap[node] = color;
        while (queue.Count > 0)
        {
            var index = queue.Dequeue();
            foreach (var neighbor in graph[index])
            {
                // 已染色
                if (colorMap[neighbor] > 0)
                {
                    if (colorMap[neighbor] == colorMap[index])
                        return false;
                }
                // 未染色
                else
                {
                    queue.Enqueue(neighbor);
                    colorMap[neighbor] = 3 - colorMap[index];
                }
            }
        }

        return true;
    }
}