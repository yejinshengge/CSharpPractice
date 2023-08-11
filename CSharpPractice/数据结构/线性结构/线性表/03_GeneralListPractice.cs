namespace CSharpPractice.数据结构.线性结构.线性表;

public class GeneralListPractice {

    public static void GeneralListPracticeMain()
    {
        
    }
    
    public class GeneralListNode<T>
    {
        public bool IsSubList;
        public T? Data;
        public GeneralListNode<T>? SubList;
        public GeneralListNode<T>? Next;

        public GeneralListNode(T data)
        {
            Data = data;
        }

        public GeneralListNode(GeneralListNode<T> subList)
        {
            SubList = subList;
            IsSubList = true;
        }
    }
    
    public class GeneralList<T>
    {
        public GeneralListNode<T> Head { get; private set; }
        public int Length { get; private set; }
        
        
    }
}