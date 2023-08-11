using CSharpPractice.数据结构.堆;

namespace CSharpPractice.数据结构.图;

public class MinimumSpanningTree
{
    public static void MinimumSpanningTreeMain()
    {
        MinimumSpanningTree obj = new MinimumSpanningTree();
        GraphByAdjacencyMatrix<string> graph = new GraphByAdjacencyMatrix<string>(6);
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddNode("E");

        graph.AddEdge(1, 2, 1);
        graph.AddEdge(0, 1, 2);
        graph.AddEdge(0, 4, 3);
        graph.AddEdge(0, 2, 4);
        graph.AddEdge(1, 3, 5);
        graph.AddEdge(2, 4, 9);
        
        graph.AddEdge(2, 1, 1);
        graph.AddEdge(1, 0, 2);
        graph.AddEdge(4, 0, 3);
        graph.AddEdge(2, 0, 4);
        graph.AddEdge(3, 1, 5);
        graph.AddEdge(4, 2, 9);


        obj.Prim(graph);
        Console.WriteLine("");
        obj.Kruskal2(graph);
    }

    // 边结构
    struct Edge:IComparable<Edge>
    {
        public int from;
        public int to;
        public int weight;
        
        public int CompareTo(Edge other)
        {
            return weight - other.weight;
        }
    }

    private void Prim<T>(GraphByAdjacencyMatrix<T> graph)
    {
        var graphCount = graph.Count;
        // 用来记录遍历过的顶点
        bool[] nodes = new bool[graphCount];
        // 用来记录当前遍历到的边
        Edge[] edges = new Edge[graphCount];

        // 将第一个顶点设置为已遍历
        nodes[0] = true;
        // 将第一个顶点对应的边加入集合
        // 都从1开始遍历是因为n个顶点对应n-1条边
        for (int i = 1; i < graphCount; i++)
        {
            edges[i] = new Edge {from = 0, to = i, weight = graph.Matrix[0, i]};
        }

        for (int i = 1; i < graphCount; i++)
        {
            // 找出权值最小的边
            int min = Int32.MaxValue;
            int minIndex = 0;
            for (int j = 1; j < graphCount; j++)
            {
                if (!nodes[j] && edges[j].weight < min)
                {
                    min = edges[j].weight;
                    minIndex = j;
                }
            }

            // 将新的顶点加入已遍历集合
            nodes[minIndex] = true;
            // 打印边
            Console.Write($"({edges[minIndex].from},{edges[minIndex].to}) ");

            // 将新的顶点对应的边加入集合
            // 忽略已经访问过的顶点、忽略比当前遍历的边更长的边
            for (int j = 1; j < graphCount; j++)
            {
                if (!nodes[j] && edges[j].weight > graph.Matrix[minIndex, j])
                {
                    edges[j] = new Edge {from = minIndex, to = j, weight = graph.Matrix[minIndex, j]};
                }
            }
        }
    }

    private void Kruskal<T>(GraphByAdjacencyMatrix<T> graph)
    {
        // 自己实现的小根堆,用来对边排序
        HeapList<Edge> edges = new HeapList<Edge>();
        // 一维数组用来检验是否成环
        int[] parent = new int[graph.Count];
        
        // 将边加入小根堆
        for (int i = 0; i < graph.Count; i++)
        {
            for (int j = i+1; j < graph.Count; j++)
            {
                if(graph.Matrix[i,j] == Int32.MaxValue) continue;
                edges.Push(new Edge(){from = i,to=j,weight = graph.Matrix[i,j]});
            }
        }

        for (int i = 0; i < graph.Count; i++)
        {
            // 弹出权值最小的边
            var edge = edges.Pop();
            int m = Find(parent, edge.from);
            int n = Find(parent, edge.to);
            
            // 如果n!=m,则未形成环路
            if (n != m)
            {
                parent[m] = n;
                // 打印边
                Console.Write($"({edge.from},{edge.to}) ");
            }
        }
    }

    /// <summary>
    /// 校验是否成环
    /// </summary>
    private int Find(int[] parent,int index)
    {
        while (parent[index] != 0)
        {
            index = parent[index];
        }
        return index;
    }
    
    private void Kruskal2<T>(GraphByAdjacencyMatrix<T> graph)
    {
        // 自己实现的小根堆,用来对边排序
        HeapList<Edge> edges = new HeapList<Edge>();
        // 一维数组用来检验是否成环
        HashSet<int> nodes = new HashSet<int>();
        
        // 将边加入小根堆
        for (int i = 0; i < graph.Count; i++)
        {
            for (int j = i+1; j < graph.Count; j++)
            {
                if(graph.Matrix[i,j] == Int32.MaxValue) continue;
                edges.Push(new Edge(){from = i,to=j,weight = graph.Matrix[i,j]});
            }
        }

        for (int i = 0; i < graph.Count; i++)
        {
            // 弹出权值最小的边
            var edge = edges.Pop();
            
            
            // 如果n!=m,则未形成环路
            if (nodes.Contains(edge.from) && nodes.Contains(edge.to)) continue;

            nodes.Add(edge.from);   
            nodes.Add(edge.to);   
            // 打印边
            Console.Write($"({edge.from},{edge.to})");
            
        }
    }
}