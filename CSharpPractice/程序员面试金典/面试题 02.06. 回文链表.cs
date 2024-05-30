using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_06
{
    public static void Test()
    {
        LeetCode_02_06 obj = new LeetCode_02_06();
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1,2,2,1})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1,2,1})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(new []{1,2})));
        Console.WriteLine(obj.IsPalindrome(Tools.ConstructLinkedList(Array.Empty<int>())));
    }
    
    // 快慢指针
    public bool IsPalindrome1(ListNode head)
    {
        if (head == null) return true;
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        var cur = head;
        var tail = _reverse(slow);
        bool flag = true;
        while (cur != null && tail != null)
        {
            if (cur.val != tail.val)
            {
                flag = false;
                break;
            }

            cur = cur.next;
            tail = tail.next;
        }

        return flag;
    }
    private ListNode _reverse(ListNode head)
    {
        ListNode pre = null;
        ListNode cur = head;
        while (cur != null)
        {
            ListNode tmp = cur.next;
            cur.next = pre;
            pre = cur;
            cur = tmp;
        }
        return pre;
    }

    // 递归
    private ListNode _root;
    public bool IsPalindrome(ListNode head)
    {
        _root = head;
        return _doIsPalindrome(head);
    }

    private bool _doIsPalindrome(ListNode head)
    {
        if (head == null) return true;

        if (!_doIsPalindrome(head.next))
            return false;
        if (head.val != _root.val)
            return false;
        _root = _root.next;
        return true;
    }
}