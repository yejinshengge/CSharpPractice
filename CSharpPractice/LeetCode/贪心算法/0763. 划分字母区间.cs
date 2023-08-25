using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.贪心算法;

/**
给你一个字符串 s 。我们要把这个字符串划分为尽可能多的片段，同一字母最多出现在一个片段中。
注意，划分结果需要满足：将所有划分结果按顺序连接，得到的字符串仍然是 s 。
返回一个表示每个字符串片段的长度的列表。
 */
public class LeetCode_0763
{
    public static void Test()
    {
        LeetCode_0763 obj = new LeetCode_0763();
        Tools.PrintEnumerator(obj.PartitionLabels("ababcbacadefegdehijhklij"));
        Tools.PrintEnumerator(obj.PartitionLabels("eccbbbbdec"));
    }
    
    public IList<int> PartitionLabels2(string s)
    {
        IList<int> res = new List<int>();
        int[] arr = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            arr[s[i] - 'a']++;
        }
        
        HashSet<char> set = new HashSet<char>();
        int pre = 0;
        for (int i = 0; i < s.Length; i++)
        {
            set.Add(s[i]);
            var index = s[i] - 'a';
            arr[index]--;
            if (arr[index] == 0)
            {
                set.Remove(s[i]);
                if (set.Count == 0)
                {
                    res.Add(i-pre+1);
                    pre = i+1;
                }
            }
        }

        return res;
    }

    public IList<int> PartitionLabels(string s)
    {
        IList<int> res = new List<int>();
        int[] arr = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            arr[s[i] - 'a'] = i;
        }

        int right = 0;
        int left = 0;
        for (int i = 0; i < s.Length; i++)
        {
            right = Math.Max(arr[s[i] - 'a'], right);
            if (right == i)
            {
                res.Add(right-left+1);
                left = i + 1;
            }
        }

        return res;
    }
}