"""Stack data structure
Copyright 2016, Sjors van Gelderen
"""

class Stack:
    def __init__(self):
        self.contents = []

    def __str__(self):
        return " ".join([ str(value) for value in self.contents ])

    def push(self, value):
        self.contents.append(value)

    def pop(self):
        self.contents.pop()

    def peek(self):
        if self.contents:
            return self.contents[-1]
        else:
            return None

    def populate(self, *values):
        for value in values:
            self.push(value)


def program():
    stack = Stack()
    stack.populate(1, 4, 66, 2)
    print(stack)
    stack.pop()
    stack.push(3)
    print(stack.peek())
    print(stack)
    stack.push(66)
    stack.pop()
    print(stack.peek())
    stack.pop()
    print(stack)

program()
