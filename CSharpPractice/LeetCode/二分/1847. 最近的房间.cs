using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二分;

public class LeetCode_1847
{
    public static void Test()
    {
        LeetCode_1847 obj = new LeetCode_1847();
        Tools.PrintArr(obj.ClosestRoom(Tools.ConstructTArray("[[2,2],[1,2],[3,2]]"),Tools.ConstructTArray("[[3,1],[3,3],[5,2]]")));
        Tools.PrintArr(obj.ClosestRoom(Tools.ConstructTArray("[[1,4],[2,3],[3,5],[4,1],[5,2]]"),Tools.ConstructTArray("[[2,3],[2,4],[2,5]]")));
    }
    
    public int[] ClosestRoom(int[][] rooms, int[][] queries) {
        Array.Sort(rooms, (a, b) => b[1] - a[1]);
        int[] queryIds = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            queryIds[i] = i;
        }
        Array.Sort(queryIds,(a,b)=>queries[b][1] - queries[a][1]);

        SortedSet<int> roomIds = new SortedSet<int>();
        int total = 0;
        int[] res = new int[queries.Length];
        foreach (var index in queryIds)
        {
            res[index] = -1;
            int queryId = queries[index][0];
            int querySize = queries[index][1];
            while (total < rooms.Length && rooms[total][1] >= querySize)
            {
                roomIds.Add(rooms[total][0]);
                total++;
            }

            int dis = int.MaxValue;
            var min = roomIds.GetViewBetween(queryId, int.MaxValue).Min;
            if (min != default && min - queryId < dis)
            {
                dis = min - queryId;
                res[index] = min;
            }
            
            var max = roomIds.GetViewBetween(0, queryId).Max;
            if (max != default && queryId - max <= dis)
            {
                res[index] = max;
            }
        }

        return res;
    }
}