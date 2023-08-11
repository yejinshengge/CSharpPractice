namespace CSharpPractice.数据结构.练习;

public class UnionFindTest {

    public static void UnionFindTestMain()
    {
        List<int> elements = new List<int>() {1, 2, 3, 4, 5};
        UnionFind<int> unionFind = new UnionFind<int>(elements);

        Console.WriteLine(unionFind.Find(1, 2));
        unionFind.Union(1,2);
        Console.WriteLine(unionFind.Find(1, 2));
        Console.WriteLine(unionFind.Find(1, 3));
        unionFind.Union(1,3);
        Console.WriteLine(unionFind.Find(2, 3));
    }
    
}

public class UnionFind<T> where T : notnull
{
    // 内部节点类
    private class Element<TK>
    {
        public TK Value;

        public Element(TK value)
        {
            Value = value;
        }
    }
    // 节点
    private Dictionary<T, Element<T>> _nodesMap;
    // 父节点
    private Dictionary<Element<T>, Element<T>> _fatherMap;
    // 节点对应高度
    private Dictionary<Element<T>, int> _heightMap;

    public UnionFind(List<T> elements)
    {
        _nodesMap = new Dictionary<T, Element<T>>();
        _fatherMap = new Dictionary<Element<T>, Element<T>>();
        _heightMap = new Dictionary<Element<T>, int>();

        for (int i = 0; i < elements.Count; i++)
        {
            var element = new Element<T>(elements[i]);
            _nodesMap[elements[i]] = element;
            _fatherMap[element] = element;
            _heightMap[element] = 0;
        }
    }

    // 获取头结点
    private Element<T> GetHead(Element<T> element)
    {
        Stack<Element<T>> stack = new Stack<Element<T>>();

        // 父节点不是自己,就不是头结点
        while (element != _fatherMap[element])
        {
            stack.Push(element);
            element = _fatherMap[element];
        }
        
        // 路径压缩
        while (stack.Count > 0)
        {
            _fatherMap[stack.Pop()] = element;
        }

        return element;
    }

    /// <summary>
    /// 查询item1和item2是否同一集合
    /// </summary>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <returns></returns>
    public bool Find(T item1, T item2)
    {
        if (_nodesMap.ContainsKey(item1) && _nodesMap.ContainsKey(item2))
        {
            if (GetHead(_nodesMap[item1]) == GetHead(_nodesMap[item2]))
                return true;
        }
        return false;
    }

    /// <summary>
    /// 合并item1和item2集合
    /// </summary>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    public void Union(T item1, T item2)
    {
        if (_nodesMap.ContainsKey(item1) && _nodesMap.ContainsKey(item2))
        {
            var head1 = GetHead(_nodesMap[item1]);
            var head2 = GetHead(_nodesMap[item2]);

            if (head1 != head2)
            {
                var big = _heightMap[head1] > _heightMap[head2] ? head1 : head2;
                var small = big == head1 ? head2 : head1;
                
                // 小的合并到大的
                _fatherMap[small] = big;
                _heightMap[big]++;
                _heightMap.Remove(small);
            }
        }
    }

}