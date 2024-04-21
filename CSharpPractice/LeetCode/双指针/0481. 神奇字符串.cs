using System.Text;

namespace CSharpPractice.LeetCode.双指针;

/**
 * 神奇字符串 s 仅由 '1' 和 '2' 组成，并需要遵守下面的规则：

    神奇字符串 s 的神奇之处在于，串联字符串中 '1' 和 '2' 的连续出现次数可以生成该字符串。
    s 的前几个元素是 s = "1221121221221121122……" 。如果将 s 中连续的若干 1 和 2 进行分组，可以得到 "1 22 11 2 1 22 1 22 11 2 11 22 ......" 。每组中 1 或者 2 的出现次数分别是 "1 2 2 1 1 2 1 2 2 1 2 2 ......" 。上面的出现次数正是 s 自身。

    给你一个整数 n ，返回在神奇字符串 s 的前 n 个数字中 1 的数目。
 */
public class LeetCode_0481
{
    public static void Test()
    {
        LeetCode_0481 obj = new LeetCode_0481();
        Console.WriteLine(obj.MagicalString(6));
        Console.WriteLine(obj.MagicalString(1));
    }
    
    public int MagicalString(int n)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("122");
        int num = 0,left = 2,right = 2;
        while (right < n)
        {
            char need = sb[left];
            char cur = sb[right];
            
            // 需要1个
            if (need == '1')
            {
                // 当前字符是1
                if (cur == '1')
                    sb.Append("2");
                // 当前字符是2
                else
                    sb.Append("1");
                left++;
                right++;
            }
            // 需要2个
            else
            {
                // 当前字符是1
                if (cur == '1')
                    sb.Append("22");
                // 当前字符是2
                else
                    sb.Append("11");
                right += 2;
                left++;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (sb[i] == '1') num++;
        }
        return num;
    }
}