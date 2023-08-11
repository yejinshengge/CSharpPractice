using System.Net.Sockets;

namespace CSharpPractice.C_._03_网络.TCPServer;

public class TcpServer
{
    private TcpListener _listener;
    public Client curClient { get; private set; }
    public void Start()
    {
        try
        {
            _listener = TcpListener.Create(1234);
            // 指定最大连接数
            _listener.Start(100);
            Console.WriteLine("TCP Server 启动成功!");
            Accept();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async void Accept()
    {
        try
        {
            TcpClient tcpClient = await _listener.AcceptTcpClientAsync();
            Console.WriteLine("客户端已连接："+tcpClient.Client.RemoteEndPoint);
            curClient = new Client(tcpClient);
            Accept();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _listener.Stop();
        }
    }
    
}