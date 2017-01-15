/*
  Stack data structure example
  Copyright 2017, Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

// Stack data structure
typedef struct Stack {
    int size;
    int capacity;
    int* values;
} Stack;

// Function prototypes
void push(Stack* _stack, int _value);
void pop(Stack* _stack);
int peek(Stack* _stack);

/*
  Push an element onto the stack
  Complexity: O(1)
*/
void push(Stack* _stack, int _value)
{
    if(_stack->capacity > 0)
    {
	printf("PUSH: %d\n", _value);
	_stack->values[_stack->capacity - 1] = _value;
	_stack->capacity--;
    }
    else
    {
	// Stack capacity reached
	printf("PUSH: %d - Error: stack overflow!\n", _value);
    }
}

/*
  Pop an element from the stack
  Complexity: O(1)
*/
void pop(Stack* _stack)
{
    if(_stack->capacity < _stack->size)
    {
	printf("POP\n");
	_stack->capacity++;
    }
    else
    {
	// No elements on stack to pop
	printf("Error: stack underflow!\n");
    }
}

/*
  Peek the top element of the stack
  Complexity: O(1)
*/
int peek(Stack* _stack)
{
    if(_stack->capacity == _stack->size)
    {
	// No elements on stack to peek
	printf("Error: invalid operation!\n");
	return -1;
    }
    else
    {
	int value = _stack->values[(_stack->size - 1) - _stack->capacity];
	printf("PEEK: %d\n", value);
	return value;
    }
}

int main()
{
    printf("Stack data structure example - ");
    printf("Copyright 2017, Sjors van Gelderen\n\n");
    
    const int SIZE = 4;

    // Create a stack
    Stack stack;
    stack.size = SIZE;
    stack.capacity = SIZE;
    stack.values = malloc(sizeof(int) * SIZE);

    // Do some operations on it
    push(&stack, 1);
    push(&stack, 2);
    push(&stack, 3);
    push(&stack, 4);
    push(&stack, 5);

    peek(&stack);

    pop(&stack);
    pop(&stack);
    
    peek(&stack);

    pop(&stack);
    pop(&stack);
    pop(&stack);

    peek(&stack);

    // Free and deallocate memory
    free(stack.values);
    stack.values = NULL;
    
    return EXIT_SUCCESS;
}
