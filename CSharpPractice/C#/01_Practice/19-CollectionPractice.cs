using System.Collections;

namespace CSharpPractice.Class01;

public class CollectionPractice {
    
    public static void CollectionPracticeMain()
    {
        List<string> strList = new List<string>()
        {
            "Apple", "Orange", "Pear"
        };
        
        strList.Add("das");

        int[] arr = new[] { 1,2,3,4 };
        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }

        Stack<int> stack = new Stack<int>();


    }

    private void BeforeChange()
    {
        int[] arr = new[] { 1,2,3,4 };
        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }
    }

    private void AfterChange()
    {
        int[] tempArr;
        int[] arr = new[] {1, 2, 3, 4};

        tempArr = arr;
        for (int counter = 0; counter < tempArr.Length; counter++)
        {
            int item = tempArr[counter];
            Console.WriteLine(item);
        }
    }
    

}