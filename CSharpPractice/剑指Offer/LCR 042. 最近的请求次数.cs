namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR042
{
    public static void Test()
    {
        LeetCode_LCR042 obj = new LeetCode_LCR042();
    }
    
    public class RecentCounter
    {
        private Queue<int> _queue;
        
        public RecentCounter()
        {
            _queue = new Queue<int>();
        }
    
        public int Ping(int t)
        {
            int min = t - 3000;
            _queue.Enqueue(t);
            while (_queue.Peek() < min)
            {
                _queue.Dequeue();
            }
            return _queue.Count;
        }
    }
}