using System.Reflection;

namespace CSharpPractice.Class01
{

    public class ReflectPractice
    {
        public static void ReflectPracticeMain()
        {

            Type type = typeof(string);
            // 类型名称
            string typeName = type.Name;
            // 类型是否public
            bool typeIsPublic = type.IsPublic;
            // 类型的基类
            Type? baseType = type.BaseType;
            // 类型实现的接口
            Type[] interfaces = type.GetInterfaces();
            // 类型在哪个程序集定义
            Assembly typeAssembly = type.Assembly;
            // 类型的属性
            PropertyInfo[] properties = type.GetProperties();
            // 类型的方法
            MethodInfo[] methods = type.GetMethods();
            // 类型的字段
            FieldInfo[] fields = type.GetFields();
            // 类型的特性
            IEnumerable<Attribute> attributes = type.GetCustomAttributes();

            Type stuType = typeof(Student);

            var constructors = stuType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            var constructor = Array.Find(constructors, c => c.GetParameters().Length == 2);
            if (constructor != null)
            {
                Student student = (Student) constructor.Invoke(new object[] {"李四", 12});
                student.PrintStudent();
            }

            var type1 = typeof(MyList<>);
            Console.WriteLine(type1.ContainsGenericParameters);
            Console.WriteLine(type1.IsGenericType);

            var type2 = typeof(Action<int, float, string>);
            Console.WriteLine(type2.ContainsGenericParameters);
            Console.WriteLine(type2.IsGenericType);

            Type[] genericArguments = type2.GetGenericArguments();

            foreach (var argument in genericArguments)
            {
                Console.WriteLine($"param:{argument.FullName}");
            }
        }

        class MyList<T>
        {
            public void Add(T item)
            {
                var type = typeof(T);
                if (type == typeof(int))
                {
                    // ...
                }
            }
        }

        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Student()
            {
                Name = "AAA";
                Age = 12;
            }

            public Student(string name)
            {
                Name = name;
            }

            private Student(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void PrintStudent()
            {
                Console.WriteLine($"姓名：{Name} 年龄：{Age}");
            }

        }
    }
}