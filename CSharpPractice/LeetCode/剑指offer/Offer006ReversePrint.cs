using CSharpPractice.Util;

namespace CSharpPractice.LeetCode;

public class Offer006ReversePrint
{
    public static void Offer006ReversePrintMain()
    {
        Offer006ReversePrint obj = new();
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        int[] res = obj.ReversePrint2(head);
        for (int i = 0; i < res.Length; i++)
        {
            Console.Write($"{res[i]} ");
        }
    }
    
    public int[] ReversePrint(ListNode head)
    {
        ListNode cur = head;
        Stack<int> stack = new();
        while (cur != null)
        {
            stack.Push(cur.val);
            cur = cur.next;
        }

        int[] res = new int[stack.Count];
        for (int j = 0; j < res.Length; j++)
        {
            res[j] = stack.Pop();
        }
        return res;
    }

    private int[] _arr = new int[10000];
    private int _index = 0;
    public int[] ReversePrint2(ListNode head)
    {
        Reverse(head);
        int[] res = new int[_index];
        for (int i = 0; i < _index; i++)
        {
            res[i] = _arr[i];
        }
        return res;
    }

    private void Reverse(ListNode node)
    {
        if(node == null)
            return;
        Reverse(node.next);
        _arr[_index++] = node.val;
    }

}