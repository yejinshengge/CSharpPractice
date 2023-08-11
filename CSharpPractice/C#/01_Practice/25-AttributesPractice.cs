#define IsShowMessage
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CSharpPractice.Class01
{

    public class AttributesPractice
    {


        [Serializable]
        class SampleClass
        {
            // ...
            [Obsolete("该方法已被弃用", true)]
            public static void Test()
            {

            }

            [Conditional("IsShowMessage")]
            public static void Test2()
            {
                Console.WriteLine("调试信息。。。。");
            }

            public static void Test3(String message, [CallerLineNumber] int lineNum = 0
                , [CallerFilePath] string path = "", [CallerMemberName] string name = "")
            {
                Console.WriteLine(message);
                Console.WriteLine(lineNum);
                Console.WriteLine(path);
                Console.WriteLine(name);
            }

            [DebuggerStepThrough]
            public static void Test4()
            {
                Console.WriteLine("调试信息。。。。");
            }
        }

        public static void AttributesPracticeMain()
        {
            SampleClass.Test3("调用Test3");
            AttributeTest.AttributeTestMain();
        }

        [AttributeUsage(AttributeTargets.Class)]
        public sealed class ClassInfoAttribute : Attribute
        {
            public string Author { get; }
            public string CreateDate { get; }
            public string Description { get; }

            public ClassInfoAttribute(string author, string createDate, string description)
            {
                Author = author;
                CreateDate = createDate;
                Description = description;
            }
        }

        [ClassInfo("张三", "2022/08/13", "这是一个自定义特性测试类")]
        class AttributeTest
        {
            public static void AttributeTestMain()
            {
                var type = typeof(AttributeTest);
                // 是否定义了ClassInfoAttribute特性
                if (type.IsDefined(typeof(ClassInfoAttribute), false))
                {
                    var customAttributes = type.GetCustomAttributes(false);
                    if (customAttributes is {Length: > 0})
                    {
                        var classInfo =
                            Array.Find(customAttributes, item => item is ClassInfoAttribute) as ClassInfoAttribute;
                        Console.WriteLine(
                            $"Author: {classInfo?.Author} Date: {classInfo?.CreateDate} Des: {classInfo?.Description}");
                    }
                }
            }
        }
    }
}