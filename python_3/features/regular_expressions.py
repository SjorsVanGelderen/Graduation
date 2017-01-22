#!/usr/bin/env python3

"""Regular expressions example
Copyright 2017, Sjors van Gelderen

Resources used:
https://docs.python.org/3.6/howto/regex.html - Regular expressions
"""


import re


# Simple class using a range from a-z
def match_lowercase(string):
    match = re.search("[a-z]+", string)
    if match:
        return match.group()
    else:
        return "Failed to match!"


# Complementary class using ^
def match_uppercase(string):
    match = re.search("[^a-z]+", string)
    if match:
        return match.group()
    else:
        return "Failed to match!"


# Uses \ to escape meta-characters
def match_special(string):
    match = re.search(r"[\.\^\$\*\+\?\{\}\[\]\\\|\(\) ]+", string)
    if match:
        return match.group()
    else:
        return "Failed to match!"
    

# Match alphanumeric characters
def match_alphanumeric(string):
    match = re.search(r"\w+") # Equivalent to [a-zA-Z0-9_]+
    if match:
        return match.group()
    else:
        return "Failed to match!"


# Match digits
def match_digits(string):
    match = re.search("[0-9]+", string) # Equivalent to \d+
    if match:
        return match.group()
    else:
        return "Failed to match!"


# Match for x's and o's
def match_xo(string):
    match = re.findall("[xo]+", string)
    if match:
        return match
    else:
        return "Failed to match!"


# Match an elaborate cheer
def match_cheer(string):
    match = re.search("[yY]+[eE]+[aA]+[hH]+", string)
    if match:
        return match.group()
    else:
        return "Failed to match!"
    

# Match against various names people use to refer to me
def match_my_name(string):
    match = re.search("(sjors|george|sjoerd)", string)
    if match:
        return match.group()
    else:
        return "Failed to match!"


# Match input to the e-mail address format
def match_email_address(string):
    match = re.findall(r"(\w+@\w+.\w+)", string)
    if match:
        return match
    else:
        return "Failed to match!"

    
# Main program logic
def program():
    print(match_lowercase("abraCadabra"))
    print(match_uppercase("HELLO_hello"))
    print(match_special(r". ^ $ * + ? { } [ ] \ | ( )"))
    print(match_xo("xoxoxo-x-o-x-o-x-o-xoxoxo"))
    print(match_cheer("yyYYyyeeEEEEAaaaAAAAAhhhhHHH"))
    print(match_my_name("george"))
    print(match_email_address("sjors@openmailbox.org bonanza sjors@musings.eu"))


# Run the program
program()
