namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_05
{
    public static void Test()
    {
        LeetCode_01_05 obj = new LeetCode_01_05();
        Console.WriteLine(obj.OneEditAway("pale","ple"));
        Console.WriteLine(obj.OneEditAway("pales","pal"));
        Console.WriteLine(obj.OneEditAway("",""));
        Console.WriteLine(obj.OneEditAway("aa",""));
        Console.WriteLine(obj.OneEditAway("abc","ac"));
        Console.WriteLine(obj.OneEditAway("abcd","aec"));
    }
    
    public bool OneEditAway(string first, string second)
    {
        if (first.Length < second.Length) 
            (first, second) = (second, first);
        if (first.Length - second.Length > 1) return false;
        bool flag = false;
        for (int i = 0,j=0; i < first.Length; i++)
        {
            if (j == second.Length) return !flag;
            if (first[i] == second[j]) j++;
            else
            {
                if (flag) return false;
                if (first.Length == second.Length)
                    j++;
                flag = true;
            }
        }

        return true;
    }
}