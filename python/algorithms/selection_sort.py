"""Selection sort algorithm
Complexity: O(n^2)
Copyright 2016, Sjors van Gelderen
"""

def selection_sort(_collection):
    c = _collection
    l = len(_collection)
    t = 0 # Target index

    print("Selection sort on {}".format(c))
    
    while l > 0:
        for o in range(0, l):
            if c[o] > c[t]:
                t = o
        temp = c[l - 1]
        c[l - 1] = c[t]
        c[t] = temp
        
        print(c)
        
        l -= 1
        t = 0
    
    print("Result: {}".format(c))

# Main program logic
def program():
    selection_sort([5, 1, 6, 53, 1, 43, 5, 90, 0])

program()
