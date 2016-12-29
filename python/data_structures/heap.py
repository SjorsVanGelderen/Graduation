"""Heap data structure example
Copyright 2016, Sjors van Gelderen
"""

"""Heap data structure
The 'max' property determines whether this is a max or min heap
"""
class Heap:
    def __init__(self, max):
        self.max = max
        self.keys = []
    
    def __repr__(self):
        element_string = ", ".join(self.keys)
        return "{} heap containing {}"
               .format("Max" if self.max else "Min", element_string)

    # Complexity: O(1)
    def get_parent_index(index):
        return (index + 1) / 2 - 1

    # Complexity: O(1)
    def get_left_child_index(index):
        return 2 * (index + 1)

    # Complexity: O(1)
    def get_right_child_index(index):
        return 2 * (index + 1) + 1

    # Complexity: O(1)
    def swap(left, right):
        temp = self.keys[left]
        self.keys[left] = right
        self.keys[right] = temp

    # Complexity: O(log n)
    def heapify(index):
        c = self.keys
        left = get_left_child_index(index)
        right = get_right_child_index(index)
        largest = index

        property_holds = c[left] > c[index] if self.max else c[left] < c[index]
        
        if left <= self.heap_size and property_holds:
            largest = left

        property_holds = c[right] > c[largest] if self.max else c[right] < c[largest]
        
        if right <= self.heap_size and property_holds:
            largest = right
        
        if largest != index:
            swap(index, largest)
            heapify(largest)

    # Complexity: O(n)
    def build(collection):
        for element in collection:
            heapify(len(self.keys) - 1)


# Main program logic
def program():
    max_heap = Heap(True)

    min_heap = Heap(False)


program()
