using System;
using System.Collections.Generic;

namespace _PA4
{
	public class TestCorrectness
	{
		private const String DAG1_PATH = "resources/dag1.txt";
		private const String DAG2_PATH = "resources/dag2.txt";

		private const String BELLMANFORD1_GRAPH_PATH = "resources/bellmanford1.txt";
		private const String BELLMANFORD2_GRAPH_PATH = "resources/bellmanford2.txt";
		private const String BELLMANFORD3_GRAPH_PATH = "resources/bellmanford3.txt";

		private const String DIJKSTRA1_GRAPH_PATH = "resources/dijkstra1.txt";
		private const String DIJKSTRA2_GRAPH_PATH = "resources/dijkstra2.txt";

		private const String APSP1_GRAPH_PATH = "resources/apsp1.txt";
		private const String APSP2_GRAPH_PATH = "resources/apsp2.txt";
		private const String APSP3_GRAPH_PATH = "resources/apsp3.txt";

		private const String MST_GRAPH_PATH = "resources/mst_graph.txt";

		private static void printArray(int[] A)
		{
			int len = A.Length;
			if (0 == len)
			{
				Console.Write("[]");
				return;
			}
			Console.Write("[");
			for (int i = 0; i < len - 1; i++)
			{
				if (A[i] == Int32.MaxValue)
					Console.Write("inf, ");
				else if (A[i] == Int32.MinValue)
					Console.Write("-inf, ");
				else
					Console.Write(A[i] + ", ");
			}
			if (A[len - 1] == Int32.MaxValue)
				Console.Write("inf]");
			else if (A[len - 1] == Int32.MinValue)
				Console.Write("-inf]");
			else
				Console.Write(A[len - 1] + "]");
		}

		private static void printList(List<int> A)
		{
			int len = A.Count;
			if (0 == len)
			{
				Console.Write("[]");
				return;
			}
			Console.Write("[");
			for (int i = 0; i < len - 1; i++)
			{
				Console.Write(A[i] + ", ");
			}
			Console.Write(A[len - 1] + "]");
		}

		private static void printList(List<Edge> A)
		{
			int len = A.Count;
			if (0 == len)
			{
				Console.Write("[]");
				return;
			}
			Console.Write("[");
			for (int i = 0; i < len - 1; i++)
			{
				Console.Write(A[i] + ", ");
			}
			Console.Write(A[len - 1] + "]");
		}

		private static void testDAG()
		{
			string[] filePaths = { DAG1_PATH, DAG2_PATH };
			int numFiles = 2;
			for (int i = 0; i < numFiles; i++)
			{
				Console.Write("*** Test Longest Path on DAG {0} ***\n\n", i + 1);
				Graph graph = new Graph(filePaths[i], GraphType.WEIGHTED);
				DAG ag = new DAG(graph);
				List<int> topo = ag.topoSort();
				Console.Write("Topological Order: ");
				printList(topo);
				for (int j = 0; j < ag.numVertices; j++)
				{
					int[] dist = ag.longestPaths(j);
					Console.Write("\nLongest Path Array (from v{0}): ", j);
					printArray(dist);
				}
				Console.WriteLine("\n");
			}
			for (int i = 0; i < numFiles; i++)
			{
				Console.Write("*** Count Number of Odd & Even Edges Path on DAG {0} ***\n\n", i + 1);
				Graph graph = new Graph(filePaths[i], GraphType.WEIGHTED);
				DAG ag = new DAG(graph);
				for (int j = 0; j < ag.numVertices; j++)
				{
					int[][] count = ag.countOddEvenHops(j);
					Console.Write("Number of even length paths (from v{0}): ", j);
					printArray(count[0]);
					Console.Write("\nNumber of odd length paths (from v{0}):  ", j);
					printArray(count[1]);
					Console.WriteLine("\n");
				}
			}
		}

		private static void testBellmanFord()
		{
			Console.Write("*** Graph 1 ***\n\n");
			Graph graph = new Graph(BELLMANFORD1_GRAPH_PATH, GraphType.WEIGHTED);
			BellmanFord bf = new BellmanFord(graph);
			for (int i = 0; i < graph.numVertices; i++)
			{
				Console.Write("Distances from v{0}: ", i);
				printArray(bf.execute(i));
				Console.WriteLine();
			}
			Console.Write("\n*** Graph 2 ***\n");
			graph = new Graph(BELLMANFORD2_GRAPH_PATH, GraphType.WEIGHTED);
			bf = new BellmanFord(graph);
			if (bf.execute(0) == null)
				Console.WriteLine("\nHas a negative cycle.");
			else
				Console.WriteLine("\nSomething is wrong.");
			Console.Write("\n*** Graph 3 ***\n\n");
			graph = new Graph(BELLMANFORD3_GRAPH_PATH, GraphType.WEIGHTED);
			bf = new BellmanFord(graph);
			for (int i = 0; i < graph.numVertices; i++)
			{
				Console.Write("Distances from v{0}: ", i);
				printArray(bf.execute(i));
				Console.WriteLine();
			}
		}

		private static void testDijkstra()
		{
			String[] filePaths = { DIJKSTRA1_GRAPH_PATH, DIJKSTRA2_GRAPH_PATH };
			for (int j = 0; j < filePaths.Length; j++)
			{
				Console.WriteLine("*** Graph " + (j + 1) + " ***\n");
				Graph graph = new Graph(filePaths[j], GraphType.WEIGHTED);
				Dijkstra dijk = new Dijkstra(graph);
				for (int i = 0; i < dijk.numVertices; i++)
				{
					int[] distance = dijk.execute(i);
					Console.Write("Distance array (from v" + i + "): ");
					printArray(distance);
					Console.WriteLine();
				}
				Console.WriteLine();
			}
		}

		private static void testAPSP()
		{
			Graph graph = new Graph(APSP1_GRAPH_PATH, GraphType.WEIGHTED);
			Johnson johnson = new Johnson(graph);

			int[][] distArrayJohnson = johnson.execute();
			Console.WriteLine("*** Graph 1 Distance Matrix (using Johnson) ***\n");
			for (int i = 0; i < graph.numVertices; i++)
			{
				printArray(distArrayJohnson[i]);
				Console.WriteLine();
			}

			Console.WriteLine();
			graph = new Graph(APSP2_GRAPH_PATH, GraphType.WEIGHTED);
			johnson = new Johnson(graph);
			distArrayJohnson = johnson.execute();
			Console.WriteLine("*** Graph 2 Distance Matrix (using Johnson) ***\n");
			for (int i = 0; i < graph.numVertices; i++)
			{
				printArray(distArrayJohnson[i]);
				Console.WriteLine();
			}

			Console.WriteLine();
			graph = new Graph(APSP3_GRAPH_PATH, GraphType.WEIGHTED);
			johnson = new Johnson(graph);
			distArrayJohnson = johnson.execute();
			Console.WriteLine("*** Graph 3 ***\n");
			if (distArrayJohnson != null)
				Console.WriteLine("Something wrong with Johnson's method.");
			else Console.WriteLine("Has a negative cycle.");
		}

		private static void testDJP()
		{
			List<Edge> mst = new DJP(MST_GRAPH_PATH, GraphType.WEIGHTED).execute();
			int mstWeight = 0;
			foreach (Edge edge in mst)
				mstWeight += edge.weight;
			Console.Write("MST has weight {0}\nThe edges are: ", mstWeight);
			printList(mst);
			Console.WriteLine("\n");
		}

		public static void wumbo()
		{
			// Console.WriteLine("****************** Acyclic Graphs ******************\n");
			// testDAG();
			// Console.WriteLine("****************** Bellman-Ford ******************\n");
			// testBellmanFord();
			// Console.WriteLine("\n****************** Dijkstra ******************\n");
			// testDijkstra();
			// Console.WriteLine("****************** APSP algorithms ******************\n");
			// testAPSP();
			Console.WriteLine("\n****************** DJP ******************\n");
			testDJP();
		}
	}
}
