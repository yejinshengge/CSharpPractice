using System.Text;

namespace CSharpPractice.C_._03_网络.TCPServer;

public class Process
{
    public static void ProcessMain()
    {
        TcpServer server = new TcpServer();
        server.Start();

        while (true)
        {
            var str = Console.ReadLine();
            server.curClient.Send(Encoding.UTF8.GetBytes(str));
        }
    }
}