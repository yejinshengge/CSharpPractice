namespace CSharpPractice.LeetCode.哈希表篇;

public class LeetCode_0519
{
    public static void Test()
    {
        LeetCode_0519 obj = new LeetCode_0519();
    }
    
    
    public class Solution
    {
        private int _m;
        private int _n;
        private int _total;
        private Random _random = new Random();
        private Dictionary<int, int> _dic = new();
        public Solution(int m, int n)
        {
            _m = m;
            _n = n;
            _total = m * n;
        }
    
        public int[] Flip()
        {
            var rand = _random.Next(0, _total--);
            int index = rand;
            if (_dic.ContainsKey(rand))
                index = _dic[rand];
            int newIndex = _total;
            if (_dic.ContainsKey(_total))
                newIndex = _dic[_total];
            _dic[rand] = newIndex;
            return new[] { index / _n, index % _n };
        }
    
        public void Reset()
        {
            _total = _m * _n;
            _dic.Clear();
        }
    }
}