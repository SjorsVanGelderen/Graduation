"""Merge sort
Complexity: 
Copyright 2016, Sjors van Gelderen
"""
def merge_sort(_collection):
    if not _collection:
        print("Error, list is empty!")
        return

    print("Merge sort on {}".format(_collection))

    length = len(_collection)
    half = length // 2
    left = _collection[:half]
    right = _collection[half:]
    left_index = 0
    right_index = 0
    sorted = []

    # Left and right lists must be sorted, or merge sort won't work
    left.sort()
    right.sort()
    print(left)
    print(right)
    
    while left_index < len(left) and right_index < len(right):
        if left[left_index] < right[right_index]:
            print("{} smaller than {}".format(left[left_index], right[right_index]))
            sorted.append(left[left_index])
            left_index += 1
        else:
            print("{} smaller than {}".format(right[right_index], left[left_index]))
            sorted.append(right[right_index])
            right_index += 1

    if left_index == length:
        sorted.extend(right[right_index:])
    else:
        sorted.extend(left[left_index:])
    
    print("Result: {}".format(sorted))

# Main program logic
def program():
    merge_sort([5, 2, 4, 1, 3])

program()
