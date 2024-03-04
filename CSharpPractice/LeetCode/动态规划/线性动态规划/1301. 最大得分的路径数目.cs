using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个正方形字符数组 board ，你从数组最右下方的字符 'S' 出发。
    
    你的目标是到达数组最左上角的字符 'E' ，数组剩余的部分为数字字符 1, 2, ..., 9 或者障碍 'X'。在每一步移动中，你可以向上、向左或者左上方移动，可以移动的前提是到达的格子没有障碍。
    
    一条路径的 「得分」 定义为：路径上所有数字的和。
    
    请你返回一个列表，包含两个整数：第一个整数是 「得分」 的最大值，第二个整数是得到最大得分的方案数，请把结果对 10^9 + 7 取余。
    
    如果没有任何路径可以到达终点，请返回 [0, 0] 。
 */
public class LeetCode_1301
{
    public static void Test()
    {
        LeetCode_1301 obj = new LeetCode_1301();
        Tools.PrintArr(obj.PathsWithMaxScore(new List<string>(){"E23","2X2","12S"}));
        Tools.PrintArr(obj.PathsWithMaxScore(new List<string>(){"E12","1X1","21S"}));
        Tools.PrintArr(obj.PathsWithMaxScore(new List<string>(){"E11","XXX","11S"}));
    }

    private const int MOD = 1000000007;
    public int[] PathsWithMaxScore(IList<string> board)
    {
        var len = board.Count;
        // 从起始点到x,y点的得分最大值
        int[,] scoreDp = new int[len,len];
        // 从起始点到x,y点的最大得分方案数
        int[,] numDp = new int[len,len];

        for (int x = len-1; x >= 0; x--)
        {
            for (int y = len-1; y >= 0; y--)
            {
                // 起始点方案数为1
                if (x == len - 1 && y == len - 1)
                {
                    numDp[x, y] = 1;
                    continue;
                }
                // 当前为障碍物,得分为无效值
                if (board[x][y] == 'X')
                {
                    scoreDp[x, y] = int.MinValue;
                    continue;
                }
                // 当前点权值
                int val = 0;
                if (x != 0 || y != 0)
                    val = board[x][y] - '0';

                int maxScore = int.MinValue;
                int maxNum = 0;
                
                // 可以从下方转移
                if (x + 1 < len)
                {
                    int curScore = scoreDp[x + 1, y] + val;
                    int curNum = numDp[x + 1, y];
                    var res = _update(curScore, curNum, maxScore, maxNum);
                    maxScore = res[0];
                    maxNum = res[1];
                }
                // 可以从右侧转移
                if (y + 1 < len)
                {
                    int curScore = scoreDp[x, y+1] + val;
                    int curNum = numDp[x, y+1];
                    var res = _update(curScore, curNum, maxScore, maxNum);
                    maxScore = res[0];
                    maxNum = res[1];
                }
                // 可以从右下转移
                if (y + 1 < len && x + 1 < len)
                {
                    int curScore = scoreDp[x+1, y+1] + val;
                    int curNum = numDp[x+1, y+1];
                    var res = _update(curScore, curNum, maxScore, maxNum);
                    maxScore = res[0];
                    maxNum = res[1];
                }

                scoreDp[x, y] = maxScore < 0 ? int.MinValue:maxScore;
                numDp[x, y] = maxNum;
            }
        }

        return new[] { scoreDp[0,0] == int.MinValue?0:scoreDp[0,0], scoreDp[0,0] == int.MinValue?0:numDp[0,0] };
    }

    private int[] _update(int curScore, int curNum, int maxScore, int maxNum)
    {
        int[] res = { maxScore, maxNum };
        // 有新的最大得分,更新方案数
        if (curScore > maxScore)
        {
            res[0] = curScore;
            res[1] = curNum;
        }
        // 有相同的最大得分,累加方案数
        else if (curScore == maxScore && curScore != int.MinValue)
        {
            res[1] += curNum;
        }

        res[1] %= MOD;
        return res;
    }
}