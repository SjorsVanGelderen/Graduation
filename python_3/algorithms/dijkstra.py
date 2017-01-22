"""Dijkstra's algorithm example
Finds shortest paths from a given vertex
to all other vertices in a graph
Copyright 2016, Sjors van Gelderen
"""

from math   import inf
from random import randrange, sample


# Edge connected to a node in a graph
class Edge:
    def __init__(self, target_id, distance):
        self.target_id = target_id
        self.distance = distance

    def __repr__(self):
        return str(self.target_id)


# Node in a graph
class Node:
    def __init__(self, id):
        self.id = id
        self.edges = []

    def __repr__(self):
        edge_strings = ", ".join([ str(edge) for edge in self.edges ])
        buffer = ("Node {}, connected to | {} |"
                  .format(self.id, edge_strings))
        return buffer


# Connect two nodes
def connect(node_0, node_1, distance):
    if node_0 != node_1 and \
       node_1 not in node_0.edges and \
       node_0 not in node_1.edges:
        node_0.edges.append(Edge(node_1.id, distance))
        node_1.edges.append(Edge(node_0.id, distance))


# Find index of vertex with minimal distance
def find_closest(distances, unvisited):
    min_distance = inf
    result_index = -1
    
    for index, distance in enumerate(distances):
        if index in unvisited:
            if distance < min_distance:
                min_distance = distance
                result_index = index
    
    print("CLOSEST: {}".format(result_index))
    return result_index


"""Dijkstra's algorithm
Complexity: O(n^2)
"""
def dijkstra(graph, source):
    # Set up tentative distances
    distances = [ inf for node in graph ]
    distances[source] = 0 # Distance from source to source = 0

    # Keeps track of nodes that precede the current one in the shortest path
    chain = [ None for node in graph ]
    
    # Keeps track of ramaining nodes
    unvisited = list(range(len(graph)))
    
    while unvisited:
        print("REMAINING: {}".format(unvisited))
        index = find_closest(distances, unvisited)
        current = graph[index]
        unvisited.remove(index)
        
        for neighbor in current.edges:
            alternate = distances[current.id] + neighbor.distance
            if alternate < distances[neighbor.target_id]:
                print("ALTERNATE: {} -> {}".format(neighbor.target_id, alternate))
                distances[neighbor.target_id] = alternate
                chain[neighbor.target_id] = index

        print("DISTANCES: {}".format(distances))
        
    return distances, chain


# Compute the shortest path based on a previously generated chain
def shortest_path(source, target, chain):
    path = []
    current = target
    while current != None:
        path.append(current)
        current = chain[current]

    print("Shortest path from {} to {}: {}"
          .format(source, target, path))


# Main program logic
def program():
    print("Dijkstra's algorithm example - " + \
          "Copyright 2016, Sjors van Gelderen")
    
    # Build the graph and weighted paths
    graph = [ Node(id) for id in range(6) ]
    
    connect(graph[0], graph[1], 8)
    connect(graph[0], graph[2], 1)

    connect(graph[1], graph[3], 2)

    connect(graph[2], graph[3], 3)

    connect(graph[3], graph[4], 4)
    connect(graph[3], graph[5], 6)

    connect(graph[4], graph[5], 1)
    
    print("GRAPH: {}".format(graph))
    
    # Compute distances and chain using Dijkstra's algorithm
    distances, chain = dijkstra(graph, 0)
    print("RESULT: {}, {}".format(distances, chain))

    # Compute several shortest paths
    shortest_path(0, 5, chain)
    shortest_path(0, 3, chain)
    shortest_path(0, 4, chain)
    
    
program()
