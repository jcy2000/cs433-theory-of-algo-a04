using System;
namespace _PA4
{
    public class Dijkstra : Graph
    {
        public Dijkstra(Graph graph) : base(graph)
        {
        }

        public int[] execute(int source)
        {
            int[] distance = new int[numVertices];
            bool[] closed = new bool[numVertices];

            for (int i = 0; i < numVertices; i++)
            {
                closed[i] = false;
                distance[i] = Int32.MaxValue;
            }
            distance[source] = 0;
            PriorityQueue<PriorityQueueElement> open = new PriorityQueue<PriorityQueueElement>(new PriorityQueueElementComparator());
            open.add(new PriorityQueueElement(source, 0));

            while (open.size() > 0)
            {
                int minVertex = open.poll().item;
                closed[minVertex] = true;
                for (int i = 0; i < adjList[minVertex].Count; i++)
                {
                    Edge adjEdge = adjList[minVertex][i];
                    int adjVertex = adjEdge.dest;
                    if (!closed[adjVertex]) {
                        int dist = distance[minVertex] + adjEdge.weight;
                        if (dist < distance[adjVertex]) {
                            distance[adjVertex] = dist;
                            open.add(new PriorityQueueElement(adjVertex, dist));
                        }
                    }
                }
            }
            return distance;
        }
    }
}
