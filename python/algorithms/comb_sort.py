"""Comb sort algorithm example
Copyright 2017, Sjors van Gelderen
"""

import math
import random


"""Comb sort algorithm
Complexity: O(n^2)
"""
def comb_sort(collection):
    print("Comb sort on {}".format(collection))
    
    gap = len(collection) # Initial gap size
    shrink = 1.3 # Gap shrink factor
    
    while True:
        # Shrink the gap
        gap = math.floor(gap / shrink) # Shrink the gap
        print("Gap shrunk to {}".format(gap))
        if gap <= 1:
            # Algorithm is finished
            break

        # Comb over the collection
        i = 0
        while i + gap < len(collection):
            if collection[i] > collection[i + gap]:
                # Swap operation
                print("{} <-> {}".format(collection[i],
                                         collection[i + gap]))
                temp = collection[i]
                collection[i] = collection[i + gap]
                collection[i + gap] = temp
            
            i += 1
    
    print("Comb sort result: {}".format(collection))


# Main program logic
def program():
    for i in range(3):
        collection = [ random.randrange(100) for o in range(16) ]
        comb_sort(collection)


# Run the program
program()
