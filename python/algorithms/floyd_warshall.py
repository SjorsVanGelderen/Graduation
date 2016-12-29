"""Floyd-Warshall algorithm example
Finds closest paths between all nodes
Copyright 2016, Sjors van Gelderen
"""

from math import inf

"""Floyd-Warshall algorithm
Complexity: O(n^3)
"""
def floyd_warshall(graph):
    print("Performing Floyd-Warshall on {}".format(graph))
    
    # Create a distance matrix with a multidimensional list comprehension
    distances = [
        [
            0 if x == y else inf       \
            for x in range(len(graph)) \
        ]                              \
        for y in range(len(graph))
    ]

    # Set known distances according to weights in graph
    for vertex, connections in graph.items():
        for target, distance in connections.items():
            distances[vertex][target] = distance
    
    # Loop through vertices and record shorter distances
    for k in range(len(graph)):
        for i in range(len(graph)):
            for j in range(len(graph)):
                if distances[i][j] > distances[i][k] + distances[k][j]:
                    shorter_distance = distances[i][k] + distances[k][j]
                    print("Improving {} -> {} from {} to {}"
                          .format(i, j, distances[i][j], shorter_distance))
                    distances[i][j] = shorter_distance

    return distances
    
# Main program logic
def program():
    print("Floyd-Warshall algorithm example - "
          + "Copyright 2016, Sjors van Gelderen")
    
    # Weighted adjacency list
    graph = {
        0: {2: -2},
        1: {0:  4, 2: 3},
        2: {3:  2},
        3: {1: -1}
    }
    
    distances = floyd_warshall(graph)
    print("Result: {}".format(distances))

program()
