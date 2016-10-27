"""Classes example
Copyright 2016, Sjors van Gelderen
"""

from enum import Enum

# Enumeration for different book editions
class Edition(Enum):
    hardcover = 0
    paperback = 1

# Simple class for a book
class Book:
    def __init__(self, _title, _author, _edition):
        self.title = _title
        self.author = _author
        self.edition = _edition
        print("Created book {} by {} as {}".format(self.title, self.author, self.edition))

# Simple class for an E-reader
class E_Reader:    
    def __init__(self, _model, _brand, _books):
        self.model = _model
        self.brand = _brand
        self.books = _books
        print("Created E-reader {} by {} containing {}".format(self.model, self.brand, self.books))

# Main program logic
def program():
    kindle = E_Reader("Kindle", "Amazon", [Book("1984", "George Orwell", Edition.hardcover)])
    
    kobo = E_Reader("Aura", "Kobo", [
        Book("Dune", "Frank Herbert", Edition.hardcover),
        Book("Rama", "Arthur Clarke", Edition.paperback)
    ])

program()
