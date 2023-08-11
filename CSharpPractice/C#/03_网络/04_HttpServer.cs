using System.Net;
using System.Text;

namespace CSharpPractice.C_._03_网络;

public class HttpServerPractice {

    public static void HttpServerPracticeMain()
    {
        using var server = new SimpleServer();
        Console.WriteLine(new WebClient().DownloadString("http://localhost:1234/MyApp/Request.txt"));
    }

    class SimpleServer:IDisposable
    {
        private readonly HttpListener _listener = new HttpListener();

        public SimpleServer() => Listen();

        async void Listen()
        {
            _listener.Prefixes.Add("http://localhost:1234/MyApp/");
            _listener.Start();

            var context = await _listener.GetContextAsync();
            string msg = "你正在请求：" + context.Request.RawUrl;
            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
            context.Response.StatusCode = (int) HttpStatusCode.OK;
            
            using(Stream s = context.Response.OutputStream)
            using (StreamWriter writer = new StreamWriter(s))
                await writer.WriteAsync(msg);
        }
        public void Dispose()
        {
            _listener.Close();
        }
    }
    
}