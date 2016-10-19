"""Async example

Contains examples of:
- Generators
- Async operations

Copyright 2016, Sjors van Gelderen
"""

import asyncio
from time import sleep

async def coroutine():
    print("Hello world")

async def other_coroutine():
    sleep(3)
    print("Goodbye world")
    
loop = asyncio.get_event_loop()
loop.run_until_complete(coroutine())
loop.run_until_complete(other_coroutine())
loop.close()
