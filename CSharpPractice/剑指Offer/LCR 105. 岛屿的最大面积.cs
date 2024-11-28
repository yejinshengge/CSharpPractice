using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR105
{
    public static void Test()
    {
        LeetCode_LCR105 obj = new LeetCode_LCR105();
        Console.WriteLine(obj.MaxAreaOfIsland(Tools.ConstructTArray("[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]")));
        Console.WriteLine(obj.MaxAreaOfIsland(Tools.ConstructTArray("[[0,0,0,0,0,0,0,0]]")));
        Console.WriteLine(obj.MaxAreaOfIsland(Tools.ConstructTArray("[[1,1,1,1,1,1,1,1]]")));
        Console.WriteLine(obj.MaxAreaOfIsland(Tools.ConstructTArray("[[0]]")));
        Console.WriteLine(obj.MaxAreaOfIsland(Tools.ConstructTArray("[[1]]")));
        
    }
    
    public int MaxAreaOfIsland(int[][] grid)
    {
        bool[,] visited = new bool[grid.Length,grid[0].Length];
        int area = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                area = Math.Max(_getArea(visited, grid, i, j), area);
            }
        }

        return area;
    }

    private int _getArea(bool[,] visited, int[][] grid, int x, int y)
    {
        if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length) return 0;
        if (visited[x, y]) return 0;
        visited[x, y] = true;
        if (grid[x][y] == 0) return 0;
        int area = 0;
        area += _getArea(visited, grid, x + 1, y);
        area += _getArea(visited, grid, x - 1, y);
        area += _getArea(visited, grid, x, y + 1);
        area += _getArea(visited, grid, x, y - 1);
        return area + 1;
    }
}