using CSharpPractice.Util;

namespace CSharpPractice.剑指Offer;

public class LeetCode_LCR080
{
    public static void Test()
    {
        LeetCode_LCR080 obj = new LeetCode_LCR080();
        Tools.PrintEnumerator(obj.Combine(4,2));
        Tools.PrintEnumerator(obj.Combine(1,1));
    }
    
    public IList<IList<int>> Combine(int n, int k) {
        _res.Clear();
        _path.Clear();
        _doCombine(n,k,1);
        return _res;
    }
    
    private IList<IList<int>> _res = new List<IList<int>>();
    private IList<int> _path = new List<int>();

    private void _doCombine(int n,int k,int index)
    {
        if (_path.Count == k)
        {
            _res.Add(new List<int>(_path));
            return;
        }

        for (int i = index; i <= n; i++)
        {
            _path.Add(i);
            _doCombine(n,k,i+1);
            _path.RemoveAt(_path.Count-1);
        }
    }
}