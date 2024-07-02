namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_10
{
    public static void Test()
    {
        LeetCode_10_10 obj = new LeetCode_10_10();
    }
    
    public class StreamRank
    {
        private int[] _arr;
        
        public StreamRank()
        {
            _arr = new int[50002];
        }
    
        public void Track(int x)
        {
            ++x;
            for (int i = x; i <= 50001; i+=i&-i)
            {
                _arr[i]++;
            }
        }
    
        public int GetRankOfNumber(int x)
        {
            int sum = 0;
            x++;
            for (int i = x; i >0; i-=i&-i)
            {
                sum += _arr[i];
            }

            return sum;
        }
        
    }

}