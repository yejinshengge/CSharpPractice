namespace CSharpPractice.LeetCode.字符串;

/**
字符串的左旋转操作是把字符串前面的若干个字符转移到字符串的尾部。
请定义一个函数实现字符串左旋转操作的功能。比如，输入字符串"abcdefg"和数字2，该函数将返回左旋转两位得到的结果"cdefgab"。
 */
public class LeetCode_Offer58
{
    public static void Test()
    {
        LeetCode_Offer58 obj = new LeetCode_Offer58();
        Console.WriteLine(obj.ReverseLeftWords2("abcdefg",2));
        Console.WriteLine(obj.ReverseLeftWords2("lrloseumgh",6));
    }

    public string ReverseLeftWords(string s, int n)
    {
        int len = s.Length;
        var arr = new char[len];

        int index = n;
        int arrIndex = 0;
        while (index < len)
        {
            arr[arrIndex++] = s[index++];
        }

        index = 0;
        while (index<n)
        {
            arr[arrIndex++] = s[index++];
        }

        return new string(arr);
    }

    public string ReverseLeftWords2(string s, int n)
    {
        var arr = s.ToCharArray();
        Reverse(arr,0,n-1);
        Reverse(arr,n,s.Length-1);
        Reverse(arr,0,s.Length-1);
        return new string(arr);
    }

    public void Reverse(char[] arr, int left, int right)
    {
        while (left<right)
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }
    }
}