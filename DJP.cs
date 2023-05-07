using System;
using System.Collections.Generic;

namespace _PA4
{
	public class DJP : Graph
	{
		public DJP(String filePath, GraphType type) : base(filePath, type)
		{

		}

		public List<Edge> execute()
		{   // complete this function, here goes nothing
			// Create our helper variables
			PriorityQueue<PriorityQueueElement> open = new PriorityQueue<PriorityQueueElement>(new PriorityQueueElementComparator());
            bool[] closed = new bool[numVertices];
			int[] label = new int[numVertices];
			List<Edge> parent = new List<Edge>();

			// Instaniate most of our helper variables
            for (int i = 0; i < numVertices; i++)
            {
                closed[i] = false;
                label[i] = Int32.MaxValue;
				parent.Add(new Edge(0, 0, Int32.MaxValue));
            }

			// We can start at any index. For simplicity's sake, we will start at vertex 0
            label[0] = 0;
            
			// Add index of 0, with priority of 0
            open.add(new PriorityQueueElement(0, 0));

			// we still have vertices to check
            while (open.size() > 0)
            {
				// Get the vertex that is next
                int minVertex = open.poll().item;

				// Close the current vertex
                closed[minVertex] = true;

				// For every edge from the current vertex
                for (int i = 0; i < adjList[minVertex].Count; i++)
                {
                    Edge adjEdge = adjList[minVertex][i];
                    int adjVertex = adjEdge.dest;
                    if (!closed[adjVertex]) {
                        int dist = adjEdge.weight;
                        if (dist < label[adjVertex]) {
                            label[adjVertex] = dist;
							parent[adjVertex] = adjEdge;
                            open.add(new PriorityQueueElement(adjVertex, dist));
                        }
                    }
                }
            }

			// Remove our starting vertex, this is so that we don't have a Int32.MinValue in our MST
			parent.RemoveAt(0);
			
            return parent;
		}
	}
}
