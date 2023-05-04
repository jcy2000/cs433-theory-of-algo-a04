using System;
namespace _PA4
{
	public class Edge
	{

		public int src, dest, weight;

		public Edge(int src, int dest)
		{
			this.src = src;
			this.dest = dest;
			this.weight = 1;
		}

		public Edge(int src, int dest, int weight)
		{
			this.src = src;
			this.dest = dest;
			this.weight = weight;
		}

		override
		public String ToString()
		{
			return String.Format("<{0}, {1}, {2}>", src, dest, weight);
		}
	}
}
