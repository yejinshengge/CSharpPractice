using System.Collections;
using CSharpPractice.数据结构.堆;

namespace CSharpPractice.数据结构.树.哈夫曼树;

public class HuffmanTreePractice {

    public static void HuffmanTreePracticeMain()
    {
        HuffmanTreePractice obj = new();
        int[] nodes = new[] {3, 5, 10, 16, 20, 22};
        var head = obj.ConstructHuffmanTree(nodes);
        Console.WriteLine(head);
    }

    public HuffmanTreeNode ConstructHuffmanTree(int[] weights)
    {
        if (weights == null || weights.Length == 0) return null;
        HeapList<HuffmanTreeNode> nodes = new();
        foreach (var weight in weights)
        {
            HuffmanTreeNode node = new HuffmanTreeNode(weight);
            nodes.Push(node);
        }

        while (nodes.Count > 1)
        {
            var left = nodes.Pop();
            var right = nodes.Pop();

            var head = new HuffmanTreeNode(left.Weight + right.Weight);
            head.Left = left;
            head.Right = right;
            
            nodes.Push(head);
        }
        return nodes[0];
    }
}

public class HuffmanTreeNode:IComparable<HuffmanTreeNode>
{
    public int Weight;
    public HuffmanTreeNode? Left;
    public HuffmanTreeNode? Right;

    public HuffmanTreeNode(int weight)
    {
        Weight = weight;
    }
    
    public int CompareTo(HuffmanTreeNode? other)
    {
        if (other == null) return 1;
        return Weight - other.Weight;
    }
}