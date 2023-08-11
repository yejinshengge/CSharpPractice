namespace CSharpPractice.数据结构.线性结构.线性表;

public class LinkedStructure {
    public static void LinkedStructureMain()
    {
        MyLinkedList<int> list = new();
        list.Insert(0,0);
        list.Insert(1,1);
        list.Insert(2,2);
        list.Insert(3,3);
        list.Insert(4,4);
        // list.Insert(5,1);
        // list.Insert(6,5);
        list.Delete(0);
        list.Delete(3);
        list.Delete(1);
        Console.WriteLine(list);

        StaticLinkedList<int> list2 = new(20);
        list2.Insert(0,0);
        list2.Insert(1,1);
        list2.Insert(2,2);
        list2.Insert(3,3);
        list2.Insert(4,4);
        // l2ist.Insert(5,1);
        // l2ist.Insert(6,5);
        // list2.Delete(0);
        // list2.Delete(3);
        // list2.Delete(1);
        Console.WriteLine(list2);
    }

    #region 单链表

    public class MyLinkedListNode<T>
    {
        public T? Data { get; private set; }
        public MyLinkedListNode<T>? Next { get; set; }

        public MyLinkedListNode(T? data)
        {
            Data = data;
        }
    }
    public class MyLinkedList<T>: IMyList<T>
    {
        // 头结点
        public MyLinkedListNode<T> Head { get; private set; }
        
        public int Length { get; private set; }
        
        public MyLinkedList()
        {
            Head = new MyLinkedListNode<T>(default);
            Length = 0;
        }
        
        private MyLinkedListNode<T> GetNode(int index)
        {
            if (index >= Length || index < 0)
                throw new Exception("下标越界");
            MyLinkedListNode<T> res = Head;
            while (index >= 0)
            {
                res = res.Next;
                index--;
            }

            return res;
        }
        
        public T GetData(int index)
        {
            return GetNode(index).Data;
        }
        public void Insert(T e, int index)
        {
            if (index == 0)
            {
                MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(e);
                newNode.Next = Head.Next;
                Head.Next = newNode;
            }
            else
            {
                var preNode = GetNode(index - 1);
                var curNode = preNode.Next;
                MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(e);
                newNode.Next = curNode;
                preNode.Next = newNode;
            }
            Length++;
        }

        public void Delete(int index)
        {
            var curNode = GetNode(index);
            if (index == 0)
            {
                Head.Next = curNode.Next;
            }
            else
            {
                var preNode = GetNode(index - 1);
                preNode.Next = curNode.Next;
            }
            Length--;
        }
    }
    

    #endregion

    #region 静态链表

    public class StaticLinkedListNode<T>
    {
        public T? Data { get; set; }
        public int Next { get; set; }

        public StaticLinkedListNode(T? data)
        {
            Data = data;
        }
    }

    public class StaticLinkedList<T>:IMyList<T>
    {
        private readonly StaticLinkedListNode<T>[] _nodes;
        public int Length { get; private set; }
        
        public StaticLinkedList(int maxLength)
        {
            _nodes = new StaticLinkedListNode<T>[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                _nodes[i] = new StaticLinkedListNode<T>(default);
                _nodes[i].Next = i + 1;
            }
            _nodes[maxLength - 1].Next = 0;
            Length = 0;
        }

        private StaticLinkedListNode<T> GetNode(int index)
        {
            if (index >= Length || index < 0)
                throw new Exception("下标越界");
            var cur = _nodes[^1];
            while (index >= 0)
            {
                cur = _nodes[cur.Next];
                index--;
            }
            return cur;
        }
        
        public T GetData(int index)
        {
            return GetNode(index).Data;
        }

        public void Insert(T e, int index)
        {
            // 获取备用链表开始下标
            var newIndex = _nodes[0].Next;
            // 备用链表指针更新
            _nodes[0].Next = _nodes[newIndex].Next;
            if (index == 0)
            {
                if (Length != 0)
                {
                    _nodes[newIndex].Next = _nodes[^1].Next;
                }
                _nodes[^1].Next = newIndex;
            }
            else
            {
                // 获取前一节点
                var preNode = GetNode(index - 1);
                // 更新前节点和新节点的指针
                _nodes[newIndex].Next = preNode.Next;
                preNode.Next = newIndex;
            }
            _nodes[newIndex].Data = e;
            Length++;
        }

        public void Delete(int index)
        {
            
        }
    }
    #endregion
}