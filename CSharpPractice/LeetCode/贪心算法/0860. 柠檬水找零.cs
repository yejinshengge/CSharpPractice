namespace CSharpPractice.LeetCode.贪心算法;

/**
在柠檬水摊上，每一杯柠檬水的售价为 5 美元。顾客排队购买你的产品，（按账单 bills 支付的顺序）一次购买一杯。

每位顾客只买一杯柠檬水，然后向你付 5 美元、10 美元或 20 美元。你必须给每个顾客正确找零，也就是说净交易是每位顾客向你支付 5 美元。

注意，一开始你手头没有任何零钱。

给你一个整数数组 bills ，其中 bills[i] 是第 i 位顾客付的账。如果你能给每位顾客正确找零，返回 true ，否则返回 false 。
 */
public class LeetCode_0860
{
    public static void Test()
    {
        LeetCode_0860 obj = new LeetCode_0860();
        Console.WriteLine(obj.LemonadeChange(new []{5,5,5,10,20}));
        Console.WriteLine(obj.LemonadeChange(new []{5,5,10,10,20}));
        Console.WriteLine(obj.LemonadeChange(new []{5,5,10,20,5,5,5,5,5,5,5,5,5,10,5,5,20,5,20,5}));
    }
    
    public bool LemonadeChange(int[] bills)
    {
        int[] moneys = new[] { 0, 0, 0 };
        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 5)
                moneys[0]++;
            else if (bills[i] == 10)
            {
                moneys[1]++;
                moneys[0]--;
            }
            else if (bills[i] == 20)
            {
                moneys[2]++;
                if (moneys[1] > 0)
                {
                    moneys[0]--;
                    moneys[1]--;
                }
                else
                {
                    moneys[0]-=3;
                }

            }
            if (moneys[0] < 0 || moneys[1]<0) return false;
        }

        return true;
    }
}