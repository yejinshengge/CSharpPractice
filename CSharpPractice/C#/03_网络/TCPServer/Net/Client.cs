using System.Net.Sockets;
using System.Text;

namespace CSharpPractice.C_._03_网络.TCPServer;

public class Client
{
    private TcpClient _client;

    public Client(TcpClient client)
    {
        _client = client;
        Receive();
    }

    public async void Receive()
    {
        while (_client.Connected)
        {
            try
            {
                byte[] buffer = new byte[4096];
                int length = await _client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                if (length > 0)
                {
                    Console.WriteLine("接收到数据长度:"+length);
                    Console.WriteLine("接收到数据内容:"+Encoding.UTF8.GetString(buffer,0,length));
                }
                else
                {
                    _client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _client.Close();
            }
        }
    }

    public async void Send(byte[] data)
    {
        try
        {
            await _client.GetStream().WriteAsync(data, 0, data.Length);
            Console.WriteLine("发送成功");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _client.Close();
        }
    }
}