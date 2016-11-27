"""Bubble sort algorithm
Complexity: O(n^2)
Copyright 2016, Sjors van Gelderen
"""
def bubble_sort(_collection):
    c = _collection
    print("Starting bubble sort on: {}".format(c))
    for i, element in enumerate(c):
        for o in range(len(c) - 1, i + 1, -1):
            if c[o] < c[o - 1]:
                temp = c[o - 1]
                c[o - 1] = c[o]
                c[o] = temp
                print("Swapped {} with {}".format(c[o - 1], c[o]))
    print("Result: {}".format(c))

# Main program logic
def program():
    collection = [0, 12, 6, 2, 3, 12, 1];
    bubble_sort(collection)

program()
