namespace CSharpPractice.LeetCode.哈希表篇;

public class LeetCode_1366
{
    public static void Test()
    {
        LeetCode_1366 obj = new LeetCode_1366();
        Console.WriteLine(obj.RankTeams(new []{"ABC","ACB","ABC","ACB","ACB"}));
        Console.WriteLine(obj.RankTeams(new []{"WXYZ","XYZW"}));
        Console.WriteLine(obj.RankTeams(new []{"ZMNAGUEDSJYLBOPHRQICWFXTVK"}));
    }
    
    public string RankTeams(string[] votes)
    {
        Dictionary<char, int>[] dic = new Dictionary<char, int>[votes[0].Length];
        for (var i = 0; i < dic.Length; i++)
        {
            dic[i] = new Dictionary<char, int>();
        }
        for (var i = 0; i < votes.Length; i++)
        {
            for (var j = 0; j < votes[i].Length; j++)
            {
                dic[j].TryAdd(votes[i][j], 0);
                dic[j][votes[i][j]]++;
            }
        }

        var arr = votes[0].ToCharArray();
        Array.Sort(arr, (a, b) =>
        {
            for (int i = 0; i < dic.Length; i++)
            {
                dic[i].TryGetValue(a, out int aDefault);
                dic[i].TryGetValue(b, out int bDefault);
                if (aDefault != bDefault)
                    return bDefault - aDefault;
            }

            return a - b;
        });
        return new string(arr);
    }
}