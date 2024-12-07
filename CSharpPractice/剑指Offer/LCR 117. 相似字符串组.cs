namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR117
{
    public static void Test()
    {
        LeetCode_LCR117 obj = new LeetCode_LCR117();
        Console.WriteLine(obj.NumSimilarGroups(new []{"tars","rats","arts","star"}));
        Console.WriteLine(obj.NumSimilarGroups(new []{"omv","ovm"}));
        Console.WriteLine(obj.NumSimilarGroups(new []{"a"}));
        Console.WriteLine(obj.NumSimilarGroups(new []{"a","a"}));
        Console.WriteLine(obj.NumSimilarGroups(new []{"a","b"}));
    }
    
    public int NumSimilarGroups(string[] strs)
    {
        int[] fathers = new int[strs.Length];
        for (int i = 0; i < fathers.Length; i++)
        {
            fathers[i] = i;
        }

        int count = strs.Length;
        for (var i = 0; i < strs.Length; i++)
        {
            for (var j = i+1; j < strs.Length; j++)
            {
                if (_checkSimilar(strs[i], strs[j]) && _union(fathers, i, j))
                    count--;
            }
        }

        return count;
    }

    private bool _checkSimilar(string str1, string str2)
    {
        if (str1 == str2) return true;
        int diffCnt = 0;
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
                diffCnt++;
        }

        return diffCnt == 2;
    }

    private bool _union(int[] fathers,int i,int j)
    {
        var root1 = _getFather(fathers, i);
        var root2 = _getFather(fathers, j);
        if (root1 != root2)
        {
            fathers[root1] = root2;
            return true;
        }

        return false;
    }

    private int _getFather(int[] fathers, int i)
    {
        if (fathers[i] != i)
            fathers[i] = _getFather(fathers, fathers[i]);
        return fathers[i];
    }
}