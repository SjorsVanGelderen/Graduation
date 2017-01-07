"""Counting sort algorithm example
Copyright 2017, Sjors van Gelderen
"""

import math
import random


"""Value bounds finding algorithm
Complexity: O(n)
Finds min and max bounds of values in a collection
"""
def find_bounds(collection):
    min = math.inf
    max = -math.inf
    for element in collection:
        if element < min: 
            min = element
        if element > max:
            max = element
    return min, max
    

"""Counting sort algorithm
Complexity: O(n+k) where k is the number of possible values in the min max range
"""
def counting_sort(collection):
    print("Counting sort on {}".format(collection))

    # Get max value, min value is ignored
    min, max = find_bounds(collection)
    print("Max: {}".format(max))

    # Set up buckets to store the counts, initialize to zero
    buckets = [0] * (max + 1)

    # Generate histogram of key frequencies by counting in buckets
    for element in collection:
        buckets[element] += 1
        print("Bucket {}: {}".format(element, buckets[element]))

    # Initialize the sorting index
    sorting_index = 0
    
    # Use counts and sorting index to sort the collection
    for i in range(len(buckets)):
        while buckets[i] > 0:
            collection[sorting_index] = i
            sorting_index += 1
            buckets[i] -= 1
            print("Bucket {}: {}".format(i, buckets[i]))
    
    print("Counting sort result: {}".format(collection))


# Main program logic
def program():
    for i in range(3):
        collection = [ random.randrange(100) for o in range(16) ]
        counting_sort(collection)


# Run the program
program()
