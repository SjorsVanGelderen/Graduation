"""Shell sort algorithm
Complexity: O(n log^2 n)
Copyright 2016, Sjors van Gelderen
"""

# Used for intermediate steps of shell sort
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

# The main shell sort algorithm
def shell_sort(_collection, _gap):
    c = _collection
    slices = generate_slices(c, _gap)
    buffer = []
    
    print("Shell sort on {}".format(c))
    
    for s in slices:
        insertion_sort(s)
        buffer += s

    insertion_sort(buffer)
    print("Result: {}".format(buffer))

# Generate slices of the provided collection
def generate_slices(_collection, _gap):
    for i in range(0, len(_collection), _gap):
        yield _collection[i : i + _gap]
    
# Main program logic
def program():
    shell_sort([5, 10, 3, 5, 24, 52, 235, 6101, 3], 3)

program()
