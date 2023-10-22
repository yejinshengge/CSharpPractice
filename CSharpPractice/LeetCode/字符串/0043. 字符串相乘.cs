namespace CSharpPractice.LeetCode.字符串;

/**
给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。

注意：不能使用任何内置的 BigInteger 库或直接将输入转换为整数。
 */
public class LeetCode_0043
{
    public static void Test()
    {
        LeetCode_0043 obj = new LeetCode_0043();
        Console.WriteLine(obj.Multiply("123", "456"));
        Console.WriteLine(obj.Multiply("123", "4567"));
        Console.WriteLine(obj.Multiply("0", "4567"));
    }

    #region 加法解法
    public string Multiply1(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";
        string res = "";
        for (int i = num2.Length-1; i >=0; i--)
        {
            int flag = 0;
            string tmp = "";
            for (int j = num1.Length - 1; j >= 0; j--)
            {
                int product = (num2[i]-'0') * (num1[j]-'0')+flag;
                tmp = product % 10 + tmp;
                flag = product / 10;
            }
            if (flag != 0)
                tmp = flag + tmp;
            tmp += new string('0', num2.Length - i - 1);
            res = _add(tmp, res);
        }
        
        return res;
    }

    private string _add(string a, string b)
    {
        int flag = 0;
        int index1 = a.Length-1;
        int index2 = b.Length-1;
        string res = "";
        while (index1 >= 0 || index2 >= 0)
        {
            int sum = 0;
            if (index1 >=0)
                sum += a[index1] - '0';
            if (index2 >=0)
                sum += b[index2] - '0';
            sum += flag;
            flag = sum / 10;
            res = sum % 10 + res;
            index1--;
            index2--;
        }
        if (flag != 0)
            res = flag + res;
        return res;
    }
    #endregion

    #region 乘法解法

    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";
        int[] resArr = new int[num1.Length+num2.Length];
        for (int i = num1.Length-1; i >=0 ; i--)
        {
            for (int j = num2.Length-1; j >=0 ; j--)
            {
                int pro = (num1[i] - '0') * (num2[j] - '0');
                resArr[i + j + 1] += pro;
            }
        }

        for (int i = resArr.Length-1; i >=0 ; i--)
        {
            if (resArr[i] > 9)
            {
                int flag = resArr[i] / 10;
                resArr[i] %= 10;
                resArr[i - 1] += flag;
            }
        }

        var res = string.Concat(resArr);
        if (resArr[0] == 0)
            res = res.Substring(1, resArr.Length - 1);
        return res;
    }

    #endregion
}