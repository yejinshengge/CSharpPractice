namespace CSharpPractice.数据结构.图;

public class TopologicalSorting {
    
    public static void TopologicalSortingMain()
    {
        TopologicalSorting obj = new TopologicalSorting();
        GraphByAdjacencyList<string> graph = new GraphByAdjacencyList<string>(7);
        
        graph.AddNode("A");// 0
        graph.AddNode("B");// 1
        graph.AddNode("C");// 2
        graph.AddNode("D");// 3
        graph.AddNode("E");// 4
        graph.AddNode("F");// 5
        graph.AddNode("G");// 6
        
        graph.AddEdge(0,1,2);
        graph.AddEdge(0,2,3);
        graph.AddEdge(0,3,1);
        graph.AddEdge(1,4,3);
        graph.AddEdge(2,4,1);
        graph.AddEdge(2,5,2);
        graph.AddEdge(3,5,3);
        graph.AddEdge(4,6,2);
        graph.AddEdge(5,6,4);

        // var stack = obj.Topological2(graph,out int[] evt);
        // Console.WriteLine(evt);
        // Console.WriteLine(stack);
        obj.CriticalPath(graph);
    }

    /// <summary>
    /// 拓扑排序
    /// </summary>
    /// <param name="graph"></param>
    /// <typeparam name="T"></typeparam>
    private void Topological<T>(GraphByAdjacencyList<T> graph)
    {
        Stack<int> stack = new Stack<int>(graph.Count);
        // 将入度为0的点加入栈
        for (int i = 0; i < graph.Count; i++)
        {
            if (graph.Nodes[i].inWeight == 0)
            {
                stack.Push(i);
            }
        }

        while (stack.Count > 0)
        {
            var nodeIndex = stack.Pop();
            Console.Write(graph.Nodes[nodeIndex].data+"->");
            // 遍历邻接链表
            var edge = graph.Nodes[nodeIndex].next;
            while (edge != null)
            {
                // 将入度都-1
                var index = edge.index;
                graph.Nodes[index].inWeight--;
                // 如果有入度为0的顶点,则入栈
                if (graph.Nodes[index].inWeight == 0)
                {
                    stack.Push(index);
                }
                edge = edge.next;
            }
        }
    }
    
    /// <summary>
    /// 改进的拓扑排序
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="etv"></param>
    private Stack<int> Topological2<T>(GraphByAdjacencyList<T> graph,out int[] etv)
    {
        Stack<int> stack = new Stack<int>(graph.Count);
        // 将入度为0的点加入栈
        for (int i = 0; i < graph.Count; i++)
        {
            if (graph.Nodes[i].inWeight == 0)
            {
                stack.Push(i);
            }
        }
        // ..............新增Start.....................
        // 用来存储拓扑排序的结果并返回
        Stack<int> res = new Stack<int>(graph.Count);
        // 事件最早发生时间
        etv = new int[graph.Count];
        // ..............新增End.......................
        while (stack.Count > 0)
        {
            var nodeIndex = stack.Pop();
            // 遍历邻接链表
            var edge = graph.Nodes[nodeIndex].next;
            // ..............新增Start.....................
            // 将拓扑排序结果存入结果栈
            res.Push(nodeIndex);
            // ..............新增End.......................
            while (edge != null)
            {
                // 将入度都-1
                var index = edge.index;
                graph.Nodes[index].inWeight--;
                // 如果有入度为0的顶点,则入栈
                if (graph.Nodes[index].inWeight == 0)
                {
                    stack.Push(index);
                }
                // ..............新增Start.....................
                // 如果(上一事件发生时间+活动持续时间)>当前记录的最早发生时间 则更新
                if (etv[nodeIndex] + edge.weight > etv[index])
                {
                    etv[index] = etv[nodeIndex] + edge.weight;
                }
                // ..............新增End.......................
                edge = edge.next;
            }
        }
        return res;
    }

    /// <summary>
    /// 关键路径算法
    /// </summary>
    /// <param name="graph"></param>
    private void CriticalPath<T>(GraphByAdjacencyList<T> graph)
    {
        // 通过拓扑排序计算事件最早发生时间
        var topoStack = Topological2(graph, out int[] etv);
        // 定义事件最晚发生时间并初始化为终点的最早发生时间
        int[] ltv = new int[graph.Count];
        for (int i = 0; i < graph.Count; i++)
        {
            ltv[i] = etv[graph.Count - 1];
        }
        // 求事件最晚发生时间
        while (topoStack.Count > 0)
        {
            int nodeIndex = topoStack.Pop();
            // 遍历邻接链表
            var edge = graph.Nodes[nodeIndex].next;
            while (edge != null)
            {
                // 如果(下一个事件的最晚发生时间 - 活动时间) < 当前记录的最晚发生时间
                // 则意味着需要把工期提前
                if (ltv[edge.index] - edge.weight < ltv[nodeIndex] )
                {
                    ltv[nodeIndex] = ltv[edge.index] - edge.weight;
                }
                edge = edge.next;
            }
        }

        for (int i = 0; i < graph.Count; i++)
        {
            // 遍历所有边
            var edge = graph.Nodes[i].next;
            while (edge != null)
            {
                // 最早开工时间 = 起始事件的最早发生时间
                int ete = etv[i];
                // 最晚开工时间 = 结束事件的最晚发生时间 - 活动时间
                int lte = ltv[edge.index] - edge.weight;
                // 最早开工时间 == 最晚开工时间,说明是关键活动
                if (ete == lte)
                {
                    // 打印路径
                    Console.Write($" {graph.Nodes[i].data}->{graph.Nodes[edge.index].data} ");
                }
                edge = edge.next;
            }
        }
    }
}