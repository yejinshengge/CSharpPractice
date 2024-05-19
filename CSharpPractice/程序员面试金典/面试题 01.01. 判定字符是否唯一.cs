namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_01
{
    public static void Test()
    {
        LeetCode_01_01 obj = new LeetCode_01_01();
        Console.WriteLine(obj.IsUnique("leetcode"));
        Console.WriteLine(obj.IsUnique("abc"));
    }
    
    // 排序遍历
    public bool IsUnique1(string astr)
    {
        var array = astr.ToCharArray();
        Array.Sort(array);
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1]) return false;
        }

        return true;
    }
    
    // 位运算
    public bool IsUnique(string astr)
    {
        int map = 0;
        foreach (var c in astr)
        {
            var moveBit = 1 << (c - 'a');
            if ((map & moveBit) != 0)
                return false;
            map |= moveBit;
        }

        return true;
    }
}