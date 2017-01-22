"""Iterators / state machines / indexing / example
Copyright 2016, Sjors van Gelderen
"""

from enum import Enum

# Enumeration containing all types of accepted cards
class Card(Enum):
    Jack  = 0
    Queen = 1
    King  = 2
    Ace   = 3

# Indexed iterator containing cards
class Hand:    
    def __init__(self, _cards):
        self.cards = _cards

    def __iter__(self):
        self.i = 0
        return self

    def __next__(self):
        if self.i >= len(self.cards):
            raise StopIteration
        
        self.i += 1
        return self.cards[self.i - 1]

    def __getitem__(self, _key):
        return self.cards[_key]
            
# Main program logic
def program():
    # Create a hand holding the specified cards
    hand = Hand([ Card.Jack, Card.Queen, Card.King, Card.Ace ])

    print("Iterating example:")
    for card in hand:
        print(card)

    print("Indexing example:")
    for i in range(2):
        print(hand[i])

program()
