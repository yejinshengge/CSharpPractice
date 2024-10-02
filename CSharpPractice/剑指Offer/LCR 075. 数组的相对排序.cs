using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR075
{
    public static void Test()
    {
        LeetCode_LCR075 obj = new LeetCode_LCR075();
        Tools.PrintArr(obj.RelativeSortArray(new []{2,3,1,3,2,4,6,7,9,2,19},new []{2,1,4,3,9,6}));
    }
    
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        int[] dic = new int[1001];
        foreach (var num in arr1)
        {
            dic[num]++;
        }

        int[] res = new int[arr1.Length];
        int index = 0;
        foreach (var num in arr2)
        {
            while (dic[num] > 0)
            {
                res[index++] = num;
                dic[num]--;
            }
        }
        
        for (var i = 0; i < dic.Length; i++)
        {
            while (dic[i] > 0)
            {
                res[index++] = i;
                dic[i]--;
            }
        }

        return res;
    }
}