using System.Linq.Expressions;

namespace CSharpPractice.Class01;

public class LambdaExpression {
    
    public static void LambdaExpressionMain()
    {
        Person person1 = new Person() {Age = 10, Name = "张三"};
        Person person2 = new Person() {Age = 20, Name = "李四"};
        
        PrintGreater(person1,person2,(p1,p2)=> p1.Age > p2.Age);
        
        PrintGreater(person1,person2,LambdaExpression.b__0_0);

        int num = 10;
        Action<int,int> action = (a,b) => Console.WriteLine(a+b+num);
        action(3,5);

        __LocalDisplayClass_00001 local = new __LocalDisplayClass_00001();
        local.num = 10;
        local.__AnonymousMethod_00001(3,5);

        Func<int, int> func = x => x + 1;
        Expression<Func<int, int>> exp = x => x + 1;
        Console.WriteLine(func);
        Console.WriteLine(exp);

        Expression a = Expression.Variable(typeof(int), "a");
        Expression b = Expression.Variable(typeof(int), "b");
        Expression ex = Expression.Add(a,b);
        // 输出 (a + b)
        Console.WriteLine(ex);

        Expression<Func<int,int,int>> ex2 = (a,b) => a + b;
        // 输出 (a + b)
        Console.WriteLine(ex2.Body);
        
        Func<int,int,int> fun = (a,b) => a + b;

        List<Person> pers = new List<Person>();
        pers.Add(new Person(){Age = 10,Name = "张三"});
        pers.Add(new Person(){Age = 20,Name = "李四"});
        pers.Add(new Person(){Age = 30,Name = "王五"});
        IQueryable<Person> persons = new EnumerableQuery<Person>(pers);
        
        var newPersons = persons.Where(person => person.Age >= 20);
        Console.WriteLine(newPersons);
    }
    
    private sealed class __LocalDisplayClass_00001
    {
        public int num;

        public void __AnonymousMethod_00001(int a, int b)
        {
            Console.WriteLine(a+b+num);
        }
    }
    // 自动生成的静态方法
    private static bool b__0_0(Person person1, Person person2)
    {
        return person1.Age > person2.Age;
    }

    /**
     * 输出较大的对象
     */
    public static void PrintGreater<T>(T item1,T item2,Func<T,T,bool> compare)
    {
        Console.WriteLine(compare(item1, item2) ? item1:item2);
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public override string ToString()
        {
            return $"姓名:{Name},年龄:{Age}";
        }
    }
    
    
}