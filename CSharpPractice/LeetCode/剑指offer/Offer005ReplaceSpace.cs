using System.Text;

namespace CSharpPractice.LeetCode;

public class Offer005ReplaceSpace
{
    public static void Offer005ReplaceSpaceMain()
    {
        Offer005ReplaceSpace obj = new();
        obj.Test();
    }

    private void Test()
    {
        List<string> inputs = new() {"We are happy.","   ","","abc"};
        List<string> results = new() {"We%20are%20happy.", "%20%20%20", "", "abc"};
        for (int i = 0; i < inputs.Count; i++)
        {
            if (results[i].Equals(ReplaceSpace(inputs[i])))
            {
                Console.WriteLine($"第{i}条,成功");
            }
            else
            {
                Console.WriteLine($"第{i}条,失败");
            }
        }
    }
    
    public string ReplaceSpace(string s)
    {
        StringBuilder builder = new(s.Length);
        foreach (var t in s)
        {
            if (t.Equals(' '))
            {
                builder.Append("%20");
            }
            else
            {
                builder.Append(t);
            }
        }
        return builder.ToString();
    }
}