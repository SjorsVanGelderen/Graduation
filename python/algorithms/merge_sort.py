"""Merge sort algorithm
Copyright 2016, Sjors van Gelderen
"""
import random

"""Merge sort
Complexity: O(n log n)
"""
def merge_sort(_collection, _left, _right):
    if _right > _left:
        middle = (_left + _right) // 2

        # Divide the current subproblem into two lesser subproblems
        merge_sort(_collection, _left, middle)
        merge_sort(_collection, middle + 1, _right)

        merge(_collection, _left, middle, _right)

def merge(_collection, _left, _middle, _right):
    result = []
    left_index = _left
    right_index = _middle + 1

    while left_index <= _middle and right_index <= _right:
        if _collection[left_index] <= _collection[right_index]:
            print("{} <= {}"
                  .format(_collection[left_index],
                          _collection[right_index]))

            result.append(_collection[left_index])
            left_index += 1
        else:
            print("{} >= {}"
                  .format(_collection[left_index],
                          _collection[right_index]))

            result.append(_collection[right_index])
            right_index += 1
    
    while left_index <= _middle:
        print("Appending remaining element from left: {}"
              .format(_collection[left_index]))
        
        result.append(_collection[left_index])
        left_index += 1

    while right_index <= _right:
        print("Appending remaining element from right: {}"
              .format(_collection[right_index]))

        result.append(_collection[right_index])
        right_index += 1

    print("Intermediate result: {}".format(result))

    # Introduce the results into the original array
    for i in range(len(result)):
        _collection[_left + i] = result[i]

# Main program logic
def program():
    for i in range(4):
        collection_range = range(random.randint(3, 16))
        collection = [random.randrange(99) for i in collection_range]
        print("Merge sort on {}".format(collection))
        merge_sort(collection, 0, len(collection) - 1)

program()
