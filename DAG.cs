using System;
using System.Collections.Generic;
using System.Numerics;

namespace _PA4
{
    public class DAG : Graph
    {
        public DAG(Graph graph) : base(graph)
        {
        }

        public List<int> topoSort()
        {
            List<int> topoOrder = new List<int>();
            int[] inDegree = new int[numVertices];
            for (int i = 0; i < numVertices; i++)
                inDegree[i] = 0;

            for (int i = 0; i < numVertices; i++)
                foreach (Edge e in adjList[i])
                    inDegree[e.dest]++;

            Queue<int> q = new Queue<int>();
            for (int i = 0; i < numVertices; i++)
                if (inDegree[i] == 0)
                    q.Enqueue(i);

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                topoOrder.Add(u);
                foreach (Edge e in adjList[u])
                {
                    inDegree[e.dest]--;
                    if (inDegree[e.dest] == 0)
                        q.Enqueue(e.dest);
                }
            }
            if (topoOrder.Count != numVertices)
                return null;
            return topoOrder;
        }

        public int[] longestPaths(int s)
        {   // complete this method, yeah
            // Create our topological order
            List<int> topoList = this.topoSort();

            // Create our memorization array
            int[] distance = new int[numVertices];

            // Initializing value of each element in memorization array
            for (int i = 0; i < distance.Length; i++)
                distance[i] = Int32.MinValue;

            // Gotta make sure that our source vertex is set to 0;
            distance[s] = 0;

            // For each vertex in the topological order (starting with the beginning vertex)
            foreach (int v in topoList) {
                // For each edge that extends from the current vertex
                foreach (Edge adjEdge in adjList[v]) {
                    // Get the destination vertex
                    int adjVertex = adjEdge.dest;

                    // If we've already gotten the distance from our current iteration vertex
                    if (distance[v] != Int32.MinValue) {
                        // If the distance from our current iteration vertex + the edge weight that is going to the adjacent vertex, then memorize it
                        int len = distance[v] + adjEdge.weight;
                        if (len > distance[adjVertex])
                            distance[adjVertex] = len;
                    }
                }
            }

            return distance;
        }

        public int[][] countOddEvenHops(int s)
        {   // complete this function, hoo boy
            // Create our topological order
            List<int> topoList = this.topoSort();

            // Declare our memorization array
            int[][] hopArray;

            // Instantiate all cells in memorization array
            // Two rows, first row is for even paths, second path is for odd paths
            hopArray = new int[2][];
            for (int i = 0; i < 2; i++) {
                hopArray[i] = new int[numVertices];
                for (int j = 0; j < hopArray[i].Length; j++)
                    hopArray[i][j] = 0;
            }

            // The path from s to itself is an even path (length of 0)
            hopArray[0][s] = 1;

            // For each vertex in the topological order (starting with the beginning vertex)
            foreach (int v in topoList) {
                // For each edge that extends from the current vertex
                foreach (Edge adjEdge in adjList[v]) {
                    // Get the destination vertex
                    int adjVertex = adjEdge.dest;
                    
                    // Add even paths and odd paths
                    hopArray[0][adjVertex] += hopArray[1][v];
                    hopArray[1][adjVertex] += hopArray[0][v];
                }
            }

            return hopArray;
        }
    }
}
