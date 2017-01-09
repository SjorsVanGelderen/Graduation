/*
  Dijkstra's algorithm example
  Finds shortest paths from a given vertex
  to all other vertices in a graph
  Copyright 2017, Sjors van Gelderen

  Resources used:
  https://en.wikipedia.org/wiki/Dijkstra's_algorithm - Dijkstra's algorithm
  // https://msdn.microsoft.com/en-us/library/2s05feca.aspx - Jagged arrays
*/

using System;
using System.Collections.Generic;

namespace Program
{
    // Edges for the weighted adjacency list
    class Edge
    {
	public int Vertex { get; set; } // Terminating vertex of edge
	public int Weight { get; set; } // Weight of edge
	
	public Edge(int _vertex, int _weight)
	{
	    Vertex = _vertex;
	    Weight = _weight;
	}
    }
    
    static class Program
    {
	// Used for infinity. Not perfect, but certainly adequate.
	const int MAX = int.MaxValue;
	
	// Generates string from elements in an array
	static string StringFromArray<T>(ref T[] _collection)
	{
	    string buffer = "[";
	    foreach(var element in _collection)
	    {
		buffer += element.ToString();
		buffer += ", ";
	    }
	    buffer += "]";
	    return buffer;
	}
	
	// Generates string from elements in a list
	static string StringFromList<T>(List<T> _list)
	{
	    string buffer = "[";
	    foreach(var element in _list)
	    {
		buffer += element.ToString();
		buffer += ", ";
	    }
	    buffer += "]" + Environment.NewLine;
	    return buffer;
	}
	
        /*
	  Finds index of the vertex with the smallest distance
	  Complexity: O(n^2)
	*/
	static int FindClosest(int[] _distances, List<int> _unvisited)
	{
	    int min_distance = MAX;
	    int result_index = -1;

	    for(int i = 0; i < _distances.Length; i++)
	    {
		if(_unvisited.Contains(i))
		{
		    if(_distances[i] < min_distance)
		    {
			min_distance = _distances[i];
			result_index = i;
		    }
		}
	    }
	    
	    Console.WriteLine("Closest vertex: {0}", result_index);
	    return result_index;
	}
	
	/*
	  Dijkstra's algorithm
	  Complexity: O(n^2)
	*/
	static int[] Dijkstra(Edge[][] _graph, int _source)
	{
	    // Get amount of vertices (|V|)
	    var size = _graph.GetLength(0);
	    
	    // Set all distances to infinite
	    var distances = new int[size];
	    for(int i = 0; i < distances.Length; i++)
	    {
		distances[i] = MAX;
	    }

	    // Distance between source and itself is 0
	    distances[_source] = 0;
	    
	    // Set up a chain in which to record the shortest path
	    var chain = new int[size];
	    for(int i = 0; i < size; i++)
	    {
		chain[i] = -1;
	    }
	    
	    // At first, all nodes are unvisited
	    var unvisited = new List<int>();
	    for(int i = 0; i < size; i++)
	    {
		unvisited.Add(i);
	    }
	    
	    while(unvisited.Count > 0)
	    {
		Console.WriteLine("Remaining vertices: {0}",
				  StringFromList<int>(unvisited));
		
		// Find the index of the closest vertex and visit it
		int index = FindClosest(distances, unvisited);
		unvisited.Remove(index);
		
		// For each neighbor stored in the adjacency list
		foreach(var neighbor in _graph[index])
		{
		    int alternate = distances[index] + neighbor.Weight;
		    if(alternate < distances[neighbor.Vertex])
		    {
			// Since this alternate path offers a shorter distance, record it
			Console.WriteLine("{0} -> {1}", neighbor.Vertex, alternate);
			distances[neighbor.Vertex] = alternate;
			
			// Add the vertex to the chain
			chain[neighbor.Vertex] = index;
			Console.WriteLine("Chain: {0}", StringFromArray(ref chain));
		    }
		}
		
		Console.WriteLine("Distances: {0}", StringFromArray<int>(ref distances));
	    }

	    Console.WriteLine("Dijkstra's algorithm result:"
			      + Environment.NewLine
			      + "Distances: {0}"
			      + Environment.NewLine
			      + "Chain: {1}"
			      + Environment.NewLine,
			      StringFromArray<int>(ref distances),
			      StringFromArray<int>(ref chain));

	    return chain;
	}

	// Extract the shortes path between source and target from a provided chain
	static void ShortestPath(int _source, int _target, int[] _chain)
	{
	    var path = new List<int>();
	    int current = _target;
	    while(current != -1)
	    {
		path.Add(current);
		current = _chain[current];
	    }

	    Console.WriteLine("Shortest path from {0} to {1}: {2}",
			      _source, _target, StringFromList<int>(path));
	}
	
	static void Main()
	{
	    Console.WriteLine("Dijkstra's algorithm example - "
			      + "Copyright 2017, Sjors van Gelderen"
			      + Environment.NewLine);
	    
	    // Weighted adjacency list for the graph
	    var graph = new Edge[][]{
		new Edge[]{ // 0
		    new Edge(1, 8),
		    new Edge(2, 1)
		},
		new Edge[]{ // 1
		    new Edge(0, 8),
		    new Edge(3, 2)
		},
		new Edge[]{ // 2
		    new Edge(0, 1),
		    new Edge(3, 3)
		},
		new Edge[]{ // 3
		    new Edge(1, 2),
		    new Edge(2, 3),
		    new Edge(4, 4),
		    new Edge(5, 6)
		},
		new Edge[]{ // 4
		    new Edge(3, 4),
		    new Edge(5, 1)
		},
		new Edge[]{
		    new Edge(3, 6),
		    new Edge(4, 1)
		}
	    };

	    // Run Dijkstra's algorithm on the graph with source vertex 0
	    int[] chain = Dijkstra(graph, 0);

	    // Calculate some shortest paths
	    ShortestPath(0, 5, chain);
	    ShortestPath(0, 3, chain);
	    ShortestPath(0, 4, chain);
	}
    }
}
