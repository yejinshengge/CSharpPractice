using System.Text;
using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.双指针;

/**
 * 给你一个字符数组 chars ，请使用下述算法压缩：

    从一个空字符串 s 开始。对于 chars 中的每组 连续重复字符 ：

    如果这一组长度为 1 ，则将字符追加到 s 中。
    否则，需要向 s 追加字符，后跟这一组的长度。
    压缩后得到的字符串 s 不应该直接返回 ，需要转储到字符数组 chars 中。需要注意的是，如果组长度为 10 或 10 以上，则在 chars 数组中会被拆分为多个字符。

    请在 修改完输入数组后 ，返回该数组的新长度。

    你必须设计并实现一个只使用常量额外空间的算法来解决此问题。
 */
public class LeetCode_0443
{
    public static void Test()
    {
        LeetCode_0443 obj = new LeetCode_0443();
        //var arr = new[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
        var arr = new[] { 'a'};
        //var arr = new[] { 'a','b','b','b','b','b','b','b','b','b','b','b','b'};
        Console.WriteLine(obj.Compress(arr));
        Tools.PrintArr(arr);
    }

    // 常量空间
    public int Compress(char[] chars)
    {
        int left = 1;
        int count = 1;
        for (int right = 1; right < chars.Length; right++)
        {
            if (chars[right] == chars[right - 1])
                count++;
            else
            {
                _appendCount(chars, ref left, ref count);
                chars[left++] = chars[right];
                count = 1;
            }
        }
        _appendCount(chars, ref left, ref count);
        return left;
    }

    private void _appendCount(char[] chars, ref int left, ref int count)
    {
        if (count > 1)
        {
            int cur = left;
            while (count > 0)
            {
                chars[left++] = (char)(count % 10+'0');
                count = count / 10;
            }
            Array.Reverse(chars,cur,left-cur);
        }
    }
    
    public int Compress2(char[] chars)
    {
        StringBuilder str = new StringBuilder();
        int count = 1;
        str.Append(chars[0]);
        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == chars[i - 1])
                count++;
            else
            {
                if (count > 1)
                    str.Append(count);
                str.Append(chars[i]);
                count = 1;
            }
        }
        if (count > 1)
            str.Append(count);
        str.CopyTo(0,chars,0,str.Length);
        return str.Length;
    }
}