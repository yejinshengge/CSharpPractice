using System.Net;

namespace CSharpPractice.C_._03_网络;

public class IpAddressPractice {

    public static void IpAddressPracticeMain()
    {
        // IP地址
        IPAddress a1 = new IPAddress(new byte[] {101, 102, 103, 104});
        IPAddress a2 = IPAddress.Parse("101.102.103.104");
        Console.WriteLine(a1.Equals(a2));
        Console.WriteLine(a1.AddressFamily);
        
        IPAddress a3 = IPAddress.Parse("[3EA0:FFFF:198A:E4A3:4FF2:54fA:41BC:8D31]");
        Console.WriteLine(a3.AddressFamily);
        
        // 端口
        IPEndPoint ep = new IPEndPoint(a1, 222);
        Console.WriteLine(ep.ToString());
    }
}