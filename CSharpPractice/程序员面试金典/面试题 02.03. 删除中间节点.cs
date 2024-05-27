using CSharpPractice.Util;

namespace CSharpPractice.程序员面试金典;

public class LeetCode_02_03
{
    public static void Test()
    {
        LeetCode_02_03 obj = new LeetCode_02_03();
    }
    
    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}