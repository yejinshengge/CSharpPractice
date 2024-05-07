namespace CSharpPractice.数据结构;

public class BinaryIndexedTree
{
    public static void Test()
    {
        BinaryIndexedTree obj = new BinaryIndexedTree();
        int[] arr = new[] { 1, 2, 3, 4, 5 };
        for (int i = 1; i <= arr.Length; i++)
        {
            obj.Update(i,arr[i-1]);
        }
        Console.WriteLine(obj.Query(5));
    }
    
    private const int MAX_LEN = 10;
    private int[] _arr = new int[MAX_LEN];

    private int _lowbit(int x)
    {
        return -x & x;
    }

    public void Update(int index, int val)
    {
        for (int i = index; i < MAX_LEN; i+=_lowbit(i))
        {
            _arr[i] += val;
        }
    }

    public int Query(int n)
    {
        int res = 0;
        for (int i = n; i >0; i-=_lowbit(i))
        {
            res += _arr[i];
        }

        return res;
    }
}