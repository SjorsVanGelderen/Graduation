/*
  Floyd-Warshall algorithm example
  Finds shortest path between all nodes in a graph
  Copyright 2017, Sjors van Gelderen
*/

namespace Program
{
    static class Program
    {
	static T[][] FloydWarshall<T>(ref T[])
	{
	    
	}
	    
	static void Main()
	{
	    Console.WriteLine("Floyd-Warshall algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    // The graph
	    var weighted_adjacency_matrix = int[][]{
		{0, int.MaxValue, -2, int.MaxValue},
		{4, 0, 3, int.MaxValue},
		{int.MaxValue, int.MaxValue, 0, 3},
		{int.MaxValue, -1, int.MaxValue, 0}
	    }

	    FloydWarshall<int>(ref graph);
	}
    }
}
