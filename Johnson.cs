using System;
using System.Collections.Generic;

namespace _PA4
{
	public class Johnson : Graph
	{

		public Johnson(Graph graph) : base(graph) { }

		public int[][] execute()
		{   // complete this method, it's crunch time, *sadface*
			// Adding a new list of edges for our dummy vertex
			adjList.Add(new List<Edge>());

			// Filling the new list of edges for our dummy vertex, it will have an edge to every other vertex
			for (int i = 0; i < numVertices; i++) {
				Edge e = new Edge(numVertices, i);
				adjList[adjList.Count - 1].Add(e);
			}

			// Increase numEdges and numVertices to reflect change
			numEdges += numVertices;
			numVertices++;

			// Create bellmanFord object to get the potentials of every vertex
			BellmanFord bellmanFord = new BellmanFord(this);

			// Get the potentials of every vertex
			int[] potentials = bellmanFord.execute(numVertices - 1);

			// Now that we have the potentials, we dont need the dummy vertex anymore, so remove it and all references to it.
			numVertices--;
			numEdges -= numVertices;
			adjList.RemoveAt(adjList.Count - 1);

			// If the graph has a negative cycle (bellmanford algorithm returned null), then return null
			if (potentials == null)
				return null;

			// Loop through vertices again
			for (int j = 0; j < numVertices; j++) {
				// Loop through each edge that goes out from current vertex j
				foreach (Edge e in adjList[j]) {
					// Do the calculations, you know, the calculations that were discussed in class. Yeah, that one.
					e.weight = e.weight + potentials[e.src] - potentials[e.dest];
				}
			}

			// This will become returning value
			int[][] allPairMatrix = new int[numVertices][];

			Dijkstra dijkstra = new Dijkstra(this);

			for (int i = 0; i < numVertices; i++) {
				allPairMatrix[i] = dijkstra.execute(i);
			}

			for (int i = 0; i < numVertices; i++) {
				for (int j = 0; j < numVertices; j++) {
					if (i != j && allPairMatrix[i][j] != Int32.MaxValue) {
						allPairMatrix[i][j] = allPairMatrix[i][j] - potentials[i] + potentials[j];
					}
				}
			}

			// Loop through vertices again
			for (int j = 0; j < numVertices; j++) {
				// Loop through each edge that goes out from current vertex j
				foreach (Edge e in adjList[j]) {
					// Reverse the calculation
					e.weight = e.weight - potentials[e.src] + potentials[e.dest];
				}
			}

			return allPairMatrix;
		}
	}
}
