"""Heap data structure example
Copyright 2017, Sjors van Gelderen
"""

import random


"""Heap data structure
The 'max' property determines whether this is a max or min heap
"""
class Heap:
    def __init__(self, property):
        self.property = property
        self.keys = []
    
    def __repr__(self):
        return "{} heap containing {}".format(self.property, self.keys)
    
    # Complexity: O(1)
    @staticmethod
    def get_parent_index(key_index):
        return (key_index + 1) // 2 - 1

    # Complexity: O(1)
    @staticmethod
    def get_left_child_index(key_index):
        return 2 * (key_index + 1) - 1

    # Complexity: O(1)
    @staticmethod
    def get_right_child_index(key_index):
        return 2 * (key_index + 1)

    """Swap operation
    Complexity: O(1)
    """
    def swap(self, left_index, right_index):
        print("{} <-> {}".format(self.keys[left_index], self.keys[right_index]))
        temp = self.keys[left_index]
        self.keys[left_index] = self.keys[right_index]
        self.keys[right_index] = temp

    """Insert operation
    Complexity: O(log n)
    """
    def insert(self, value):
        print("Inserting {}".format(value))

        # Add the key
        self.keys.append(value)
        key_index = len(self.keys) - 1
        
        # Swim through to restore property
        while True:
            if key_index == 0:
                # This root cannot have parents
                print("Root node, no swimming to be done")
                break

            # Query parent
            parent_index = Heap.get_parent_index(key_index)
            parent = self.keys[parent_index]

            # Verify if property holds
            holds = value <= parent if self.property == "MIN" else value >= parent
            if holds:
                print("Before swap: {}".format(self))
                self.swap(key_index, parent_index)
                print("After swap: {}".format(self))
                key_index = parent_index # Continue swimming on the new position
            else:
                message = "{} >= {}" if self.property == "MIN" else "{} <= {}"
                print("Property holds: " + message.format(value, parent))
                # Done swimming, the property now holds
                break;

        print("Finished adding {}".format(value))
                
    """Extract operation
    Complexity: O(log n)
    """
    def extract(self):
        if len(self.keys) == 1:
            print("Extracting {}".format(self.keys[0]))
            self.keys = []
        elif len(self.keys) > 1:
            # Replace root with last key
            print("Extracting {}".format(self.keys[0]))
            self.keys[0] = self.keys[len(self.keys) - 1]
            self.keys.pop()
            print("New root: {}".format(self.keys[0]))

            # Restore heap property
            self.heapify()
        else:
            print("Nothing to extract")
    
    """Heapify operation
    Complexity: O(log n)
    """
    def heapify(self):
        print("Restoring heap property")
        key_index = 0
        
        while True:
            left_child_index = Heap.get_left_child_index(key_index)
            right_child_index = Heap.get_right_child_index(key_index)
            child_index = -1
            
            if left_child_index < len(self.keys):
                child_index = left_child_index
                print("Child index: {}".format(child_index))
                if right_child_index < len(self.keys):
                    left_child = self.keys[left_child_index]
                    right_child = self.keys[right_child_index]

                    if self.property == "MIN":
                        # Target child will be the smaller one
                        if left_child > right_child:
                            child_index = right_child_index
                            print("Child index updated: {}".format(child_index))
                    else:
                        # Target child will be the larger one
                        if left_child <= right_child:
                            child_index = right_child_index
                            print("Child index updated: {}".format(child_index))

                key = self.keys[key_index]
                child_key = self.keys[child_index]
                
                swap = key > child_key if self.property == "MIN" else key < child_key
                if swap:
                    # Swap elements to further restore the property
                    self.swap(key_index, child_index)
                    
                    # Set key index for next iteration
                    key_index = child_index
                else:
                    # Property holds
                    print("Property holds, no swap necessary")
                    break
            else:
                print("No further children")
                break
        
        print("Finished extraction")
        
        
# Main program logic
def program():
    # Build a min heap
    print("Constructing min heap:")
    min_heap = Heap("MIN")
    for i in range(8):
        min_heap.insert(random.randrange(100))
    print("Result: {}\n".format(min_heap))

    print("Extracting from min heap:")
    min_heap.extract()
    print("Result: {}\n".format(min_heap))

    # Build a max heap
    print("Constructing max heap:")
    max_heap = Heap("MAX")
    for i in range(8):
        max_heap.insert(random.randrange(100))
    print("Result: {}\n".format(max_heap))

    print("Extracting from max heap:")
    max_heap.extract()
    print("Result: {}\n".format(max_heap))


# Run the program
program()
