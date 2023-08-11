using System;

public class MyArray
{
    public static void MyArrayMain()
    {
        int[] arr1 = {11, 32, 542, 12};
        // 多维数组
        int[,] arr2 =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        Console.WriteLine("arr2的长度:"+arr2.Length);
        
        // 反向访问数组
        Console.WriteLine(arr1[^3]);
        // 区间
        Console.WriteLine("数组切片:"+string.Join(",",arr1[0..^0]));
        
        // 交错数组
        int[][] arr3 = new[]
        {
            new[] {1, 2, 3},
            new[] {1, 2, 3, 4},
            new[] {1, 2, 3, 4, 5}
        };
        Console.WriteLine("arr3的长度:"+arr3.Length);
        
        // 索引类型
        Index index = ^42;// int:Value,bool:IsFromEnd
        // 区间类型
        Range range = ..;// Index:Start,Index:End
    }
}
