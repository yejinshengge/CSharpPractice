using System.Text;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR109
{
    public static void Test()
    {
        LeetCode_LCR109 obj = new LeetCode_LCR109();
        Console.WriteLine(obj.OpenLock(new []{"0201","0101","0102","1212","2002"},"0202"));//6
        Console.WriteLine(obj.OpenLock(new []{"8888"},"0009"));//1
        Console.WriteLine(obj.OpenLock(new []{"0000"},"8888"));//-1
        Console.WriteLine(obj.OpenLock(new []{"8887","8889","8878","8898","8788","8988","7888","9888"},"8888"));//-1
    }
    
    public int OpenLock1(string[] deadends, string target)
    {
        HashSet<string> visited = new();
        HashSet<string> dead = new(deadends);
        if (dead.Contains("0000")) return -1;
        Queue<string> queue = new();
        int minCnt = 0;
        queue.Enqueue("0000");
        visited.Add("0000");
        while (queue.Count > 0)
        {
            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var cur = queue.Dequeue();
                if (cur == target) return minCnt;
                var neighbors = _getNeighbors(cur);
                foreach (var neighbor in neighbors)
                {
                    if(visited.Contains(neighbor)) continue;
                    if(dead.Contains(neighbor)) continue;
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
            minCnt++;
        }

        return -1;
    }

    public int OpenLock(string[] deadends, string target)
    {
        HashSet<string> visited = new();
        HashSet<string> dead = new(deadends);
        if (dead.Contains("0000")) return -1;
        if (target == "0000") return 0;
        HashSet<string> front = new();
        HashSet<string> tail = new();
        int minCnt = 0;
        front.Add("0000");
        tail.Add(target);
        visited.Add("0000");
        visited.Add(target);
        
        while (front.Count > 0 && tail.Count > 0)
        {
            if (front.Count > tail.Count)
                (front, tail) = (tail, front);
            HashSet<string> tmp = new();
            minCnt++;
            foreach (var str in front)
            {
                var neighbors = _getNeighbors(str);
                foreach (var neighbor in neighbors)
                {
                    if (tail.Contains(neighbor)) return minCnt;
                    if(dead.Contains(neighbor)) continue;
                    if(visited.Contains(neighbor)) continue;
                    tmp.Add(neighbor);
                }
            }

            front = tmp;
        }

        return -1;
    }
    
    private List<string> _getNeighbors(string cur)
    {
        List<string> res = new();
        StringBuilder sb = new StringBuilder(cur);
        for (int i = 0; i < cur.Length; i++)
        {
            var pre = sb[i];
            sb[i] = sb[i] == '9' ? '0' : (char)(sb[i] + 1);
            res.Add(sb.ToString());
            sb[i] = pre;
            sb[i] = sb[i] == '0' ? '9' : (char)(sb[i] - 1);
            res.Add(sb.ToString());
            sb[i] = pre;
        }
        return res;
    }
}