using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

/**
假设有打乱顺序的一群人站成一个队列，数组 people 表示队列中一些人的属性（不一定按顺序）。
每个 people[i] = [hi, ki] 表示第 i 个人的身高为 hi ，前面 正好 有 ki 个身高大于或等于 hi 的人。
请你重新构造并返回输入数组 people 所表示的队列。返回的队列应该格式化为数组 queue ，其中 queue[j] = [hj, kj] 
是队列中第 j 个人的属性（queue[0] 是排在队列前面的人）。
 */
public class LeetCode_0406
{
    public static void Test()
    {
        LeetCode_0406 obj = new LeetCode_0406();
        var tArray = Tools.ConstructTArray("[[9,0],[7,0],[1,9],[3,0],[2,7],[5,3],[6,0],[3,4],[6,2],[5,2]]");
        Tools.PrintEnumerator(obj.ReconstructQueue(tArray));
    }
    
    public int[][] ReconstructQueue(int[][] people) {
        Array.Sort(people, (e1, e2) =>
        {
            if (e2[0] == e1[0])
                return e1[1] - e2[1];
            return e2[0] - e1[0];
        });
        List<int[]> res = new List<int[]>(people.Length);
        for (int i = 0; i < people.Length; i++)
        {
            res.Insert(people[i][1],people[i]);
        }
        return res.ToArray();
    }
}