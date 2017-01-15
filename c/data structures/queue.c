/*
  Queue data structure example
  Circular (wrap-around) indexed implementation
  Copyright 2017 - Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

// Queue data structure
typedef struct Queue {
    int size;
    int front;
    int back;
    int* values;
} Queue;

// Function prototypes
void enqueue(Queue* _queue, int _value);
void dequeue(Queue* _queue);
void print_queue(Queue* _queue);

/*
  Put a new item in the queue
  Complexity: O(1)
*/
void enqueue(Queue* _queue, int _value)
{
    int current_queue = _queue->back;
    
    _queue->back++;
    if(_queue->back == _queue->size)
    {
	// Wrap around
	_queue->back = -1;
    }
    
    if(_queue->back == _queue->front)
    {
	// Revert operation
	printf("ENQUEUE: %d - Error, queue overflow!\n", _value);
	_queue->back = current_queue;
    }
    else
    {
	printf("ENQUEUE: %d\n", _value);
	_queue->values[_queue->back] = _value;
    }
}

/*
  Remove an item from the queue
  Complexity: O(1)
*/
void dequeue(Queue* _queue)
{
    if(_queue->front == _queue->back)
    {
        // Revert operation
	printf("DEQUEUE: Error, queue underflow!\n");
    }
    else
    {
	int current_front = _queue->front;
	_queue->front++;
	if(_queue->front == _queue->size)
	{
	    // Wrap around
	    _queue->front = -1;
	}

	printf("DEQUEUE: %d\n", _queue->values[_queue->front]);
    }
}

/*
  Print contents of the queue
  Complexity: O(n)
*/
void print_queue(Queue* _queue)
{
    /*
    printf("VALUES: ");
    for(int i = 0; i < _queue->size; i++)
    {
	printf("%d, ", _queue->values[i]);
    }
    printf("\n");
    */
    
    int front = _queue->front;
    printf("QUEUE: ");
    while(front != _queue->back)
    {
	front++;
	if(front == _queue->size)
	{
	    front = -1;
	}
	printf("%d, ", _queue->values[front]);
    }
    printf("\n");
}

int main()
{
    printf("Queue data structure example - ");
    printf("Copyright 2017, Sjors van Gelderen\n\n");
    
    const int SIZE = 3;
    
    // Set up a queue
    Queue queue;
    queue.size = SIZE;
    queue.front = -1;
    queue.back = -1;
    queue.values = calloc(SIZE, sizeof(int));
    
    // Do some operations on the queue
    enqueue(&queue, 10);
    print_queue(&queue);
    
    enqueue(&queue, 34);
    print_queue(&queue);
    
    enqueue(&queue, 66);
    print_queue(&queue);
    
    enqueue(&queue, 98);
    print_queue(&queue);
    
    dequeue(&queue);
    print_queue(&queue);
    
    dequeue(&queue);
    print_queue(&queue);
    
    dequeue(&queue);
    print_queue(&queue);
    
    dequeue(&queue);
    print_queue(&queue);
    
    // Free and deallocate memory
    free(queue.values);
    queue.values = NULL;
    
    return EXIT_SUCCESS;
}
