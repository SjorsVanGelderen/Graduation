/*
  Linked list data structure example
  Copyright 2017, Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

// Singly-linked list data structure
typedef struct List {
    int value;
    struct List* next;
} List;

// Function prototypes
void insert(List** _list, int _value);
void delete(List** _list, int _value);
void search(List* _list, int _value);
void terminate(List** _list);

/*
  Insert operation
  Complexity: O(n)
*/
void insert(List** _list, int _value)
{
    if(*_list == NULL)
    {
	printf("INSERT: %d - Storing value now\n", _value);
	*_list = malloc(sizeof(List));
	(*_list)->value = _value;
	(*_list)->next = NULL;
    }
    else
    {
	printf("INSERT: %d - Moving to next\n", _value);
	insert(&(*_list)->next, _value);
    }
}

/*
  Delete operation
  Complexity: O(n)
*/
void delete(List** _list, int _value)
{
    if(*_list == NULL)
    {
	printf("DELETE: %d - Error, value not found in list!\n", _value);
    }
    else if((*_list)->value == _value)
    {
	printf("DELETE: %d - Deleting found value from list\n", _value);
	List* next = (*_list)->next;
	free(*_list);
	*_list = next;
    }
    else
    {
	printf("DELETE: %d - Moving to next\n", _value);
	delete(&(*_list)->next, _value);
    }
}

/*
  Search operation
  Complexity: O(n)
*/
void search(List* _list, int _value)
{
    if(_list == NULL)
    {
	printf("SEARCH: %d - Value not found in list!\n", _value);
    }
    else if(_list->value == _value)
    {
	printf("SEARCH: %d - Value found in list!\n", _value);
    }
    else
    {
	printf("SEARCH: %d - Moving to next\n", _value);
	search(_list->next, _value);
    }
}

/*
  Frees and deallocates list memory
  Complexity: O(n)
*/
void terminate(List** _list)
{
    if(*_list != NULL)
    {
	List* next = (*_list)->next;
	free(*_list);
	*_list = NULL;
	terminate(&next);
    }
}

int main()
{
    printf("Linked list data structure example - ");
    printf("Copyright 2017, Sjors van Gelderen\n\n");
    
    // Empty linked list
    List* list = NULL;
    
    // Several operations on the linked list
    insert(&list, 1);
    insert(&list, 2);
    insert(&list, 3);
    insert(&list, 4);
    insert(&list, 5);
    
    delete(&list, 3);
    delete(&list, 5);

    search(list, 1);
    search(list, 4);

    // Free and deallocate memory
    terminate(&list);
    
    return EXIT_SUCCESS;
}
