using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_02
{
    public static void Test()
    {
        LeetCode_08_02 obj = new LeetCode_08_02();
        Tools.PrintEnumerator(obj.PathWithObstacles(Tools.ConstructTArray("[[0,0,0],[0,1,0],[0,0,0]]")));
        //Tools.PrintEnumerator(obj.PathWithObstacles(Tools.ConstructTArray("[[1]]")));
    }

    private IList<IList<int>> _path = new List<IList<int>>();
    public IList<IList<int>> PathWithObstacles(int[][] obstacleGrid)
    {
        bool[,] visited = new bool[obstacleGrid.Length,obstacleGrid[0].Length];
        _backTracking(obstacleGrid, visited,0, 0);
        return _path;
    }

    private bool _backTracking(int[][] obstacleGrid,bool[,] visited, int x, int y)
    {
        if (x >= obstacleGrid.Length || y >= obstacleGrid[0].Length)
            return false;
        if (obstacleGrid[x][y] == 1 || visited[x,y]) return false;
        if (x == obstacleGrid.Length - 1 && y == obstacleGrid[0].Length - 1)
        {
            _path.Add(new List<int>(){x,y});
            return true;
        }

        visited[x, y] = true;
        _path.Add(new List<int>(){x,y});
        if (_backTracking(obstacleGrid, visited,x + 1, y) || _backTracking(obstacleGrid,visited, x, y + 1))
            return true;
        _path.RemoveAt(_path.Count-1);
        return false;
    }
}