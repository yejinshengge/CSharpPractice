namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR071
{
    public static void Test()
    {
        LeetCode_LCR071 obj = new LeetCode_LCR071();
        Solution sl = new Solution(new[] { 3,14,1,7 });
        sl.PickIndex();
        sl.PickIndex();
        sl.PickIndex();
        sl.PickIndex();

    }
    
    public class Solution
    {
        private int[] oriArr;
        private int[] prefixSum;
        public Solution(int[] w)
        {
            oriArr = w;
            prefixSum = new int[w.Length];
            prefixSum[0] = w[0];
            for (var i = 1; i < w.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + w[i];
            }
        }
    
        public int PickIndex()
        {
            int random = new Random().Next(0, prefixSum[^1]);
            int left = 0, right = prefixSum.Length;
            while (left <= right)
            {
                int mid = (left + right) >> 1;
                if (prefixSum[mid] > random)
                {
                    if (mid == 0 || prefixSum[mid - 1] <= random)
                        return mid;
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }

            return -1;
        }
    }
}