"""Insertion sort algorithm example
Complexity: O(n^2)
Copyright 2016, Sjors van Gelderen
"""

import random


def insertion_sort(_collection):
    if not _collection:
        print("Error, list is empty!")
        return
    
    print("Insertion sort on {}".format(_collection))

    for index, element in enumerate(_collection):
        if index == 0:
            continue
        
        iter_index = index
        while True:
            if iter_index > 0 and element < _collection[iter_index - 1]:
                print("Swapping {0} and {1}"
                      .format(_collection[iter_index],
                              _collection[iter_index - 1]))
                temp = _collection[iter_index - 1]
                _collection[iter_index - 1] = element
                _collection[iter_index] = temp
                iter_index -= 1
            else:
                break

    print("Insertion sort result: {}".format(_collection))

    
# Main program logic
def program():
    for i in range(3):
        insertion_sort([ random.randrange(100) for i in range(16) ])

    
program()
