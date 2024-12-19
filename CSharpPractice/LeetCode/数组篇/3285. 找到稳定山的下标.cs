using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.数组篇;

public class LeetCode_3285
{
    public static void Test()
    {
        LeetCode_3285 obj = new LeetCode_3285();
        Tools.PrintEnumerator(obj.StableMountains(new []{1,2,3,4,5},2));
        Tools.PrintEnumerator(obj.StableMountains(new []{10,1,10,1,10},3));
        Tools.PrintEnumerator(obj.StableMountains(new []{10,1,10,1,10},10));
    }
    
    public IList<int> StableMountains(int[] height, int threshold)
    {
        IList<int> res = new List<int>();
        for (int i = 1; i < height.Length; i++)
        {
            if(height[i-1] >threshold)
                res.Add(i);
        }

        return res;
    }
}