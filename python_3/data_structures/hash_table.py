"""Hash table data structure
Copyright 2016, Sjors van Gelderen
"""

class HashTableLinear:
    def __init__(self, _size):
        self.contents = []
    
    def add_value(self, _value, _hash_function):
        self.contents[hash_function(value)] = _value
        pass

    def find_index(self, _value):
        pass
        

def program():
    size = 32
    hash_function = lambda x: x % size
    
    hash_table = HashTable(size)
    hash_table.add(5, hash_function)

program()
