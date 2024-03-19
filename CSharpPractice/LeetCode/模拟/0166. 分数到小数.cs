using System.Text;

namespace CSharpPractice.LeetCode.模拟;

/**
 * 给定两个整数，分别表示分数的分子 numerator 和分母 denominator，以 字符串形式返回小数 。

    如果小数部分为循环小数，则将循环的部分括在括号内。

    如果存在多个答案，只需返回 任意一个 。

    对于所有给定的输入，保证 答案字符串的长度小于 104 。
 */
public class LeetCode_0166
{
    public static void Test()
    {
        LeetCode_0166 obj = new LeetCode_0166();
        Console.WriteLine(obj.FractionToDecimal(1,2));
        Console.WriteLine(obj.FractionToDecimal(2,1));
        Console.WriteLine(obj.FractionToDecimal(4,333));
        Console.WriteLine(obj.FractionToDecimal(-50,8));
        Console.WriteLine(obj.FractionToDecimal(7,-12));
        Console.WriteLine(obj.FractionToDecimal(0,-12));
        Console.WriteLine(obj.FractionToDecimal(0,12));
        Console.WriteLine(obj.FractionToDecimal(-1,-2147483648));
    }
    
    public string FractionToDecimal(int numerator, int denominator)
    {
        StringBuilder intNum = new StringBuilder();
        StringBuilder decNum = new StringBuilder();
        Dictionary<long, int> dic = new Dictionary<long, int>();
        // 符号部分
        if ((numerator > 0 && denominator < 0) || (numerator < 0 && denominator > 0))
            intNum.Append("-");
        // 整数部分
        long numeratorL = Math.Abs((long)numerator);
        long denominatorL = Math.Abs((long)denominator);
        intNum.Append(numeratorL / denominatorL);
        long rest = numeratorL % denominatorL;
        if (rest == 0) return intNum.ToString();
        intNum.Append(".");

        // 记录当前是第几位
        int index = 0;
        // 如果除尽了或循环了,停止迭代
        while (rest != 0 && !dic.ContainsKey(rest))
        {
            // 缓存当前余数
            dic[rest] = index;
            // 进位,
            rest = rest * 10;
            decNum.Append(rest / denominatorL);
            rest = rest % denominatorL;
            index++;
        }
        
        // 如果还有余数,说明循环了
        if (rest > 0)
        {
            decNum.Insert(dic[rest], "(");
            decNum.Insert(index+1, ")");
        }

        intNum.Append(decNum);
        return intNum.ToString();
    }
}