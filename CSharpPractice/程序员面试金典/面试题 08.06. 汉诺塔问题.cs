namespace CSharpPractice.程序员面试金典;

public class LeetCode_08_06
{
    public static void Test()
    {
        LeetCode_08_06 obj = new LeetCode_08_06();
    }
    
    public void Hanota(IList<int> a, IList<int> b, IList<int> c) {
        _move(a.Count,a,b,c);
    }

    private void _move(int index, IList<int> a, IList<int> b, IList<int> c)
    {
        if (index == 1)
        {
            c.Add(a[^1]);
            a.RemoveAt(a.Count-1);
            return;
        }

        _move(index - 1, a, c, b);
        c.Add(a[^1]);
        a.RemoveAt(a.Count-1);
        _move(index-1,b,a,c);
    }
}