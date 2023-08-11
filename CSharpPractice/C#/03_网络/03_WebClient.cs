using System.Net;

namespace CSharpPractice.C_._03_网络;

public class WebClientPractice {
    
    public static async Task WebClientPracticeMain()
    {
        // WebClient
        WebClient client = new WebClient() {Proxy = null};
        client.DownloadFile("http://www.albahari.com/nutshell/code.aspx","code.htm");
        client.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage+"%");

        // WebRequest、WebResponse
        WebRequest req = WebRequest.Create("http://www.albahari.com/nutshell/code.aspx");
        req.Proxy = null;
        using (WebResponse res = req.GetResponse())
        using (Stream rs = res.GetResponseStream())
        using (FileStream fs = File.Create("code.htm"))
            rs.CopyTo(fs);
        
        // HttpClient
        string html = await new HttpClient().GetStringAsync("http://linqpad.net");

        var client2 = new HttpClient();
        HttpResponseMessage httpResponseMessage = await client2.GetAsync("http://linqpad.net");
        httpResponseMessage.EnsureSuccessStatusCode();
        string html2 = await httpResponseMessage.Content.ReadAsStringAsync();


        var message = new HttpRequestMessage(HttpMethod.Get, "http://linqpad.net");
        var response = await client2.SendAsync(message);
        response.EnsureSuccessStatusCode();
    }
}