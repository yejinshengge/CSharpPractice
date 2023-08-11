namespace CSharpPractice.LeetCode;

public class Offer031ValidateStackSequences
{
    public static void Offer31ValidateStackSequencesMain()
    {
        Offer031ValidateStackSequences obj = new();
        var flag = obj.ValidateStackSequences(new[] {1, 2, 3, 4, 5}, new[] {4,3,1,5,2});
        Console.WriteLine(flag);
    }
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var pushedLength = pushed.Length;
        var poppedLength = popped.Length;
        if (pushedLength == 0 && poppedLength == 0)
            return true;
        if (pushedLength * poppedLength == 0)
            return false;
        
        Stack<int> stack = new();
        int index1 = 0, index2 = 0;

        while (index1 != pushedLength && index2 != poppedLength)
        {
            while (index1 < pushedLength && index2 < poppedLength &&pushed[index1] != popped[index2])
            {
                stack.Push(pushed[index1]);
                index1++;
            }

            while (index1 < pushedLength && index2 < poppedLength && pushed[index1] == popped[index2])
            {
                index1++;
                index2++;
            }
            
            while (stack.Count > 0 && stack.Peek() == popped[index2])
            {
                stack.Pop();
                index2++;
            }
        }

        return index1 == index2;
    }
}