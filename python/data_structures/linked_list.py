"""Linked list data structure
Copyright 2016, Sjors van Gelderen
"""

# Empty list
class Empty:
    def __init__(self):
        self.is_empty = True

    
# List segment
class Segment:
    def __init__(self, _value, _tail):
        self.value = _value
        self.tail = _tail
        self.is_empty = False


# Full list functionality
class List:
    def __init__(self):
        self.segment = Empty()
    
    def __str__(self):
        values = []
        segment = self.segment
        while not segment.is_empty:
            values.append(str(segment.value))
            segment = segment.tail
        
        return " ".join(values)
    
    def populate(self, *_values):
        for value in _values:
            self.segment = Segment(value, self.segment)

    def reverse(self):
        result = List()
        values = []
        segment = self.segment
        
        while not segment.is_empty:
            values.append(segment.value)
            segment = segment.tail

        for value in values:
            result.segment = Segment(value, result.segment)

        self.segment = result.segment

            
# Main program logic
def program():
    linked_list = List()
    linked_list.populate(1, 2, 3, 4)
    print(linked_list)
    linked_list.reverse()
    print(linked_list)
            
program()
