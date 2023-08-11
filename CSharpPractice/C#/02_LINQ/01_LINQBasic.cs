namespace CSharpPractice.C_._02_LINQ;

public class LINQBasic {
    
    public static void LINQBasicMain()
    {
        // 条件查询语句
        string[] names = {"Tom","John","Mary","LiHua","ZhangSan"};
        IEnumerable<string> res = names
            .Where(e => e.Contains("o"))
            .OrderBy(e => e.Length)
            .Select(e=>e.ToUpper());

        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
        // 输出结果:
        // TOM
        // JOHN
        Console.WriteLine("______________________");
        
        // Take运算符
        var res1 = names.Take(3);
        foreach (var item in res1)
        {
            Console.WriteLine(item);
        }
        // 输出结果:
        // Tom
        // John
        // Mary
        Console.WriteLine("______________________");
        
        // Skip运算符
        var res2 = names.Skip(3);
        foreach (var item in res2)
        {
            Console.WriteLine(item);
        }
        // 输出结果:
        // LiHua
        // ZhangSan
        Console.WriteLine("______________________");
        
        // Reverse运算符
        var res3 = names.Reverse();
        foreach (var item in res3)
        {
            Console.WriteLine(item);
        }
        // 输出结果:
        // ZhangSan
        // LiHua
        // Mary
        // John
        // Tom
        Console.WriteLine("______________________");
        
        var item1 = names.First(); // Tom
        var item2 = names.Last(); // ZhangSan
        var item3 = names.ElementAt(3); // LiHua

        Console.WriteLine(item1);
        Console.WriteLine(item2);
        Console.WriteLine(item3);
        
        Console.WriteLine("______________________");

        var count = names.Count();// 5
        var min = names.Min();// John
        var max = names.Max();// ZhangSan

        Console.WriteLine(count);
        Console.WriteLine(min);
        Console.WriteLine(max);
        
        Console.WriteLine("______________________");
        var isContains = names.Contains("ZhangSan"); // True
        var isAny = names.Any(e => e.Equals("John")); // True

        Console.WriteLine(isContains);
        Console.WriteLine(isAny);
        
        Console.WriteLine("______________________");
        int[] seq1 = {1, 2, 3};
        int[] seq2 = {3, 4, 5};

        var seq3 = seq1.Concat(seq2);// 1,2,3,3,4,5
        var seq4 = seq1.Union(seq2);// 1,2,3,4,5

        Console.WriteLine("______________________");
        
        IEnumerable<string> query =
            from name in names
            where name.Contains("o")
            orderby name.Length
            select name.ToUpper();

        foreach (var item in query)
        {
            Console.WriteLine(item);
        }

        // 输出结果:
        // TOM
        // JOHN

    }
    
}