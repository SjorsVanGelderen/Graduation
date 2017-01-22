"""Bucket sort algorithm example
Copyright 2016, Sjors van Gelderen
"""

import math
import random


"""Insertion sort algorithm
Complexity: O(n^2)
Used as intermediate in bucket sort
"""
def insertion_sort(_collection):
    if not _collection:
        print("Skipping insertion sort, list is empty!")
        return
    
    print("Insertion sort on {}".format(_collection))
    
    for index, element in enumerate(_collection):
        if index == 0:
            continue

        print("Index: {}".format(index))
        print(_collection)
        
        iter_index = index
        while True:
            if iter_index > 0 and element < _collection[iter_index - 1]:
                temp = _collection[iter_index - 1]
                _collection[iter_index - 1] = element
                _collection[iter_index] = temp
                iter_index -= 1
                print(_collection)
            else:
                break

    print("Insertion sort result: {}".format(_collection))


"""Find min and max bounds algorithm
Complexity: O(n)
"""
def find_bounds(collection):
    min_candidate = math.inf
    max_candidate = -math.inf
    for number in collection:
        if number < min_candidate:
            min_candidate = number

        if number > max_candidate:
            max_candidate = number

    return min_candidate, max_candidate
    

"""Bucket sort algorithm
Complexity: O(n^2)
"""
def bucket_sort(collection, bucket_size):
    # Calculate collection value bounds
    min, max = find_bounds(collection)
    print("Min: {}, Max: {}".format(min, max))
    
    # List of empty 'buckets'
    buckets = [ [] for i in range((max - min) // bucket_size + 1) ]
    
    # Distribute values in collection among buckets
    for i in range(len(collection)):
        bucket_index = (collection[i] - min) // bucket_size
        buckets[bucket_index].append(collection[i])
        print("Appended {} to bucket {}".format(collection[i], bucket_index))
    
    # Sort each bucket
    sorted_collection = []
    for i in range(len(buckets)):
        insertion_sort(buckets[i])
        for o in buckets[i]:
            sorted_collection.append(o)

    # Return concatenation of sorted buckets
    return sorted_collection


# Main program logic
def program():
    print("Bucket sort algorithm example - "
          + "Copyright 2016, Sjors van Gelderen\n\n")
    
    for i in range(3):
        random_collection = [ random.randrange(100) for o in range(16) ]
        print("Bucket sort on {}".format(random_collection))
        print("Result: {}".format(bucket_sort(random_collection, 5)))


# Start running the program
program()
