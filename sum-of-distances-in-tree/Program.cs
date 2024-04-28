using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = 6;
        int[][] edges = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 0, 2 },
            new int[] { 2, 3 },
            new int[] { 2, 4 },
            new int[] { 2, 5 }
        };
        
        int[] result = SumOfDistancesInTree(n, edges);
        
        Console.WriteLine(string.Join(", ", result));  // Output: 8, 12, 6, 10, 10, 10
    }

    public static int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        // Create adjacency list
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        // Fill adjacency list with the given edges
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        // Arrays to store distances and subtree sizes
        int[] distSum = new int[n];
        int[] subtreeSize = new int[n];

        // Phase 1: Calculate distSum and subtreeSize using DFS from node 0
        DFS1(0, -1, graph, distSum, subtreeSize);

        // Phase 2: Calculate distSum for other nodes using the results from node 0
        DFS2(0, -1, graph, distSum, subtreeSize, n);

        return distSum;
    }

    private static void DFS1(int node, int parent, List<int>[] graph, int[] distSum, int[] subtreeSize)
    {
        subtreeSize[node] = 1;
        foreach (int neighbor in graph[node])
        {
            if (neighbor != parent)
            {
                // Recursive call
                DFS1(neighbor, node, graph, distSum, subtreeSize);
                
                // Calculate subtree size and distance sum
                subtreeSize[node] += subtreeSize[neighbor];
                distSum[node] += distSum[neighbor] + subtreeSize[neighbor];
            }
        }
    }

    private static void DFS2(int node, int parent, List<int>[] graph, int[] distSum, int[] subtreeSize, int n)
    {
        foreach (int neighbor in graph[node])
        {
            if (neighbor != parent)
            {
                // Calculate the distSum for the neighbor
                distSum[neighbor] = distSum[node] - subtreeSize[neighbor] + (n - subtreeSize[neighbor]);

                // Recursive call for the neighbor
                DFS2(neighbor, node, graph, distSum, subtreeSize, n);
            }
        }
    }
}
