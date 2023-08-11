namespace CSharpPractice.LeetCode;

public class Offer017PrintNumbers
{
    public static void Offer017PrintNumbersMain()
    {
        Offer017PrintNumbers obj = new();
        int[] res = obj.PrintNumbers(3);
        for (int i = 0; i < res.Length; i++)
        {
            Console.Write(res[i]+" ");
        }
    }
    public int[] PrintNumbers(int n)
    {
        int[] res = new int[(int) Math.Pow(10, n)-1];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = i + 1;
        }
        return res;
    }
}