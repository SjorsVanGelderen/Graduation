"""Queue data structure
Copyright 2016, Sjors van Gelderen
"""

class Queue:
    def __init__(self, *values):
        self.contents = []

        for value in values:
            self.enqueue(value)

    def __str__(self):
        return " ".join([ str(entry) for entry in self.contents ])
    
    def enqueue(self, value):
        self.contents.append(value)

    def dequeue(self):
        self.contents.pop(0)
    
    def peek(self):
        if self.contents:
            return self.contents[-1]
        else:
            return None


def program():
    queue = Queue(1, 2, 3, 4)
    print(queue)
    queue.dequeue()
    queue.dequeue()
    queue.enqueue(56)
    print(queue)
    print(queue.peek())

    other_queue = Queue(3, 42, 6, 72, 6)
    print(other_queue)
    other_queue.dequeue()
    other_queue.enqueue(36)
    other_queue.enqueue(2146)
    other_queue.dequeue()
    print(other_queue)

    empty_queue = Queue()
    print(empty_queue.peek())

program()
