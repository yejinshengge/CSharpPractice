namespace CSharpPractice.LeetCode.动态规划;

public class LeetCode_1387
{
    public static void Test()
    {
        LeetCode_1387 obj = new LeetCode_1387();
        Console.WriteLine(obj.GetKth(12,15,2));
        Console.WriteLine(obj.GetKth(7,11,4));
        Console.WriteLine(obj.GetKth(1,1000,4));
    }
    
    public int GetKth(int lo, int hi, int k)
    {
        Dictionary<int, int> dic = new();
        dic[1] = 0;
        int[] arr = new int[hi - lo + 1];
        int index = 0;
        for (int i = lo; i <= hi; i++)
        {
            arr[index++] = i;
        }
        
        Array.Sort(arr, (a, b) =>
        {
            var aP = _getPriority(dic, a);
            var bP = _getPriority(dic, b);
            if (aP != bP)
                return aP - bP;
            return a - b;
        });
        return arr[k-1];
    }

    private int _getPriority(Dictionary<int, int> dic, int num)
    {
        if (dic.ContainsKey(num)) return dic[num];
        if (num % 2 == 0)
            dic[num] = _getPriority(dic, num / 2)+1;
        else
            dic[num] = _getPriority(dic, 3 * num + 1)+1;
        return dic[num];
    }
}