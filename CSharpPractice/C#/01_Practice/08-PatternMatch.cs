using System.Numerics;

namespace CSharpPractice.Class01;

public class PatternMatch {
    public static void PatternMatchMain()
    {
        // 顺序模式匹配
        PatternMatch ma = new PatternMatch(){_firstName = "花泽",_lastName = "香菜"};
        if (ma is (string firstName1, string lastName1))
        {
            Console.WriteLine($"顺序模式匹配{firstName1},{lastName1}");
        }
        // 属性模式匹配
        if (ma is {_firstName: string firstName2, _lastName: string lastName2})
        {
            Console.WriteLine($"属性模式匹配{firstName2},{lastName2}");
        }
        // 递归模式匹配
        var person = (FirstName: "石原", LastName: "里美");
        (PatternMatch per1, (string FirstName, string LastName) per2) laopo = (ma, person);
        if (laopo is 
            (({Length: int len}, _), {FirstName: string firstName3})
            )
        {
            Console.WriteLine($"递归模式匹配{len},{firstName3}");
        }
        // 使用as操作符进行转换
        PatternMatch? match = ma as PatterMatchChild;
        if (match is not null)
        {
            Console.WriteLine("转换成功");
        }
        else
        {
            Console.WriteLine("转换失败");
        }
    }

    private string _firstName;
    private string _lastName;
    // 用is操作符进行模式匹配
    public static void Print(object data)
    {
        if (data is string)
        {
            string text = (string) data;
            Console.WriteLine(text);
        }
        // 类型模式匹配
        else if (data is Vector3 vector3)
        {
            Console.WriteLine(vector3.X+",",vector3.Y+",",vector3.Z);
        }
        // 常量模式匹配
        else if (data is 2)
        {
            Console.WriteLine(2);
        }
        else if(data is null)
        {
            Console.WriteLine("data是空值");
        }
        // 元组模式匹配
        else if (data is (1, "hhh"))
        {
            Console.WriteLine("data是元组(1,hhh)");
        }
        // 在模式匹配中使用var
        else if (data is var res)
        {
            // 等同于 var res = data
        }

    }
    // 解构函数
    public void Deconstruct(out string firstName, out string lastName) =>
        (firstName, lastName) = (_firstName, _lastName);

}

public class PatterMatchChild : PatternMatch
{
    
}