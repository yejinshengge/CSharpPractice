namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR034
{
    public static void Test()
    {
        LeetCode_LCR034 obj = new LeetCode_LCR034();
        Console.WriteLine(obj.IsAlienSorted(new []{"hello","leetcode"},"hlabcdefgijkmnopqrstuvwxyz"));
        Console.WriteLine(obj.IsAlienSorted(new []{"word","world","row"},"worldabcefghijkmnpqstuvxyz"));
        Console.WriteLine(obj.IsAlienSorted(new []{"apple","app"},"abcdefghijklmnopqrstuvwxyz"));
    }
    
    public bool IsAlienSorted(string[] words, string order)
    {
        int[] map = new int[26];
        for (int i = 0; i < order.Length; i++)
        {
            map[order[i] - 'a'] = i;
        }

        for (int i = 0; i < words.Length-1; i++)
        {
            string word1 = words[i];
            string word2 = words[i+1];
            if (!_check(word1, word2, map))
                return false;
        }
        return true;
    }

    private bool _check(string word1, string word2,int[] map)
    {
        int index = 0;
        while (index < word1.Length && index < word2.Length)
        {
            if (map[word1[index] - 'a'] > map[word2[index] - 'a'])
                return false;
            if (map[word1[index] - 'a'] < map[word2[index] - 'a'])
                return true;
            index++;
        }

        return word1.Length <= word2.Length;
    }
}