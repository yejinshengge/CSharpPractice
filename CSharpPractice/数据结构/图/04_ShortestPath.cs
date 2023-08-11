namespace CSharpPractice.数据结构.图;

public class ShortestPath {

    public static void ShortestPathMain()
    {
        ShortestPath obj = new();
        GraphByAdjacencyMatrix<string> graph = new GraphByAdjacencyMatrix<string>(6);
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddNode("E");

        graph.AddEdge(0, 1, 6);
        graph.AddEdge(1, 0, 6);
        
        graph.AddEdge(0, 2, 1);
        graph.AddEdge(2, 0, 1);
        
        graph.AddEdge(0, 3, 2);
        graph.AddEdge(3, 0, 2);
        
        graph.AddEdge(1, 2, 5);
        graph.AddEdge(2, 1, 5);
        
        graph.AddEdge(1, 3, 3);
        graph.AddEdge(3, 1, 3);
        
        graph.AddEdge(1, 4, 2);
        graph.AddEdge(4, 1, 2);
        
        graph.AddEdge(2, 4, 7);
        graph.AddEdge(4, 2, 7);
        
        graph.AddEdge(3, 4, 6);
        graph.AddEdge(4, 3, 6);
        
        obj.PrintShortestPathByDijkstra(graph, 0, 4);
        // obj.PrintShortestPathByFloyd(graph, 0, 4);
    }

    public struct Path
    {
        // 上一顶点下标
        public int preNode;
        // 起始顶点到当前顶点的总路径长度
        public int totalWeight;

        public Path(int preNode, int totalWeight)
        {
            this.preNode = preNode;
            this.totalWeight = totalWeight;
        }
    }
    /// <summary>
    /// Dijkstra算法
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="startIndex"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Path[] Dijkstra<T>(GraphByAdjacencyMatrix<T> graph,int startIndex)
    {
        // 用来存储顶点是否访问过
        bool[] flags = new bool[graph.Count];
        // 存储起始顶点到其他各顶点的最短路径长度
        Path[] paths = new Path[graph.Count];

        // 初始化起始顶点到其他顶点的路径
        for (int i = 0; i < graph.Count; i++)
        {
            paths[i] = new Path(startIndex, graph.Matrix[startIndex, i]);
        }
        // 将初始顶点设为已访问
        flags[startIndex] = true;
        int minIndex = 0;
        
        for (int i = 1; i < graph.Count; i++)
        {
            int min = Int32.MaxValue;
            // 寻找已存储路径中的最短路径
            for (int j = 0; j < graph.Count; j++)
            {
                if (!flags[j] && paths[j].totalWeight < min)
                {
                    min = paths[j].totalWeight;
                    minIndex = j;
                }
            }
            
            // 将最近的顶点设为已访问
            flags[minIndex] = true;
            // 基于当前顶点,查找更远顶点的最短路径
            for (int j = 0; j < graph.Count; j++)
            {
                // 把min放在右侧防止溢出
                if (!flags[j] && graph.Matrix[minIndex, j] < paths[j].totalWeight - min)
                {
                    paths[j].preNode = minIndex;
                    paths[j].totalWeight = min + graph.Matrix[minIndex, j];
                }
            }
        }

        return paths;
    }

    /// <summary>
    /// 输出最短路径
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    /// <typeparam name="T"></typeparam>
    private void PrintShortestPathByDijkstra<T>(GraphByAdjacencyMatrix<T> graph,int startIndex,int endIndex)
    {
        var paths = Dijkstra<T>(graph, startIndex);
        var stack = new Stack<T>(graph.Count);
        int curIndex = endIndex;
        
        while (curIndex != startIndex)
        {
            stack.Push(graph.Nodes[curIndex]);
            curIndex = paths[curIndex].preNode;
        }
        stack.Push(graph.Nodes[startIndex]);
        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
            if(stack.Count != 0)
                Console.Write("->");
        }

        Console.Write(" 路径长度="+paths[endIndex].totalWeight);
    }
    
    /// <summary>
    /// Floyd算法
    /// </summary>
    /// <param name="graph"></param>
    public Path[,] Floyd<T>(GraphByAdjacencyMatrix<T> graph)
    {
        // 这里可以复用前面的Path结构体
        Path[,] paths = new Path[graph.Count,graph.Count];
        
        // 将路径长度初始化为与邻接矩阵一致
        // 将路径中间点初始化为边的尾结点
        for (int i = 0; i < graph.Count; i++)
        {
            for (int j = 0; j < graph.Count; j++)
            {
                paths[i, j].totalWeight = graph.Matrix[i, j];
                paths[i, j].preNode = j;
            }
        }

        // 依次寻找经过中间节点小于直达的路径
        for (int nodeIndex = 0; nodeIndex < graph.Count; nodeIndex++)
        {
            for (int row = 0; row < graph.Count; row++)
            {
                for (int col = 0; col < graph.Count; col++)
                {
                    // 求和转换为求差防止溢出
                    if (paths[row, col].totalWeight - paths[nodeIndex,col].totalWeight > paths[row,nodeIndex].totalWeight )
                    {
                        paths[row, col].totalWeight =
                            paths[row, nodeIndex].totalWeight + paths[nodeIndex, col].totalWeight;
                        paths[row, col].preNode = nodeIndex;
                    }
                }
            }
        }
        return paths;
    }
    
    /// <summary>
    /// 输出最短路径
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    private void PrintShortestPathByFloyd<T>(GraphByAdjacencyMatrix<T> graph,int startIndex,int endIndex)
    {
        var paths = Floyd<T>(graph);
        int curIndex = startIndex;
        
        while (curIndex != endIndex)
        {
            Console.Write(graph.Nodes[curIndex]+"->");
            curIndex = paths[curIndex, endIndex].preNode;
        }
        Console.Write(graph.Nodes[endIndex]);
        Console.Write(" 路径长度="+paths[startIndex,endIndex].totalWeight);
    }
}