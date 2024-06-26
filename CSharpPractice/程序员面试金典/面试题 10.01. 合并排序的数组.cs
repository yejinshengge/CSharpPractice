namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_01
{
    public static void Test()
    {
        LeetCode_10_01 obj = new LeetCode_10_01();
        //obj.Merge(new []{1,2,3,0,0,0},3,new []{2,5,6},3);
        obj.Merge(new []{0},0,new []{1},1);
        //obj.Merge(Array.Empty<int>(),0,Array.Empty<int>(),0);
    }
    
    public void Merge(int[] a, int m, int[] b, int n)
    {
        int aIndex = m-1, bIndex = n-1,arrIndex = m+n-1;
        for (int i = arrIndex; i >=0; i--)
        {
            if(aIndex >=0 && bIndex >= 0)
                a[i] = a[aIndex] > b[bIndex] ? a[aIndex--] : b[bIndex--];
            else if (aIndex >= 0)
                a[i] = a[aIndex--];
            else
                a[i] = b[bIndex--];
        }
        
    }
}