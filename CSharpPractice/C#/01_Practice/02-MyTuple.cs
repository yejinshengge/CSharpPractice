
using System;

public class MyTuple
{
    public static void MyTupleMain()
    {
        // 将元组赋给单独声明的变量
        (string country1,string capital1,double gdp1) = ("China", "Beijing", 10000);
        Console.WriteLine($@"{country1},{capital1},{gdp1}");
        
        // 将元组赋给预声明的变量
        string country2;
        string capital2;
        double gdp2;
        (country2,capital2,gdp2) = ("China", "Beijing", 10000);
        Console.WriteLine($@"{country2},{capital2},{gdp2}");
        
        // 将元组赋值给单独声明和隐式类型的变量
        (var country3,var capital3,var gdp3) = ("China", "Beijing", 10000);
        Console.WriteLine($@"{country3},{capital3},{gdp3}");
        
        // 将元组赋值给单独声明和隐式类型的变量
        var ( country4, capital4, gdp4) = ("China", "Beijing", 10000);
        Console.WriteLine($@"{country4},{capital4},{gdp4}");
        
        // 声明具名元组,将元组赋值给它,按名称访问元组
        (string country5,string capital5,double gdp5) info = ("China", "Beijing", 10000);
        Console.WriteLine($@"{info.country5},{info.capital5},{info.gdp5}");
        
        // 声明包含具名元组项的元组,将其赋值给隐式类型变量,通过项目编号属性访问单独的元素
        var info2 = (country6:"China", capital6:"Beijing", gdp6:10000);
        Console.WriteLine($@"{info2.country6},{info2.capital6},{info2.gdp6}");
        
        // 将元组项未具名的元组赋值给隐式类型变量
        var info3 = ("China", "Beijing", 10000);
        Console.WriteLine($@"{info3.Item1},{info3.Item2},{info3.Item3}");
        
        // 赋值时使用下划线丢弃元组的一部分
        (string country7,_,double gdp7) = ("China", "Beijing", 10000);
        
        // 通过变量和属性名推断元组项目名称
        string country8 = "China";
        string capital8 = "Beijing";
        double gdp8 = 10000;
        var info4 = (country8, capital8, gdp8);
        Console.WriteLine($@"{info4.country8},{info4.capital8},{info4.gdp8}");

        System.ValueTuple<string, string, double> tuple = (country8, capital8, gdp8);
        Console.WriteLine($@"{tuple.Item1},{tuple.Item2},{tuple.Item3}");
    }
}
