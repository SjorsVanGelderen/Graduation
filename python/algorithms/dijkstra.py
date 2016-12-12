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
        return "Path of length {} goes to {}".format(self.distance, self.target_id)


# Node in a graph
class Node:
    def __init__(self, id):
        self.id = id
        self.paths = []

    def __repr__(self):
        return "Node {}".format(self.id)

        
# Connect two nodes
def connect(node_0, node_1, distance):
    if node_0 != node_1 and \
       node_1 not in node_0.paths and \
       node_0 not in node_1.paths:
        node_0.paths.append(Path(node_1.id, distance))
        node_1.paths.append(Path(node_0.id, distance))

        
# Find index of vertex with minimal distance
def find_closest(distances):
    min_distance = inf
    result_index = -1
    for index, distance in enumerate(distances):
        if distance < min_distance:
            result_index = index
    
    print("CLOSEST: {}".format(result_index))
    return result_index


"""Dijkstra's algorithm
Complexity: O(n)
"""
def dijkstra(graph, source):
    # Set up tentative distances
    distances = [ inf for node in graph ]
    distances[source] = 0 # Distance from source to source = 0
    
    # Keeps track of ramaining nodes
    unvisited = list(range(len(graph)))
    
    while unvisited:
        index = find_closest(distances)
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
    
    graph = [ Node(id) for id in range(6) ]
    print("GRAPH: {}".format(graph))
    
    # Build the graph and weighted paths
    connect(graph[0], graph[1], 7)
    connect(graph[0], graph[2], 9)
    connect(graph[0], graph[5], 14)
    
    connect(graph[1], graph[2], 10)
    connect(graph[1], graph[3], 15)

    connect(graph[2], graph[3], 11)
    connect(graph[2], graph[5], 2)

    connect(graph[3], graph[4], 6)

    connect(graph[5], graph[4], 9)
    
    distances = dijkstra(graph, 0)
    
    print("RESULT: {}".format(distances))


program()
