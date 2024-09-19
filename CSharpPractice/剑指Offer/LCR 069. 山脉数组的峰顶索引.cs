namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR069
{
    public static void Test()
    {
        LeetCode_LCR069 obj = new LeetCode_LCR069();
        Console.WriteLine(obj.PeakIndexInMountainArray(new []{3,4,5,1}));
        Console.WriteLine(obj.PeakIndexInMountainArray(new []{18,29,38,59,98,100,99,98,90}));
    }
    
    public int PeakIndexInMountainArray(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) >> 1;
            int leftNum = mid - 1 >= 0 ? arr[mid - 1] : -1;
            int rightNum = mid + 1 < arr.Length ? arr[mid + 1] : 1000001;

            if (leftNum < arr[mid] && arr[mid] > rightNum)
                return mid;
            if (rightNum > arr[mid])
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}