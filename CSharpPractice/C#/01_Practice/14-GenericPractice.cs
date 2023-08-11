namespace CSharpPractice.Class01;

public class GenericPractice {
    public static void GenericPracticeMain()
    {
        List<string> strList = new List<string>(){"aaa","bbb"};
        // 假设合法
        // List<object> objList = strList;
        IReadOnlyList<object> objList = strList;
        List<object> objList2 = new List<object>(){1,2,"sdada"};
        //List<string> strList2 = objList2;


        IExample<Fruit> fruit = new ExampleClass<Fruit>(){Item = new Orange()};
        IExample<Apple> apple = fruit;
        

    }
    
    public class Fruit { }
    public class Apple:Fruit { }
    public class Orange:Fruit { }
    public interface IExample<in T>
    {
        public T Item { set; }
    }
    public class ExampleClass<T> : IExample<T>
    {
        public T Item { get; set; }
    }
    
}  