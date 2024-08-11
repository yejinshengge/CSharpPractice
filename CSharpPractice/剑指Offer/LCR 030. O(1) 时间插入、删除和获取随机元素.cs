namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR030
{
    public static void Test()
    {
        LeetCode_LCR030 obj = new LeetCode_LCR030();
    }
}

public class RandomizedSet
{
    private Dictionary<int, int> _dic;
    private List<int> _list;
    /** Initialize your data structure here. */
    public RandomizedSet()
    {
        _dic = new Dictionary<int, int>();
        _list = new List<int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val)
    {
        if (_dic.ContainsKey(val))
            return false;
        _list.Add(val);
        _dic.Add(val,_list.Count-1);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val)
    {
        if (!_dic.ContainsKey(val))
            return false;
        var lastVal = _list[^1];
        _list[_dic[val]] = lastVal;
        _dic[lastVal] = _dic[val];
        _list.RemoveAt(_list.Count-1);
        _dic.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom()
    {
        return _list[new Random().Next(0, _list.Count)];
    }
}