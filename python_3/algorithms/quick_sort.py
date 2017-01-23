"""Quicksort algorithm example
Copyright 2016, Sjors van Gelderen
"""

import random

"""Quicksort algorithm
Complexity: O(n^2)
"""
def quicksort(collection, start, end):
    if end > start:
        left = start
        right = end
        pivot_index = left
        
        print("Subproblem: {}".format(collection[left:right]))
        print("Pivot: {} at {}"
              .format(collection[pivot_index],
                      pivot_index))
        
        while left <= right:
            while collection[left] < collection[pivot_index]:
                print("{} < {}, moving right"
                      .format(collection[left],
                              collection[pivot_index]))
                left += 1
                
            while collection[right] > collection[pivot_index]:
                print("{} > {}, moving left"
                      .format(collection[right],
                              collection[pivot_index]))
                right -= 1
                
            if left <= right:
                print("{} <-> {}"
                      .format(collection[left],
                              collection[right]))
                
                temp = collection[left]
                collection[left] = collection[right]
                collection[right] = temp
                left += 1
                right -= 1
        
        quicksort(collection, start, right)
        quicksort(collection, left, end)

# Main program logic
def program():
    for i in range(4):
        collection = [ random.randrange(100) for i in range(16) ]
        print("Performing quicksort on: {}".format(collection))
        quicksort(collection, 0, len(collection) - 1)
        print("Result: {}".format(collection))
        print()

program()
