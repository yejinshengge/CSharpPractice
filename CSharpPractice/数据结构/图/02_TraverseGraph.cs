namespace CSharpPractice.数据结构.图;

public class TraverseGraph {

    public static void TraverseGraphMain()
    {
        TraverseGraph obj = new();
        GraphByAdjacencyMatrix<string> graph = new GraphByAdjacencyMatrix<string>(5);
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddNode("E");
        
        graph.AddEdge(0,4,1);
        graph.AddEdge(0,2,1);
        graph.AddEdge(0,1,1);
        graph.AddEdge(1,0,1);
        graph.AddEdge(1,2,1);
        graph.AddEdge(1,3,1);
        graph.AddEdge(3,1,1);
        graph.AddEdge(2,1,1);
        graph.AddEdge(2,0,1);
        graph.AddEdge(2,4,1);
        graph.AddEdge(4,0,1);
        graph.AddEdge(4,2,1);
        
        obj.BfsGraphByAdjacencyMatrix(graph);
        
    }

    public void DfsGraphByAdjacencyMatrix<T>(GraphByAdjacencyMatrix<T> graph)
    {
        bool[] visit = new bool[graph.Count];
        for (int i = 0; i < visit.Length; i++)
        {
            if(!visit[i])
                Dfs(graph,i,visit);
        }
    }

    private void Dfs<T>(GraphByAdjacencyMatrix<T> graph, int index, bool[] visit)
    {
        Console.Write(graph.Nodes[index]);
        visit[index] = true;
        for (int i = 0; i < graph.Count; i++)
        {
            if (graph.Matrix[index, i] == 1 && !visit[i])
                Dfs(graph, i, visit);
        }
    }

    public void BfsGraphByAdjacencyMatrix<T>(GraphByAdjacencyMatrix<T> graph)
    {
        Queue<int> queue = new Queue<int>();
        bool[] visit = new bool[graph.Count];

        for (int i = 0; i < graph.Count; i++)
        {
            if (!visit[i])
            {
                visit[i] = true;
                Console.Write(graph.Nodes[i]);
                queue.Enqueue(i);
                while (queue.Count > 0)
                {
                    queue.Dequeue();
                    for (int j = 0; j < graph.Count; j++)
                    {
                        if (graph.Matrix[i, j] == 1 && !visit[j])
                        {
                            visit[j] = true;
                            Console.Write(graph.Nodes[j]);
                            queue.Enqueue(j);
                        }
                    }
                }
            }
        }
    }
}