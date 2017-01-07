"""Async examples
Copyright 2017, Sjors van Gelderen

Resources used:
https://docs.python.org/3/library/asyncio.html - asyncio
https://makina-corpus.com/blog/metier/2015/python-http-server-with-the-new-async-await-syntax - aiohttp
http://aiohttp.readthedocs.io/en/stable/web.html#aiohttp-web-graceful-shutdown - aiohttp
"""

import asyncio
import aiohttp.web
import json


# Handles requests asynchronously
async def handle(request):
    # Set up sources on which to perform a GET request
    sources = [
        "http://www.google.com/",
        "http://www.ubuntu.com/",
        "http://www.gnu.org/",
    ]
    
    # Generate coroutines that will perform the GET requests asynchronously
    tasks = [ aiohttp.request("GET", source) for source in sources ]
    
    # Block until asynchronous routines are finished
    responses = await asyncio.gather(*tasks, return_exceptions=True)

    # Close connections
    for connection in responses:
        if not isinstance(connection, Exception):
            connection.close()
    
    # Zip sources with their responses
    data = {
        source: not isinstance(response, Exception) and         \
                response.status == 200                          \
                for source, response in zip(sources, responses)
    }
    
    # Build a JSON body
    body = json.dumps(data).encode("utf-8")
    
    # Return a response to the client
    return aiohttp.web.Response(body=body, content_type="application/json")
    
    
# Main program logic
def program():
    # Get the main event loop
    loop = asyncio.get_event_loop()
    
    # Set up application with the event loop
    application = aiohttp.web.Application(loop=loop)
    application.router.add_get("/", handle)

    # Start server
    aiohttp.web.run_app(application, host="127.0.0.1", port=8800)
    

# Run the program
program()
