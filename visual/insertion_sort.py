#!/usr/bin/python3

"""Visual insertion sort
Copyright 2016, Sjors van Gelderen
"""

from kivy.app import App
from kivy.uix.button import Button

class TestApp(App):
    def build(self):
        return Button(text = "Hello World")

TestApp().run()
