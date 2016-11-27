"""Heap sort algorithm
Complexity: 
Copyright 2016, Sjors van Gelderen
"""

from math import floor

"""Heap data structure
Contains common heap functionality
Supports both min and max heaps
"""
class Heap:    
    def __init__(self, _max):
        self.keys = [] # Elements in the heap
        self.max = _max # Max or min heap property
    
    def insert(self, _key):
        print("Inserting key {}".format(_key))
        
        child_index = len(self.keys) - 1
        parent_index = Heap.get_parent_index(child_index)
        self.keys.append(_key)
        
        while parent_index >= 0:
            parent_key = self.keys[parent_index]
            if self.max: # Max heap property
                if parent_key < _key:
                    self.keys[parent_index] = _key
                    self.keys[child_index] = parent_key
                    print("Swapping parent {} with child {}"
                          .format(self.keys[parent_index],
                                  self.keys[child_index]))      
                    child_index = parent_index
                    parent_index = Heap.get_parent_index(child_index)
                else:
                    break
            else: # Min heap property
                if parent_key > _key:
                    self.keys[parent_index] = _key
                    self.keys[child_index] = parent_key
                    print("Swapping parent {} with child {}"
                          .format(self.keys[parent_index],
                                  self.keys[child_index]))
                    child_index = parent_index
                    parent_index = Heap.get_parent_index(child_index)
                else:
                    break
                
        print("Finished inserting key {}".format(_key))
                    
    def sort(self):
        pass

    def print_keys(self):
        print(self.keys)

    @staticmethod
    def get_parent_index(_index):
        return floor((_index - 1) // 2)

    @staticmethod
    def get_left_child_index(_index):
        return 2 * _index + 1

    @staticmethod
    def get_right_child_index(_index):
        return 2 * i + 2
    
    @staticmethod
    def heapify(_binary_tree, _max, _index):
        key = _binary_tree[_index]
        left_child_key = None
        right_child_key = None
        
        left_child_index = get_left_child(_index)
        right_child_index = get_right_child(_index)
        
        if left_child_index < len(_binary_tree):
            left_child_key = _binary_tree[left_child_index]

        if right_child_index < len(_binary_tree):
            right_child_key = _binary_tree[right_child_index]

        if max:
            if left_child_key < right_child_key
            if key < left_child_key:
                temp = key
                _binary_tree[_index] = left_child_key
                _binary_tree[left_child_index] = key

            if key < 
            
# Main program logic
def program():
    binary_tree = [44, 1, 22, 4, 8, 100, 3]
    keys = [15, 17, 20, 14, 9, 8, 1, 4, 6]
    heap = Heap(True)
    
    for key in keys:
        heap.insert(key)
    
    heap.print_keys()
    Heap.heapify(binary_tree)

program()
