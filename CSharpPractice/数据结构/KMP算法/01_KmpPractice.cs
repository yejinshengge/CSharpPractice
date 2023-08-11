namespace CSharpPractice.Class02.KMP算法;

public class KmpPractice {
    public static void KmpPracticeMain()
    {
        KmpPractice obj = new KmpPractice();
        string m = "ababeababkababeababf";
        string n = "ababeababf";

        // int[] next = obj.GetNextArr("ababeababf");
        
        Console.WriteLine(obj.Process1(m,n));
        Console.WriteLine(obj.Process2(m,n));
    }

    /// <summary>
    /// 朴素的匹配模式算法
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    private int Process1(string m,string n)
    {
        if (m == null || n == null || m.Length < n.Length || n.Length <= 0)
            return -1;
        int p1=0, p2 = 0;

        while (p1 < m.Length && p2 < n.Length)
        {
            // 两字符相同,指针共同后移
            if (m[p1] == n[p2])
            {
                p1++;
                p2++;
            }
            // 两字符不同,指针回退
            else
            {
                p1 = p1 - p2 + 1;
                p2 = 0;
            }
        }
        // 如果p2走到末尾,则匹配成功
        if (p2 == n.Length)
            return p1 - p2;
        // 否则匹配失败
        return -1;
    }

    /// <summary>
    /// KMP算法
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    private int Process2(string m, string n)
    {
        if (m == null || n == null || m.Length < n.Length || n.Length <= 0)
            return -1;
        int p1 = 0, p2 = 0;
        int[] next = GetNextArr(n);
        while (p1 < m.Length && p2 < n.Length)
        {
            // 如果匹配成功,两指针都后移
            if (m[p1] == n[p2])
            {
                p1++;
                p2++;
            }
            // 如果匹配失败,且p2本来就在0位置,则p1后移
            else if (p2 == 0)
            {
                p1++;
            }
            // 如果匹配失败,且p2不在0位置,则进行回溯
            else
            {
                p2 = next[p2];
            }
        }
        // p2遍历完成,说明匹配成功,否则匹配失败
        return p2 == n.Length ? p1 - p2 : -1;
    }
    /// <summary>
    /// 获取next数组
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private int[] GetNextArr(string n)
    {
        int[] next = new int[n.Length];
        // 0和1位置的值是固定的
        next[0] = -1;
        next[1] = 0;
        // 定义左右指针
        int left = 0, right = 1;
        
        while (right < n.Length-1)
        {
            // 字符匹配成功时,left、right同时右移,
            // ‘前后缀相同的最长子串长度’+1(其实就是left的值)
            if (n[left] == n[right])
            {
                left++;
                next[right + 1] = left;
                right++;
            }
            // 如果匹配失败,但left还没回溯到最开始的位置,那就继续回溯
            else if (left > 0)
            {
                left = next[left];
            }
            // left回溯到0的位置也没有匹配成功,则‘前后缀相同的最长子串长度’为0
            else
            {
                next[right + 1] = 0;
                right++;
            }
        }
        return next;
    }
}