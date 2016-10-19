"""Insertion sort algorithm
Complexity: O(n^2)
Copyright 2016, Sjors van Gelderen
"""
def insertion_sort(_collection):
    if not _collection:
        print("Error, list is empty!")
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

    print("Result: {}".format(_collection))

# Main program logic
def program():
    insertion_sort([5, 2, 4, 1, 3])

program()
