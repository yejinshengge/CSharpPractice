using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_10
{
    public static void Test()
    {
        LeetCode_08_10 obj = new LeetCode_08_10();
        Tools.PrintArr(obj.FloodFill(Tools.ConstructTArray("[[1,1,1],[1,1,0],[1,0,1]]"),1,1,2));
    }
    
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        _doFloodFill(image, sr, sc, newColor, new bool[image.Length,image[0].Length]);
        return image;
    }
    
    private void _doFloodFill(int[][] image, int sr, int sc, int newColor, bool[,] visited)
    {
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length)
            return;
        if(visited[sr,sc])
            return;
        visited[sr, sc] = true;
        if (sr - 1 >= 0 && image[sr - 1][sc] == image[sr][sc])
            _doFloodFill(image, sr - 1, sc, newColor,visited);
        if (sr + 1 < image.Length && image[sr + 1][sc] == image[sr][sc])
            _doFloodFill(image, sr + 1, sc, newColor,visited);
        if (sc - 1 >= 0 && image[sr][sc-1] == image[sr][sc])
            _doFloodFill(image, sr, sc-1, newColor,visited);
        if (sc + 1 < image[0].Length && image[sr][sc+1] == image[sr][sc])
            _doFloodFill(image, sr, sc+1, newColor,visited);
        image[sr][sc] = newColor;
    }
}