using System;
using System.ComponentModel;

public class AboutNull
{
    public static void AboutNullMain()
    {
        string? uri = null;
        
        // 检查null值的方式
        if (uri == null)
        {
            Console.WriteLine("uri == null uri是空的");
        }

        if (object.ReferenceEquals(uri, null))
        {
            Console.WriteLine("object.ReferenceEquals(uri, null) uri是空的");
        }

        if (uri is null)
        {
            Console.WriteLine("uri is null uri是空的");
        }
        
        if (uri is not {})
        {
            Console.WriteLine("uri is not {} uri是空的");
        }
        
        // 空合并操作符
        string str = uri ?? uri ?? uri ?? uri ?? "default";
        Console.WriteLine(str);
        
        // 空合并赋值
        string? str2 = null;
        str2 ??= "default";
        str2 ??= "default2";
        Console.WriteLine(str2);
        
        // 声明数组及其元素可空
        string?[]? strings = null;
        
        // 空包容操作符
        uri = string.Join('/', strings!);


    }
    
}
