namespace CSharpPractice.C_._03_网络;

public class UriPractice {
    
    public static void UriPracticeMain()
    {
        Uri page = new Uri("https://www.mihoyo.com/?page=join");

        Console.WriteLine(page.Host);
        Console.WriteLine(page.Port);
        
    }
}