namespace CSharpPractice.数据结构.图;

public class GraphStructurePractice
{
    public static void GraphStructurePracticeMain()
    {
        IGraph<string> graph = new GraphByEdgeCollectionArray<string>(4);
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        
        graph.AddEdge(0,1,7);
        graph.AddEdge(0,2,3);
        graph.AddEdge(1,2,6);
        graph.AddEdge(1,3,5);

        Console.WriteLine(graph);
    }
}

public interface IGraph<T>
{
    public void AddNode(T e);
    public void AddEdge(int node1Index, int node2Index, int weight);
}

/// <summary>
/// 图的邻接矩阵存储方式
/// </summary>
public class GraphByAdjacencyMatrix<T>:IGraph<T>
{
    public T[] Nodes => _nodes;
    public int Count => _count;
    public int[,] Matrix => _matrix;
    
    private T[] _nodes;
    private int[,] _matrix;
    private int _count;

    public GraphByAdjacencyMatrix(int capacity)
    {
        _nodes = new T[capacity];
        _matrix = new int[capacity, capacity];
        // 初始化邻接矩阵
        for (int i = 0; i < capacity; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                if (i == j) 
                    _matrix[i, j] = 0;
                else
                    _matrix[i, j] = Int32.MaxValue;
            }
        }
    }

    /// <summary>
    /// 添加节点
    /// </summary>
    /// <param name="e"></param>
    public void AddNode(T e)
    {
        _nodes[_count++] = e;
    }

    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="node1Index"></param>
    /// <param name="node2Index"></param>
    /// <param name="weight"></param>
    public void AddEdge(int node1Index, int node2Index, int weight)
    {
        _matrix[node1Index, node2Index] = weight;
    }
}

/// <summary>
/// 图的邻接表存储方式
/// </summary>
/// <typeparam name="T"></typeparam>
public class GraphByAdjacencyList<T>:IGraph<T>
{
    /// <summary>
    /// 边结构
    /// </summary>
    public class Edge
    {
        public int index;
        public int weight;
        public Edge next;

        public Edge(int index,int weight)
        {
            this.index = index;
            this.weight = weight;
        }
    }
    /// <summary>
    /// 顶点结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T data;
        public int inWeight;
        public Edge next;
        public Node(T e)
        {
            data = e;
        }
    }

    public int Count => _count;
    public Node<T>[] Nodes => _nodes;
    private Node<T>[] _nodes;
    private int _count;
    
    public GraphByAdjacencyList(int capacity)
    {
        _nodes = new Node<T>[capacity];
    }

    /// <summary>
    /// 添加顶点
    /// </summary>
    /// <param name="e"></param>
    public void AddNode(T e)
    {
        _nodes[_count++] = new Node<T>(e);
    }

    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="node1Index"></param>
    /// <param name="node2Index"></param>
    /// <param name="weight"></param>
    public void AddEdge(int node1Index, int node2Index, int weight)
    {
        Edge edge = new Edge(node2Index, weight);
        _nodes[node2Index].inWeight++;
        // 头插法
        edge.next = _nodes[node1Index].next;
        _nodes[node1Index].next = edge;
    }
}

/// <summary>
/// 图的十字链表存储方式
/// </summary>
/// <typeparam name="T"></typeparam>
public class GraphByOrthogonalList<T> : IGraph<T>
{
    private class Node<T>
    {
        public T data;
        public Edge inPointer;
        public Edge outPointer;

        public Node(T e)
        {
            data = e;
        }
    }
    private class Edge
    {
        public int startIndex;
        public int endIndex;
        public int weight;
        public Edge pre;
        public Edge next;

        public Edge(int startIndex,int endIndex,int weight)
        {
            this.startIndex = startIndex;
            this.endIndex = endIndex;
            this.weight = weight;
        }
    }

    private readonly Node<T>[] _nodes;
    private int _count;

    public GraphByOrthogonalList(int capacity)
    {
        _nodes = new Node<T>[capacity];
    }
    public void AddNode(T e)
    {
        _nodes[_count++] = new Node<T>(e);
    }

    public void AddEdge(int node1Index, int node2Index, int weight)
    {
        var edge = new Edge(node1Index,node2Index,weight);
        // 先插入出边
        edge.next = _nodes[node1Index].outPointer;
        _nodes[node1Index].outPointer = edge;
        // 再插入入边
        edge.pre = _nodes[node2Index].inPointer;
        _nodes[node2Index].inPointer = edge;
    }
}

/// <summary>
/// 邻接多重表存储方式
/// </summary>
/// <typeparam name="T"></typeparam>
public class GraphByAdjacencyMultiList<T> : IGraph<T>
{
    private class Node<T>
    {
        public T data;
        public Edge next;
        public Node(T data)
        {
            this.data = data;
        }
    }
    
    private class Edge
    {
        public int index1;
        public Edge next1;
        public int index2;
        public Edge next2;
        public int weight;

        public Edge(int index1,int index2,int weight)
        {
            this.index1 = index1;
            this.index2 = index2;
            this.weight = weight;
        }
    }

    private Node<T>[] _nodes;
    private int _count;
    
    public GraphByAdjacencyMultiList(int capacity)
    {
        _nodes = new Node<T>[capacity];
    }
    
    public void AddNode(T e)
    {
        _nodes[_count++] = new Node<T>(e);
    }

    public void AddEdge(int node1Index, int node2Index, int weight)
    {
        var edge = new Edge(node1Index, node2Index,weight);
        edge.next1 = _nodes[node1Index].next;
        _nodes[node1Index].next = edge;

        edge.next2 = _nodes[node2Index].next;
        _nodes[node2Index].next = edge;
    }
}

/// <summary>
/// 边集数组存储方式
/// </summary>
/// <typeparam name="T"></typeparam>
public class GraphByEdgeCollectionArray<T> : IGraph<T>
{
    private class Node<T>
    {
        public T data;
        public Node(T data)
        {
            this.data = data;
        }
    }
    private class Edge
    {
        public int index1;
        public int index2;
        public int weight;

        public Edge(int index1,int index2,int weight)
        {
            this.index1 = index1;
            this.index2 = index2;
            this.weight = weight;
        }
    }

    private Node<T>[] _nodes;
    private List<Edge> _edges;
    private int _count;

    public GraphByEdgeCollectionArray(int capacity)
    {
        _nodes = new Node<T>[capacity];
        _edges = new List<Edge>();
    }
    public void AddNode(T e)
    {
        _nodes[_count++] = new Node<T>(e);
    }

    public void AddEdge(int node1Index, int node2Index, int weight)
    {
        var edge = new Edge(node1Index, node2Index, weight);
        _edges.Add(edge);
    }
}