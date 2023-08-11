namespace CSharpPractice.Class01;

public class Param {
    public static void ParamMain()
    {
        // 引用参数
        string s1 = "第一个字符串";
        string s2 = "第二个字符串";
        Swap1(s1,s2);
        Console.WriteLine(s1+s2);
        Swap2(ref s1,ref s2);
        Console.WriteLine(s1+s2);
        
        // 输出参数
        Console.WriteLine("---------------------------");
        string s3 = "第一个字符串";
        string s4 = "第二个字符串";
        Merge(s3,s4,out string res);
        Console.WriteLine(res);
        
        // 只读传引用
        Console.WriteLine("---------------------------");
        Console.WriteLine(Method(100));
        
        // 返回引用
        Console.WriteLine("---------------------------");
        string[] strs = {"123", "456"};
        ref string str = ref FindStr(strs);
        str = "789";
        Console.WriteLine(strs[0]+" "+strs[1]);
        
        // 参数数组
        Console.WriteLine("---------------------------");
        PrintStr("str1","str2","str3");
        PrintStr(new []{"str4","str5"});
        
        // 可选参数
        Console.WriteLine("---------------------------");
        PrintStr2("str1");
        PrintStr2("str1","str2");
    }

    private static void Swap1(string s1, string s2)
    {
        (s1, s2) = (s2, s1);
    }
    private static void Swap2(ref string s1,ref string s2)
    {
        (s1, s2) = (s2, s1);
    }

    private static void Merge(string s1, string s2, out string res)
    {
        res = s1 + s2;
    }

    private static int Method(in int number)
    {
        //number++;
        return number;
    }
    
    private static ref string FindStr(string[] strs)
    {
        return ref strs[0];
    }

    private static void PrintStr(params string[] strs)
    {
        foreach (var str in strs)
        {
            Console.WriteLine(str);
        }
    }
    
    private static void PrintStr2(string str1,string str2="hhhhhh")
    {
        Console.WriteLine(str1);
        Console.WriteLine(str2);
    }
}
