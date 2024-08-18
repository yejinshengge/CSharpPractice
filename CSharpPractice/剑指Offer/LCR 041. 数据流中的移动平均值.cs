namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR041
{
    public static void Test()
    {
        LeetCode_LCR041 obj = new LeetCode_LCR041();
    }
    
    public class MovingAverage
    {
        private Queue<int> _queue = new();
        private int _size = 0;
        private int _total = 0;
        
        public MovingAverage(int size)
        {
            _size = size;
        }
    
        public double Next(int val) {
            if (_queue.Count < _size)
            {
                _queue.Enqueue(val);
                _total += val;
                return (double)_total / _queue.Count;
            }
            else
            {
                var front = _queue.Dequeue();
                _queue.Enqueue(val);
                _total -= front;
                _total += val;
                return (double)_total / _size;
            }
        }
    }
}