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
        { // complete this method
        }

        public int[][] countOddEvenHops(int s)
        { // complete this function
        }
    }
}
