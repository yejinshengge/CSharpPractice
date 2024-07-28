namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR014
{
    public static void Test()
    {
        LeetCode_LCR014 obj = new LeetCode_LCR014();
        Console.WriteLine(obj.CheckInclusion("ab","eidbaooo"));
        Console.WriteLine(obj.CheckInclusion("ab","eidboaoo"));
    }
    
    public bool CheckInclusion1(string s1, string s2)
    {
        if (s2.Length < s1.Length) return false;
        int[] count = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            count[s1[i] - 'a']++;
        }

        for (int i = 0; i < s2.Length; i++)
        {
            count[s2[i] - 'a']--;
            if (i >= s1.Length)
                count[s2[i - s1.Length] - 'a']++;
            bool flag = true;
            foreach (var item in count)
            {
                if (item != 0)
                    flag = false;
            }

            if (flag) return true;
        }

        return false;
    }

    public bool CheckInclusion(string s1, string s2)
    {
        if (s2.Length < s1.Length) return false;
        int[] count = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            count[s1[i] - 'a']--;
        }

        int left = 0;
        for (int right = 0; right < s2.Length; right++)
        {
            var x = s2[right] - 'a';
            count[x]++;
            while (count[x] > 0)
            {
                count[s2[left] - 'a']--;
                left++;
            }

            if (right - left + 1 == s1.Length)
                return true;
        }

        return false;
    }
}