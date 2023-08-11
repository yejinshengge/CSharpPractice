namespace CSharpPractice.Class01;

public class DelegatePractice
{

    // 声明委托
    delegate string TestDelegate(int a, int b);
    
    delegate string Test1Delegate(int a, int b);
    delegate string Test2Delegate(int a, int b);
    
    public static void DelegatePracticeMain()
    {
        TestDelegate testDelegate = null;
        // 绑定方法
        testDelegate = Test;
        // 执行方法
        Console.WriteLine(testDelegate(10,20));

        Func<int, int, string> testFunc = Test;
        Console.WriteLine(testFunc(20,30));
        Action<int> testAct = VoidTest;
        testAct(50);

        Person person1 = new Person() {Age = 10, Name = "张三"};
        Person person2 = new Person() {Age = 20, Name = "李四"};
        
        PrintGreater(person1,person2,PersonCompare);

        Test1Delegate test1Delegate = Test;
        Test2Delegate test2Delegate = test1Delegate.Invoke;
        
        // 逆变
        Action<object> objAction = o => Console.WriteLine(o);
        Action<string> strAction = objAction;

        // 协变
        Func<string> strFunc = () => "strFunc";
        Func<object> objFunc = strFunc;
        
        // 协变与逆变同时发生
        Func<object, string> objStrFunc = o => o.ToString();
        Func<string, object> strObjFunc = objStrFunc;


    }

    public static string Test(int a, int b)
    {
        return $"a + b = {a + b}";
    }

    public static void VoidTest(int a)
    {
        Console.WriteLine($"a is {a}");
    }
    
    /**
     * 比较方法
     */
    public static bool PersonCompare(Person person1, Person person2)
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
