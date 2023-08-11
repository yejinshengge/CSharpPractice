namespace CSharpPractice.LeetCode.数组篇.移除元素;

/**
给定 s 和 t 两个字符串，当它们分别被输入到空白的文本编辑器后，如果两者相等，返回 true 。# 代表退格字符。
注意：如果对空文本输入退格字符，文本继续为空。

 */
public class LeetCode_0844
{
    public static void Test()
    {
        LeetCode_0844 obj = new LeetCode_0844();
        Console.WriteLine(obj.BackspaceCompare("a##c","#a#c"));
    }

    public bool BackspaceCompare(string s, string t)
    {
        return Process(s) == Process(t);
    }

    private string Process(string str)
    {
        int left = 0, right = 0;
        var charArray = str.ToCharArray();
        while (right<charArray.Length)
        {
            if (charArray[right] == '#')
            {
                left = Math.Max(left-1, 0);
                right++;
            }
            else
            {
                (charArray[left], charArray[right]) = (charArray[right], charArray[left]);
                left++;
                right++;
            }
            
        }

        return new string(charArray, 0, left);
    }
}