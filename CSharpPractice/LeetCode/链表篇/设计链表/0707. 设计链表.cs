﻿namespace CSharpPractice.LeetCode.链表篇.设计链表;

/**
你可以选择使用单链表或者双链表，设计并实现自己的链表。

单链表中的节点应该具备两个属性：val 和 next 。val 是当前节点的值，next 是指向下一个节点的指针/引用。

如果是双向链表，则还需要属性prev以指示链表中的上一个节点。假设链表中的所有节点下标从 0 开始。

实现 MyLinkedList 类：

MyLinkedList() 初始化 MyLinkedList 对象。
int get(int index) 获取链表中下标为 index 的节点的值。如果下标无效，则返回 -1 。
void addAtHead(int val) 将一个值为 val 的节点插入到链表中第一个元素之前。在插入完成后，新节点会成为链表的第一个节点。
void addAtTail(int val) 将一个值为 val 的节点追加到链表中作为链表的最后一个元素。
void addAtIndex(int index, int val) 将一个值为 val 的节点插入到链表中下标为 index 的节点之前。
    如果 index 等于链表的长度，那么该节点会被追加到链表的末尾。如果 index 比长度更大，该节点将 不会插入 到链表中。
void deleteAtIndex(int index) 如果下标有效，则删除链表中下标为 index 的节点。

 */
public class LeetCode_0707
{
    public static void Test()
    {
        MyLinkedList obj = new MyLinkedList();
        obj.AddAtHead(4);
        int param_1 = obj.Get(1);
        obj.AddAtHead(1);
        obj.AddAtHead(5);
        obj.DeleteAtIndex(3);
        obj.AddAtHead(7);
        int param_2 = obj.Get(3);
        int param_3 = obj.Get(3);
        int param_4 = obj.Get(3);
        obj.AddAtHead(1);
        obj.DeleteAtIndex(4);
        
    }

}

public class MyLinkedList {
    
    private class MyNode
    {
        public int val;
        public MyNode next;

        public MyNode(int val)
        {
            this.val = val;
        }
        
    }

    private MyNode head;
    
    public MyLinkedList()
    {
        head = new MyNode(0);
    }
    
    /// <summary>
    /// 获取链表中下标为 index 的节点的值。如果下标无效，则返回 -1 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int Get(int index)
    {
        MyNode cur = head;
        
        while (index >= 0)
        {
            cur = cur.next;
            if (cur == null)
                return -1;
            index--;
        }

        return cur.val;
    }
    
    /// <summary>
    /// 将一个值为 val 的节点插入到链表中第一个元素之前。在插入完成后，新节点会成为链表的第一个节点。
    /// </summary>
    /// <param name="val"></param>
    public void AddAtHead(int val)
    {
        MyNode node = new MyNode(val);
        node.next = head.next;
        head.next = node;
    }
    
    /// <summary>
    /// 将一个值为 val 的节点追加到链表中作为链表的最后一个元素。
    /// </summary>
    /// <param name="val"></param>
    public void AddAtTail(int val)
    {
        MyNode node = new MyNode(val);
        MyNode cur = head;
        while (cur.next != null)
        {
            cur = cur.next;
        }

        cur.next = node;
    }
    /// <summary>
    /// 将一个值为 val 的节点插入到链表中下标为 index 的节点之前。如果 index 等于链表的长度，
    /// 那么该节点会被追加到链表的末尾。如果 index 比长度更大，该节点将 不会插入 到链表中。
    /// </summary>
    /// <param name="index"></param>
    /// <param name="val"></param>
    public void AddAtIndex(int index, int val) {
        MyNode cur = head;
        MyNode node = new MyNode(val);
        while (index > 0)
        {
            cur = cur.next;
            if (cur == null)
                return;
            index--;
        }

        node.next = cur.next;
        cur.next = node;
    }
    /// <summary>
    /// 如果下标有效，则删除链表中下标为 index 的节点。
    /// </summary>
    /// <param name="index"></param>
    public void DeleteAtIndex(int index) {
        MyNode cur = head;
        while (index > 0)
        {
            cur = cur.next;
            if (cur == null)
                return;
            index--;
        }
        
        if(cur.next == null) return;
        cur.next = cur.next.next;
    }
}