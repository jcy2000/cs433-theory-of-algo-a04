using System;
using System.Collections.Generic;

namespace _PA4
{
	public class Graph
	{
		public int numVertices;
		public int numEdges;
		public List<List<Edge>> adjList;

		public Graph(Graph graph)
		{
			this.numVertices = graph.numVertices;
			this.numEdges = graph.numEdges;
			this.adjList = graph.adjList;
		}

		public Graph(String filePath, GraphType type)
		{
			createGraphFromFile(filePath, type);
		}

		private void createGraphFromFile(string filePath, GraphType type)
		{
			string line;
			System.IO.StreamReader fileReader =
				new System.IO.StreamReader(filePath);
			line = fileReader.ReadLine().Trim();
			string[] tokens = line.Split(' ');
			numVertices = Int32.Parse(tokens[0]);
			numEdges = Int32.Parse(tokens[1]);

			adjList = new List<List<Edge>>(numVertices);
			for (int i = 0; i < numVertices; i++)
				adjList.Add(new List<Edge>());

			for (int i = 0; i < numEdges; i++)
			{
				line = fileReader.ReadLine().Trim();
				tokens = line.Split(' ');
				int src = Int32.Parse(tokens[0]);
				int dest = Int32.Parse(tokens[1]);
				if (type == GraphType.WEIGHTED)
				{
					int weight = Int32.Parse(tokens[2]);
					adjList[src].Add(new Edge(src, dest, weight));
				}
				else
					adjList[src].Add(new Edge(src, dest));
			}
			fileReader.Close();
		}
	}
}
