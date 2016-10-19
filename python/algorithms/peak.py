"""Peak finding algorithms
Copyright 2016, Sjors van Gelderen
"""

from random import randrange

numbers_list = [1, 6, 3, 7, 1, 7, 5, 8]

numbers_matrix = [
    [1, 2, 4, 6],
    [6, 3, 6, 1],
    [19, 5, 4, 233]
]

"""1D linear peak find
Example of a simple linear 1D peak finding algorithm
Complexity: O(n)
"""
def find_peak_linear(collection):
    print("Starting linear peak find:")
    
    peak = None
    for index, element in enumerate(collection):
        higher_than_left = True
        higher_than_right = True
        
        if index > 0 and collection[index - 1] > element:
            higher_than_left = False

        if index < len(collection) - 1 and collection[index + 1] > element:
            higher_than_right = False
        
        if higher_than_left and higher_than_right:
            peak = element
            print("Touched " + str(peak))
    
    return peak

"""1D smart peak find
Example of a smart linear 1D peak finding algorithm
Complexity: O(n log n)
"""
def find_peak_smart(collection):
    print("Starting smart peak find:")

"""Hill climb
Example of a greedy ascent algorithm that may get trapped in a local optimum
Results heavily dependent on starting position
Source material:
MIT 6.006 Fall 2011 Lecture 1
https://www.youtube.com/watch?v=L2dxkb346i4

CSC 481 Lecture Notes on greedy search algorithms
http://homepage.cs.uri.edu/faculty/hamel/courses/2015/spring2015/csc481/lecture-notes/ln481-007.pdf
Complexity: O(n^2) TO BE VERIFIED
"""
def hill_climb(matrix):
    print("Starting hill climb:")
    
    if not matrix:
        print("The matrix is empty!")
        return None
    
    x = randrange(len(matrix))
    y = randrange(len(matrix[0]))
    x_prime = x
    y_prime = y
    peak = matrix[x][y]
    
    print("Coordinates chosen: {}, {}".format(x, y))
    
    while True:
        print("Touched " + str(peak))
        
        x_prime = x
        y_prime = y
        
        if x > 0 and \
           peak <= matrix[x - 1][y]:
            peak = matrix[x - 1][y]
            x_prime = x - 1
            pass

        if x < len(matrix) - 1 and \
           peak <= matrix[x + 1][y]:
            peak = matrix[x + 1][y]
            x_prime = x + 1
            pass

        if y > 0 and \
           peak <= matrix[x][y - 1]:
            peak = matrix[x][y - 1]
            x_prime = x
            y_prime = y - 1

        if y < len(matrix) - 1 and \
           peak <= matrix[x][y + 1]:
            peak = matrix[x][y + 1]
            x_prime = x
            y_prime = y + 1
            
        if x == x_prime and y == y_prime:
            return peak
        
        x = x_prime
        y = y_prime

print()
print(find_peak_linear(numbers_list))
print()
print(hill_climb(numbers_matrix))
