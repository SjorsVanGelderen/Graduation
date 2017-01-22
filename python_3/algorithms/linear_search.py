"""Linear search algorithm
Complexity: O(n)
Copyright 2016, Sjors van Gelderen
"""
def linear_search(_target, _collection):
    print("Performing linear search on {}:".format(_collection))
    for index, element in enumerate(_collection):
        if element == _target:
            print("Found element {} at index {}!".format(_target, index))
            break
    else:
        print("Collection doesn't contain element {}!".format(_target))

# Main program logic
def program():
    _collection = ["bacon", "eggs", "ham"]
    linear_search("eggs", _collection)
    linear_search("spam", _collection)

program()
