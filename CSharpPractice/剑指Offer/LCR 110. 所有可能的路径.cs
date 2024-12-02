using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_110
{
    public static void Test()
    {
        LeetCode_110 obj = new LeetCode_110();
        Tools.PrintEnumerator(obj.AllPathsSourceTarget(Tools.ConstructTArray("[[1,2],[3],[3],[]]")));
        Tools.PrintEnumerator(obj.AllPathsSourceTarget(Tools.ConstructTArray("[[4,3,1],[3,2,4],[3],[4],[]]")));
        Tools.PrintEnumerator(obj.AllPathsSourceTarget(Tools.ConstructTArray("[[1],[]]")));
        Tools.PrintEnumerator(obj.AllPathsSourceTarget(Tools.ConstructTArray("[[1,2,3],[2],[3],[]]")));
        Tools.PrintEnumerator(obj.AllPathsSourceTarget(Tools.ConstructTArray("[[1,3],[2],[3],[]]")));
    }
    
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        _path.Clear();
        _res.Clear();
        _path.Add(0);
        _findPath(graph,0,new bool[graph.Length]);
        return _res;
    }

    private IList<int> _path = new List<int>();
    private IList<IList<int>> _res = new List<IList<int>>();
    private void _findPath(int[][] graph,int cur,bool[] visited)
    {
        if (cur == graph.Length - 1)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        foreach (var node in graph[cur])
        {
            if(visited[node]) continue;
            _path.Add(node);
            visited[node] = true;
            _findPath(graph,node,visited);
            visited[node] = false;
            _path.RemoveAt(_path.Count-1);
        }
    }
}