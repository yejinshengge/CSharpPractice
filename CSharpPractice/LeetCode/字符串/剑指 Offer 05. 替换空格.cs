namespace CSharpPractice.LeetCode.字符串;

// 请实现一个函数，把字符串 s 中的每个空格替换成"%20"。
public class LeetCode_Offer05
{
    public static void Test()
    {
        LeetCode_Offer05 obj = new LeetCode_Offer05();
        Console.WriteLine(obj.ReplaceSpace("We are happy."));
    }
    
    // 双指针
    public string ReplaceSpace(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
                count++;
        }

        char[] res = new char[count*2+s.Length];
        int left = s.Length-1;
        int right = res.Length - 1;

        while (left >= 0)
        {
            if (s[left] == ' ')
            {
                res[right] = '0';
                res[right-1] = '2';
                res[right-2] = '%';
                right -= 3;
                left--;
            }
            else
            {
                res[right] = s[left];
                right--;
                left--;
            }
        }
        return new string(res);
    }
}