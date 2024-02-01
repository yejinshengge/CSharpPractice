namespace CSharpPractice.LeetCode.动态规划.线性动态规划;

/**
 * 给你一个 互不相同 的整数数组，其中 locations[i] 表示第 i 个城市的位置。同时给你 start，finish 和 fuel 分别表示出发城市、目的地城市和你初始拥有的汽油总量
    
    每一步中，如果你在城市 i ，你可以选择任意一个城市 j ，满足  j != i 且 0 &lt;= j &lt; locations.length ，并移动到城市 j 。从城市 i 移动到 j 消耗的汽油量为 |locations[i] - locations[j]|，|x| 表示 x 的绝对值。
    
    请注意， fuel 任何时刻都 不能 为负，且你 可以 经过任意城市超过一次（包括 start 和 finish ）。
    
    请你返回从 start 到 finish 所有可能路径的数目。
    
    由于答案可能很大， 请将它对 10^9 + 7 取余后返回。
 */
public class LeetCode_1575
{
    public static void Test()
    {
        LeetCode_1575 obj = new LeetCode_1575();
        // Console.WriteLine(obj.CountRoutes(new []{2,3,6,8,4},1,3,5));
        // Console.WriteLine(obj.CountRoutes(new []{4,3,1},1,0,6));
        // Console.WriteLine(obj.CountRoutes(new []{5,2,1},0,2,3));
        Console.WriteLine(obj.CountRoutes(new []{1,2,3},0,2,40));
    }

    private const int MOD = 1000000007;
    public int CountRoutes(int[] locations, int start, int finish, int fuel)
    {
        int[,] map = new int[locations.Length, fuel + 1];
        for (int i = 0; i < locations.Length; i++)
        {
            for (int j = 0; j <= fuel; j++)
            {
                map[i, j] = -1;
            }
        }

        return _doCountRoutes(locations, start, finish, fuel, map);
    }

    private int _doCountRoutes(int[] locations, int start, int finish, int fuel,int[,] map)
    {
        if (map[start, fuel] != -1)
            return map[start, fuel];
        
        var restFuel = fuel - Math.Abs(locations[start] - locations[finish]);
        if (restFuel < 0)
        {
            map[start, fuel] = 0;
            return 0;
        }

        int total = start == finish ?1:0;
        for (int i = 0; i < locations.Length; i++)
        {
            if(i == start) continue;
            restFuel = fuel - Math.Abs(locations[start] - locations[i]);
            if (restFuel >= 0)
            {
                total += _doCountRoutes(locations, i, finish, restFuel,map);
                total %= MOD;
            }
            
        }
        map[start, fuel] = total;
        return total;
    }
}