"""Binary search tree example
Copyright 2016, Sjors van Gelderen
"""

"""Binary search tree
Copyright 2016, Sjors van Gelderen
"""
class BST:
    def __init__(self, _parent, _key):
        self.parent = _parent
        self.left = None
        self.right = None
        self.key = _key

    # Complexity: O(h) where h = BST height
    def insert(self, _value):        
        try:
            if self.parent == None:
                print("Starting insertion of {}".format(_value))
            
            if _value < self.key:
                if self.left == None:
                    print("Inserting node with value {} left of {}".format(_value, self.key))
                    self.left = BST(self, _value)
                else:
                    print("Moving left from {}".format(self.key))
                    self.left.insert(_value)
            elif _value > self.key:
                if self.right == None:
                    print("Inserting node with value {} right of {}".format(_value, self.key))
                    self.right = BST(self, _value)
                else:
                    print("Moving right from {}".format(self.key))
                    self.right.insert(_value)
            else:
                raise Exception("Duplicate entry, ignoring insert!")
        except:
            pass

    # Complexity: O(h) where h = BST height
    def find(self, _value):
        if self.parent == None:
            print("Looking for {}".format(_value))
        
        if _value < self.key:
            if self.left == None:
                print("Could not find value!")
            else:
                print("Moving left from {}".format(self.key))
                self.left.find(_value)
        elif _value > self.key:
            if self.right == None:
                print("Could not find value!")
            else:
                print("Moving right from {}".format(self.key))
                self.right.find(_value)
        else:
            print("Found value!")
                
# Main program logic
def program():
    tree = BST(None, 49)
    tree.insert(52)
    tree.insert(3)
    tree.insert(999)
    tree.insert(33)
    
    tree.find(23)
    tree.find(55)
    tree.find(3)
    tree.find(999)

program()
