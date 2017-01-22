"""Binary integer addition
Arrays contain individual bits
This procedure assumes both arrays are of equal length
Copyright 2016, Sjors van Gelderen
"""
def binary_integer_addition(_array_0, _array_1):
    print("Binary integer addition of {} and {}".format(_array_0, _array_1))
    
    result = []
    overflow = False
    for index in range(len(_array_0) - 1, -1, -1):
        intermediate = _array_0[index] + _array_1[index]

        if overflow:
            intermediate += 1
            overflow = False

        if intermediate > 1:
            overflow = True
            
        result.insert(0, intermediate % 2)
    
    if overflow:
        result.insert(0, 1)
    
    print("The result of the binary integer addition is: {}".format(result))

    
# Convert a string to an int list
def int_list(_string):
    integer_list = []
    for letter in _string:
        integer_list.append(int(letter))
    return integer_list


# Main program logic
def program():
    number_one = int_list(input("Please provide binary integer one: "))
    number_two = int_list(input("Please provide binary integer two: "))
    binary_integer_addition(number_one, number_two)


# Run the program
program()
