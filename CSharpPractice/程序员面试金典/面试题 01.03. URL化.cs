namespace CSharpPractice.程序员面试金典;

public class LeetCode_01_03
{
    public static void Test()
    {
        LeetCode_01_03 obj = new LeetCode_01_03();
        // Console.WriteLine(obj.ReplaceSpaces("Mr John Smith    ",13));
        // Console.WriteLine(obj.ReplaceSpaces("               ",5));
        Console.WriteLine(obj.ReplaceSpaces("ds sdfs afs sdfa dfssf asdf             ",27));
    }
    
    public string ReplaceSpaces(string s, int length)
    {
        var array = s.ToCharArray();
        int index = array.Length - 1;
        for (int i = length-1; i >=0; i--)
        {
            if (array[i] == ' ')
            {
                array[index--] = '0';
                array[index--] = '2';
                array[index--] = '%';
            }
            else
                array[index--] = array[i];
        }

        return new string(array,index+1,array.Length - index -1);
    }
}