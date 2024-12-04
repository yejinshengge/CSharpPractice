using System.Text;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR114
{
    public static void Test()
    {
        LeetCode_LCR114 obj = new LeetCode_LCR114();
        Console.WriteLine(obj.AlienOrder(new []{"wrt","wrf","er","ett","rftt"}));
        Console.WriteLine(obj.AlienOrder(new []{"z","x"}));
        Console.WriteLine(obj.AlienOrder(new []{"z","x","z"}));
        Console.WriteLine(obj.AlienOrder(new []{"ac","ab","zc","zb"}));
    }
    
    public string AlienOrder(string[] words)
    {
        Dictionary<char, HashSet<char>> graph = new();
        Dictionary<char, int> inDegrees = new();
        foreach (var word in words)
        {
            foreach (var c in word)
            {
                graph.TryAdd(c, new HashSet<char>());
                inDegrees.TryAdd(c,0);
            }
        }

        for (int i = 1; i < words.Length; i++)
        {
            var cur = words[i];
            var pre = words[i-1];
            if (pre.StartsWith(cur) && pre != cur) return "";
            for (int j = 0; j < cur.Length && j < pre.Length; j++)
            {
                if (cur[j] != pre[j])
                {
                    if (!graph[pre[j]].Contains(cur[j]))
                    {
                        graph[pre[j]].Add(cur[j]);
                        inDegrees[cur[j]]++;
                    }
                    break;
                }
            }
        }

        Queue<char> queue = new Queue<char>();
        foreach (var (key, value) in inDegrees)
        {
            if(value == 0)
                queue.Enqueue(key);
        }

        StringBuilder sb = new StringBuilder();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            sb.Append(node);
            foreach (var next in graph[node])
            {
                inDegrees[next]--;
                if(inDegrees[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return sb.Length == graph.Count ? sb.ToString() : "";
    }
}