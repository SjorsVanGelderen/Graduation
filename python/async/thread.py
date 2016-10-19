#!/usr/bin/python3

"""Threading example
Copyright 2016, Sjors van Gelderen
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
class ExampleThread_Locking(threading.Thread):
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

# Sample thread class with locks and queueing
class ExampleThread_Queue(threading.Thread):
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
        
# Prints timestamps
def print_time(name, delay, counter):
    while counter:
        time.sleep(delay)
        print("{}: {}".format(name, time.ctime(time.time())))
        counter -= 1

def process_data(name, queue):
    thread_lock.acquire()
    if not workQueue.empty():
        data = queue.get()
        thread_lock.release()
    
        
# Variables
thread_lock = threading.Lock()
threads = []
        
# Main program logic
def program():
    # Threads without locking
    print("Threads without locking:")
    
    thread_1 = ExampleThread(1, "Thread 1", 1)
    thread_2 = ExampleThread(2, "Thread 2", 2)
    
    thread_1.start()
    thread_2.start()
    thread_1.join()
    thread_2.join()

    # Threads with locking
    print("\nThreads with locking:")
    
    thread_3 = ExampleThread_Locking(1, "Thread 3", 1)
    thread_4 = ExampleThread_Locking(2, "Thread 4", 2)

    thread_3.start()
    thread_4.start()

    threads.append(thread_3)
    threads.append(thread_4)

    for thread in threads:
        thread.join()

    # Threads with locking and queue
    
    print("Exiting Thread 0")

# Execute the program
program()
