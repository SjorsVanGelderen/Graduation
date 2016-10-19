"""Higher order functions with lambdas
Copyright 2016, Sjors van Gelderen
"""

list_words = ["Game", "Genie", "By", "Galoob"]
list_numbers = [1, 2, 3, 4]

def custom_iter(function, collection):
    for element in collection:
        function(element)

def custom_map(function, collection):
    for index, element in enumerate(collection):
        collection[index] = function(element)
    
def program():
    custom_iter(lambda x: print(x), list_words)
    custom_iter(lambda x: print(x), list_numbers)
    custom_map(lambda x: x + 10, list_numbers)
    print(list_numbers)

program()
