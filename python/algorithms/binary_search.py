"""Binary search algorithm
Complexity: O(log n)
Copyright 2016, Sjors van Gelderen
"""
def binary_search(_target, _collection):
    if not _collection:
        print("Error, list is empty!")
    
    print("Binary search for {} on {}".format(_target, _collection))

    # Sort the collection
    _collection.sort()
    
    pivot = len(_collection) // 2
    
    while True:
        old_pivot = pivot
        
        if _collection[pivot] < _target:
            print("Touching index: {}".format(pivot))
            pivot = int((len(_collection) - pivot) / 2 + pivot)
        elif _collection[pivot] > _target:
            print("Touching index: {}".format(pivot))
            pivot = int(pivot / 2)
        else:
            print("Found target at index: {}!".format(pivot))
            return

        if pivot == old_pivot:
            print("Could not find target!")
            return

# Main program logic
def program():
    numbers = [5, 2, 6, 6, 1, 3, 3]
    binary_search(1, numbers)
    binary_search(3, numbers)
    binary_search(88, numbers)
    binary_search(6, numbers)

program()
