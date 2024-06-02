namespace CSharpPractice.程序员面试金典;

public class LeetCode_03_06
{
    public static void Test()
    {
        LeetCode_03_06 obj = new LeetCode_03_06();
    }
    
}

public class AnimalShelf
{
    private Queue<int> _dogQueue;
    private Queue<int> _catQueue;
    public AnimalShelf()
    {
        _dogQueue = new Queue<int>();
        _catQueue = new Queue<int>();
    }
    
    public void Enqueue(int[] animal) {
        if(animal[1] == 0)
            _catQueue.Enqueue(animal[0]);
        else
            _dogQueue.Enqueue(animal[0]);
    }
    
    public int[] DequeueAny()
    {
        int dogMin = _dogQueue.Count > 0 ? _dogQueue.Peek() : -1;
        int catMin = _catQueue.Count > 0 ? _catQueue.Peek() : -1;
        if (dogMin == -1 && catMin == -1)
            return new[] { -1, -1 };
        if (dogMin != -1 && catMin == -1)
            return new[] { _dogQueue.Dequeue(), 1 };
        if (dogMin == -1 && catMin != -1)
            return new[] { _catQueue.Dequeue(), 0 };
        if(dogMin < catMin)
            return new[] { _dogQueue.Dequeue(), 1 };
        return new[] { _catQueue.Dequeue(), 0 };
    }
    
    public int[] DequeueDog()
    {
        if (_dogQueue.Count == 0)
            return new[] { -1, -1 };
        return new[] { _dogQueue.Dequeue(), 1 };
    }
    
    public int[] DequeueCat() {
        if (_catQueue.Count == 0)
            return new[] { -1, -1 };
        return new[] { _catQueue.Dequeue(), 0 };
    }

}
