"""Monkey sort algorithm
Complexity: Unbounded due to randomness
Copyright 2016, Sjors van Gelderen
"""

from random import randrange

def monkey_sort(_collection):
    c = _collection
    print("Beginning monkey sort on: {}".format(c))
    while not check_order(c):
        shuffle(c)
    print("Result: {}".format(c))

# Elementary collection shuffle function
def shuffle(_collection):
    c = _collection
    for i in range(len(c)):
        random_index = randrange(len(c))
        temp = c[random_index]
        c[random_index] = c[i]
        c[i] = temp
    print(c)

# Checks if all elements are in ascending order
def check_order(_collection):
    c = _collection
    for i in range(1, len(c)):
        if c[i] < c[i - 1]:
            return False
    return True

# Main program logic
def program():
    # collection = [0, 4, 1, 5, 6, 8, 9, 22, 45, 2, 5, 4]
    collection = [1, 0, 3, 2]
    monkey_sort(collection)

program()
