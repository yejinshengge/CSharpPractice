using System.Globalization;

namespace CSharpPractice.LeetCode.模拟;

public class LeetCode_0468
{
    public static void Test()
    {
        LeetCode_0468 obj = new LeetCode_0468();
        Console.WriteLine(obj.ValidIPAddress("192.168.01.1"));// 0
        Console.WriteLine(obj.ValidIPAddress("192.168.1.00"));// 0
        Console.WriteLine(obj.ValidIPAddress("192.168@1.1"));// 0
        Console.WriteLine(obj.ValidIPAddress("2001:0db8:85a3:0000:0000:8a2e:0370:7334"));// 1
        Console.WriteLine(obj.ValidIPAddress("2001:db8:85a3:0:0:8A2E:0370:7334"));// 1
        Console.WriteLine(obj.ValidIPAddress("2001:0db8:85a3::8A2E:037j:7334"));// 0
        Console.WriteLine(obj.ValidIPAddress("02001:0db8:85a3:0000:0000:8a2e:0370:7334"));// 0
        Console.WriteLine(obj.ValidIPAddress("172.16.254.1"));// 1
        Console.WriteLine(obj.ValidIPAddress("2001:0db8:85a3:0:0:8A2E:0370:7334"));// 1
        Console.WriteLine(obj.ValidIPAddress("256.256.256.256"));// 0
    }
    
    public string ValidIPAddress(string queryIP)
    {
        string[] arr = queryIP.Split('.');
        // 校验IPV4
        if (arr.Length == 4)
        {
            foreach (var s in arr)
            {
                if (!int.TryParse(s, out int value) || value < 0 || value > 255)
                {
                    return "Neither";
                }
                if(s.Length > 1 && s[0] == '0')
                    return "Neither";
            }
            return "IPv4";
        }
        arr = queryIP.Split(':');
        // 校验IPV6
        if (arr.Length == 8)
        {
            foreach (var s in arr)
            {
                if(s.Length < 1 || s.Length > 4)
                    return "Neither";
                if(!int.TryParse(s,NumberStyles.HexNumber,null,out int val))
                    return "Neither";
            }

            return "IPv6";
        }

        return "Neither";
    }
}