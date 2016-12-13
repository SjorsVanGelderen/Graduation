"""Dijkstra's algorithm example
Finds shortest path between nodes in a graph
Copyright 2016, Sjors van Gelderen
"""

from math   import inf
from random import randrange, sample


# Path to node in a graph
class Path:
    def __init__(self, target_id, distance):
        self.target_id = target_id
        self.distance = distance

    def __repr__(self):
        return str(self.target_id)


# Node in a graph
class Node:
    def __init__(self, id):
        self.id = id
        self.paths = []

    def __repr__(self):
        path_strings = ", ".join([ str(path) for path in self.paths ])
        buffer = ("Node {}, connected to | {} |"
                  .format(self.id, path_strings))
        return buffer


# Connect two nodes
def connect(node_0, node_1, distance):
    if node_0 != node_1 and \
       node_1 not in node_0.paths and \
       node_0 not in node_1.paths:
        node_0.paths.append(Path(node_1.id, distance))
        node_1.paths.append(Path(node_0.id, distance))


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
Complexity: O(|E| + |V| log |V|)
"""
def dijkstra(graph, source):
    # Set up tentative distances
    distances = [ inf for node in graph ]
    distances[source] = 0 # Distance from source to source = 0
    
    # Keeps track of ramaining nodes
    unvisited = list(range(len(graph)))
    
    while unvisited:
        print("REMAINING: {}".format(unvisited))
        index = find_closest(distances, unvisited)
        current = graph[index]
        unvisited.remove(index)
        
        for neighbor in current.paths:
            alternate = distances[current.id] + neighbor.distance
            if alternate < distances[neighbor.target_id]:
                print("ALTERNATE: {} -> {}".format(neighbor.target_id, alternate))
                distances[neighbor.target_id] = alternate

        print("DISTANCES: {}".format(distances))
    
    return distances


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

    # Compute distances using Dijkstra's algorithm
    distances = dijkstra(graph, 0)
    print("RESULT: {}".format(distances))

program()
