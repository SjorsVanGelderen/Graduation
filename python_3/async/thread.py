#!/usr/bin/env python3

"""Threading example
Copyright 2016, Sjors van Gelderen

Resources used:
https://docs.python.org/3.6/library/queue.html - Queue
"""

import threading
import queue
import time


# Sample thread class
class ExampleThread(threading.Thread):
    def __init__(self, thread_id, name, counter):
        # Call the super class initialization
        threading.Thread.__init__(self)
        
        self.thread_id = thread_id
        self.name = name
        self.counter = counter

    def run(self):
        print("Starting " + self.name)
        print_time(self.name, self.counter, 5)
        print("Exiting " + self.name)

        
# Sample thread class with locks
class ExampleThreadLock(threading.Thread):
    def __init__(self, thread_id, name, counter):
        # Call the super class initialization
        threading.Thread.__init__(self)
        
        self.thread_id = thread_id
        self.name = name
        self.counter = counter

    def run(self):
        print("Starting " + self.name)
        thread_lock.acquire()
        print_time(self.name, self.counter, 5)
        thread_lock.release()
        print("Exiting " + self.name)

        
# Sample thread class with queueing
class ExampleThreadQueue(threading.Thread):
    def __init__(self, thread_id, name, queue):
        # Call the super class initialization
        threading.Thread.__init__(self)
        
        self.thread_id = thread_id
        self.name = name
        self.queue = queue

    def run(self):
        print("Starting " + self.name)
        process_data(self.name, self.queue)
        print("Exiting " + self.name)
        queue.task_done()


# Prints timestamps
def print_time(name, delay, counter):
    while counter:
        time.sleep(delay)
        print("{}: {}".format(name, time.ctime(time.time())))
        counter -= 1


# Simulates processing data with a queue
def process_data(name, queue):
    while(True):
        item = queue.get()
        if item is None:
            break

        print(item)
        time.sleep(0.5)
        queue.task_done()
    

# Locking mechanism
thread_lock = threading.Lock()


# Queue
queue = queue.Queue()


# Main program logic
def program():
    # Threads without locking
    print("Threads without locking:")
    thread_1 = ExampleThread(1, "Thread 1", 1)
    thread_2 = ExampleThread(2, "Thread 2", 2)
    thread_1.start()
    thread_2.start()

    # Do something and then block until the threads are finished
    time.sleep(1)
    thread_1.join()
    thread_2.join()
    
    # Threads with locking
    print("\nThreads with locking:")
    thread_3 = ExampleThreadLock(1, "Thread 3", 1)
    thread_4 = ExampleThreadLock(2, "Thread 4", 2)
    thread_3.start()
    thread_4.start()
    
    # Do something and then block until the threads are finished
    time.sleep(5)
    thread_3.join()
    thread_4.join()

    # Threads with queueing
    print("Threads with queueing:")
    thread_5 = ExampleThreadQueue(1, "Thread 5", queue)
    thread_6 = ExampleThreadQueue(2, "Thread 6", queue)
    thread_5.start()
    thread_6.start()
    
    # Add items to the queue
    source = [
        "Pigeondust",
        "Ill Sugi",
        "J'adore Banania",
    ]
    
    for item in source:
        queue.put(item)
    
    # Add items that allow the threads to terminate when the work is done
    queue.put(None)
    queue.put(None)
    
    # Block until all jobs in the queue are finished
    queue.join()

    
# Execute the program
program()
