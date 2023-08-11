using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.初级算法;

/**
给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。
最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
你可以假设除了整数 0 之外，这个整数不会以零开头。
 */
public class LeetCode_007 {

    public static void LeetCode_007Main()
    {
        LeetCode_007 obj = new LeetCode_007();
        Util.Tools.PrintArr(obj.PlusOne2(new []{1,2,3}));
    }
    
    // 借助list
    public int[] PlusOne(int[] digits)
    {
        int index = digits.Length-1;
        int flag = 1;
        List<int> res = new List<int>(digits.Length + 1);
        
        while (index >= 0)
        {
            int num = digits[index] + flag;
            if (num > 9)
            {
                res.Add(num%10);
                flag = 1;
            }
            else
            {
                res.Add(num);
                flag = 0;
            }
            index--;
        }
        if(flag != 0)
            res.Add(1);
        res.Reverse();
        return res.ToArray();
    }

    // 优化
    public int[] PlusOne2(int[] digits)
    {
        for (int i = digits.Length-1; i >= 0; i--)
        {
            if (digits[i] != 9)
            {
                digits[i]++;
                return digits;
            }
            else
            {
                digits[i] = 0;
            }
        }

        int[] temp = new int[digits.Length + 1];
        temp[0] = 1;
        return temp;
    }
}