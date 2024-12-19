using CSharpPractice.Util;

namespace CSharpPractice.LeetCode.二叉树;

public class LeetCode_0109
{
    public static void Test()
    {
        LeetCode_0109 obj = new LeetCode_0109();
        Tools.SequenceTraversalTree(obj.SortedListToBST(Tools.ConstructLinkedList(new []{-10,-3,0,5,9})));
        Tools.SequenceTraversalTree(obj.SortedListToBST(Tools.ConstructLinkedList(new []{-10,-3,-2,0,5,9})));
        Tools.SequenceTraversalTree(obj.SortedListToBST(Tools.ConstructLinkedList(Array.Empty<int>())));
    }
    
    public TreeNode SortedListToBST1(ListNode head)
    {
        if (head == null) return null;
        ListNode fast = head, slow = head,pre = head;
        while (fast != null)
        {
            fast = fast.next;
            if(fast == null) break;
            fast = fast.next;
            pre = slow;
            slow = slow.next;
        }

        pre.next = null;

        TreeNode node = new TreeNode(slow.val);
        if (head == slow) return node;
        node.left = SortedListToBST1(head);
        node.right = SortedListToBST1(slow.next);
        pre.next = slow;
        return node;
    }

    public TreeNode SortedListToBST(ListNode head)
    {
        if (head == null) return null;
        _curHead = head;
        int num = _getNodeNum(head);
        return _buildTree(0, num-1);
    }

    private int _getNodeNum(ListNode head)
    {
        int num = 0;
        while (head != null)
        {
            head = head.next;
            num++;
        }

        return num;
    }

    private ListNode _curHead;
    private TreeNode _buildTree(int left,int right)
    {
        if (left > right) return null;
        int mid = (left + right) / 2;
        TreeNode node = new TreeNode();
        node.left = _buildTree(left, mid - 1);
        node.val = _curHead.val;
        _curHead = _curHead.next;
        node.right = _buildTree(mid + 1, right);
        return node;
    }
}
