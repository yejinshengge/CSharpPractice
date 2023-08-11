namespace CSharpPractice.LeetCode.字符串;

/**
给你一个字符串 s ，请你反转字符串中 单词 的顺序。

单词 是由非空格字符组成的字符串。s 中使用至少一个空格将字符串中的 单词 分隔开。

返回 单词 顺序颠倒且 单词 之间用单个空格连接的结果字符串。

注意：输入字符串 s中可能会存在前导空格、尾随空格或者单词间的多个空格。返回的结果字符串中，
单词间应当仅用单个空格分隔，且不包含任何额外的空格。


 */
public class LeetCode_0151
{
    public static void Test()
    {
        LeetCode_0151 obj = new LeetCode_0151();
        Console.WriteLine(obj.ReverseWords("the sky is blue"));
        Console.WriteLine(obj.ReverseWords("  hello world  "));
        Console.WriteLine(obj.ReverseWords("a good   example"));
    }

    public string ReverseWords(string s)
    {
        var array = s.ToCharArray();
        Trim(ref array);
        Reverse(array,0,array.Length-1);

        int pre = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == ' ')
            {
                Reverse(array,pre,i-1);
                pre = i+1;
            }
        }
        Reverse(array,pre,array.Length-1);
        return new string(array);
    }
    
    /// <summary>
    /// 去除多余空格
    /// </summary>
    /// <param name="arr"></param>
    private void Trim(ref char[] arr)
    {
        int left = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != ' ')
            {
                if (left != 0) arr[left++] = ' ';
                while (i < arr.Length && arr[i] != ' ')
                {
                    arr[left++] = arr[i++];
                }
            }
        }
        
        Array.Resize(ref arr,left);
    }

    private void Reverse(char[] arr, int left, int right)
    {
        
        for (int i = left; i <= (left+right)/2; i++)
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }
    }
}