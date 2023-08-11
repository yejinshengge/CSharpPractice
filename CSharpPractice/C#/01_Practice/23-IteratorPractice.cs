using System.Collections;

namespace CSharpPractice.Class01;

public class IteratorPractice {
    
    public static void IteratorPracticeMain()
    {
        var fruit = new Fruit();
        foreach (var f in fruit)
        {
            Console.WriteLine(f);
        }
        Console.WriteLine("——————————————————————————————————————————");
        var binaryTree = new BinaryTree<string>("A")
        {
            SubItems = new Pair<BinaryTree<string>>(
                new BinaryTree<string>("B")
            {
                SubItems = new Pair<BinaryTree<string>>(new BinaryTree<string>("C"), new BinaryTree<string>("D"))
            },
                new BinaryTree<string>("E")
            {
                SubItems = new Pair<BinaryTree<string>>(new BinaryTree<string>("F"), new BinaryTree<string>("G"))
            })
        };
        foreach (var item in binaryTree)
        {
            Console.WriteLine(item);
        }
    }
    
    private class Fruit:IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Apple";
            yield return "Orange";
            yield return "Banana";
            yield return "Pear";
            yield return "Strawberry";
        }
        
        // 因为IEnumerable<T>派生自IEnumerable,所以需要同时实现非泛型版本
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BinaryTree<T> : IEnumerable<T>
    {
        private T Value { get; }
        public Pair<BinaryTree<T>>? SubItems { get; init; }
        
        public BinaryTree(T value)
        {
            Value = value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
            if (SubItems != null)
                foreach (var item in SubItems)
                {
                    foreach (var e in item)
                    {
                        yield return e;
                    }
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Pair<T> : IEnumerable<T>
    {
        private T First { get; }
        private T Second { get; }

        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return First;
            yield return Second;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    private class MonoExample
    {
        IEnumerator Start()
        {
            yield break;
        }
        
        
    }
}