namespace CSharpPractice.程序员面试金典;

public class LeetCode_10_05
{
    public static void Test()
    {
        LeetCode_10_05 obj = new LeetCode_10_05();
        Console.WriteLine(obj.FindString(new []{"at", "", "", "", "ball", "", "", "car", "", "","dad", "", ""},"ta"));
        Console.WriteLine(obj.FindString(new []{"at", "", "", "", "ball", "", "", "car", "", "","dad", "", ""},"ball"));
    }
    
    public int FindString(string[] words, string s) 
    {
        int left = 0, right = words.Length-1;
        while (left <= right)
        {
            while (left < right && words[left] == "")
                left++;
            while (left < right && words[right] == "")
                right--;
            int mid = (right - left) / 2 + left;
            while (mid < right && words[mid] == "")
                mid++;
            if (words[mid] == s)
                return mid;
            if (String.Compare(words[mid], s, StringComparison.Ordinal) > 0)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return -1;
    }
}