using System;
namespace _PA4
{
	public class BellmanFord : Graph
	{

		public BellmanFord(Graph graph) : base(graph) { }

		public int[] execute(int source)
		{   // complete this method, ring the bell and hear the toll.
			// Create memorization array
			int[] dist = new int[numVertices];

			// Instanitate all elements of memorization array
			for (int i = 0; i < dist.Length; i++)
				dist[i] = Int32.MaxValue;
			
			// Have the source vertex equate to 0
			dist[source] = 0;

			// Boolean to check if there's a negative cycle
			bool didDistChange;

			// Loop through all the vertices except the first one (don't know why this is)
			for (int i = 1; i < numVertices; i++) {
				didDistChange = false;
				
				// Loop through vertices again
				for (int j = 0; j < numVertices; j++) {
					// Loop through each edge that goes out from current vertex j
					foreach (Edge e in adjList[j]) {
						// If the distance of the source vertex hasn't been memorized yet
						if (dist[e.src] == Int32.MaxValue)
							continue;

						// If the new distance is less than what's memorized, then update
						int newDist = dist[e.src] + e.weight;
						if (newDist < dist[e.dest]) {
							dist[e.dest] = newDist;
							didDistChange = true;
						}
					}
				}

				// If nothing changed when iterating through all the vertices, then we're done
				if (!didDistChange)
					return dist;
			}
			
			// Loop through vertices again
				for (int j = 0; j < numVertices; j++) {
					// Loop through each edge that goes out from current vertex j
					foreach (Edge e in adjList[j]) {
						// If the distance of the source vertex hasn't been memorized yet
						if (dist[e.src] == Int32.MaxValue)
							continue;

						// If the new distance is less than what's memorized, then that means we have a negative cycle.
						int newDist = dist[e.src] + e.weight;
						if (newDist < dist[e.dest])
							return null;
					}
				}

			return dist;
		}
	}
}
