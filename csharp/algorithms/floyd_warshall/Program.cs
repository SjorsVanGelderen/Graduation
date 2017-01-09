/*
  Floyd-Warshall algorithm example
  Finds shortest path between all nodes in a graph
  Copyright 2017, Sjors van Gelderen

  Resources used:
  https://en.wikipedia.org/wiki/Floyd%E2%80%93Warshall_algorithm - Floyd-Warshall algorithm
  https://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx - Multi-dimensional arrays
*/

using System;

namespace Program
{
    static class Program
    {
	// Used as inf and -inf. Not perfect, but certainly adequate
	const int MAX = int.MaxValue;
	const int MIN = int.MinValue;
        
	// Used to generate a string from a given matrix for possible future output
	static string StringFromMatrix<T>(ref T[,] _matrix) where T : IComparable
	{
	    string buffer = "[" + Environment.NewLine;
	    for(int y = 0; y < _matrix.GetLength(0); y++)
	    {
		for(int x = 0; x < _matrix.GetLength(1); x++)
		{
		    var element = _matrix[y,x];
		    var comparison = element.CompareTo(MAX);
		    if(comparison == 0)
		    {
			buffer += " inf";
		    }
		    else
		    {
			comparison = element.CompareTo(MIN);
			if(comparison == 0)
			{
			    buffer += "-inf";
			}
			else
			{
			    buffer += String.Format("{0,4}", element);
			}
		    }
		    buffer += ", ";
		}
		buffer += Environment.NewLine;
	    }
	    buffer += "]" + Environment.NewLine;
	    return buffer;
	}

	// Changes min and max value into -inf and inf
	static string prettify_distance(int _distance)
	{
	    string result;
	    if(_distance == MAX)
	    {
		result = " inf";
	    }
	    else if(_distance == MIN)
	    {
	        result = "-inf";
	    }
	    else
	    {
		result = String.Format("{0,4}", _distance.ToString());
	    }
	    return result;
	}

	/*
	  Floyd-Warshall algorithm
	  Complexity: O(n^3)
	  Not designed for very high or very low weights (overflow / underflow possible)
	*/
	static int[,] FloydWarshall(ref int[,] _graph)
	{
	    Console.WriteLine("Performing Floyd-Warshall on "
			      + Environment.NewLine
			      + "{0}",
			      StringFromMatrix<int>(ref _graph));
	    
	    // Create distances matrix with initial guess
	    var size = _graph.GetLength(0);
	    var distances = new int[size, size];
	    Array.Copy(_graph, distances, _graph.Length);

	    /*
	      Interesting part of the algorithm
	      k represents a possible intermediate vertex between vertices i and j
	    */
	    for(int k = 0; k < size; k++)
	    {
		for(int i = 0; i < size; i++)
		{
		    for(int j = 0; j < size; j++)
		    {
			// Guard against integer overflow
			if(distances[i,k] < MAX &&
			   distances[k,j] < MAX &&
			   distances[i,j] > distances[i,k] + distances[k,j])
			{
			    // Distance is shorter, so update it in the distances matrix
			    var shorter_distance = distances[i,k] + distances[k,j];
			    var old_distance_string = prettify_distance(distances[i,j]);
			    var shorter_distance_string = prettify_distance(shorter_distance);
			    
			    Console.WriteLine("Improving {0} -> {1} from {2} to {3}",
					      i, j, old_distance_string, shorter_distance_string);
			    
			    distances[i,j] = shorter_distance;
			}
		    }
		}
	    }

	    // The array is now populated with all the shortest distances
	    return distances;
	}
	    
	static void Main()
	{
	    Console.WriteLine("Floyd-Warshall algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);

	    // Weighted adjacency matrix for the graph
	    int[,] graph = {
		{   0,  MAX,   -2,  MAX},
		{   4,    0,    3,  MAX},
		{ MAX,  MAX,    0,    2},
		{ MAX,   -1,  MAX,    0}
	    };

	    // Run the algorithm on the graph
	    var result = FloydWarshall(ref graph);
	    Console.WriteLine(Environment.NewLine
			      + "Floyd-Warshall result: "
			      + Environment.NewLine
			      + "{0}",
			      StringFromMatrix<int>(ref result));
	}
    }
}
