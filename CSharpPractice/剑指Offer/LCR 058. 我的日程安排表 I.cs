namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR058
{
    public static void Test()
    {
        LeetCode_LCR058 obj = new LeetCode_LCR058();
        MyCalendar calendar = new();
        Console.WriteLine(calendar.Book(10,20));
        Console.WriteLine(calendar.Book(15,25));
        Console.WriteLine(calendar.Book(20,30));
    }
    
    public class MyCalendar
    {
        private HashSet<int> _tree;
        private HashSet<int> _lazy;
        private const int MAX_SIZE = 1000000000;
        public MyCalendar()
        {
            _tree = new();
            _lazy = new();
        }
    
        public bool Book(int start, int end)
        {
            if (_query(0, 0, MAX_SIZE, start, end-1))
                return false;
            _update(0,0,MAX_SIZE,start,end-1);

            return true;
        }

        private bool _query(int index, int curLeft, int curRight, int tarLeft, int tarRight)
        {
            if (curLeft > tarRight || curRight < tarLeft)
                return false;
            if (_lazy.Contains(index))
                return true;
            if (curLeft >= tarLeft && curRight <= tarRight)
                return _tree.Contains(index);
            int mid = (curLeft + curRight) >> 1;
            return _query(index*2+1, curLeft, mid, tarLeft, tarRight) 
                   || _query(index*2+2,mid+1,curRight,tarLeft,tarRight);
        }

        private void _update(int index, int curLeft, int curRight,int tarLeft,int tarRight)
        {
            if (curLeft > tarRight || curRight < tarLeft)
                return;
            if (curLeft >= tarLeft && curRight <= tarRight)
            {
                _tree.Add(index);
                _lazy.Add(index);
                return;
            }
            
            int mid = (curLeft + curRight) >> 1;
            _update(index*2+1,curLeft,mid,tarLeft,tarRight);
            _update(index*2+2,mid+1,curRight,tarLeft,tarRight);
            _tree.Add(index);
        }
    }
}