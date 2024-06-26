using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_02
{
    public static void Test()
    {
        LeetCode_10_02 obj = new LeetCode_10_02();
        Tools.PrintEnumerator(obj.GroupAnagrams(new []{"eat", "tea", "tan", "ate", "nat", "bat"}));
    }
    
    public IList<IList<string>> GroupAnagrams1(string[] strs)
    {
        Dictionary<string, List<string>> dic = new();
        foreach (var str in strs)
        {
            var array = str.ToCharArray();
            Array.Sort(array);
            var key = new string(array);
            dic.TryAdd(key, new List<string>());
            dic[key].Add(str);
        }

        List<IList<string>> res = new List<IList<string>>();
        foreach (var list in dic.Values)
        {
            res.Add(list);
        }
        return res;
    }

    private static int[] nums = new int[26];
    
    static LeetCode_10_02(){
        for (int i = 2,index = 0;index < 26 ; i++)
        {
            bool flag = true;
            for (int j = 2; j <= i/j; j++)
            {
                if (i % j == 0)
                {
                    flag = false;
                    break;
                }
            }

            if (flag) nums[index++] = i;
        }
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<long, List<string>> dic = new();
        foreach (var str in strs)
        {
            long cur = 1;
            foreach (var c in str)
            {
                cur *= nums[c - 'a'];
            }

            dic.TryAdd(cur, new List<string>());
            dic[cur].Add(str);
        }

        IList<IList<string>> res = new List<IList<string>>();
        foreach (var value in dic.Values)
        {
            res.Add(value);
        }

        return res;
    }
}