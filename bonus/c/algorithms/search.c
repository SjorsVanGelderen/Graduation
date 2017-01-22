/*
  Searching algorithms
  Copyright 2016, Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

/*
  Function prototypes
*/
int print_array(int _n, int _array[_n]);
int linear_search(int _n, int _array[_n], int _target);
int binary_search();

/*
  Prints an array
*/
int print_array(int _n, int _array[_n])
{
    int i;

    if(_n <= 0)
    {
	printf("Array is of invalid length!\n");
	return EXIT_FAILURE;
    }
    
    printf("[");
    
    for(i = 0; i < _n; i++)
    {
	if(i < _n -1)
	{
	    printf("%d, ", _array[i]);
	}
	else
	{
	    printf("%d", _array[i]);
	}
    }

    printf("]");
    return EXIT_SUCCESS;
}

/*
  Linear search algorithm
  Complexity: O(n)
*/
int linear_search(int _n, int _array[_n], int _target)
{
    int i;

    if(_n <= 0)
    {
	printf("Array is of invalid length!\n");
	return EXIT_FAILURE;
    }
    
    printf("Linear search example on ");
    print_array(_n, _array);
    printf("\n");

    for(i = 0; i < _n; i++)
    {
	if(_array[i] == _target)
	{
	    printf("Found target at index %d!\n", i);
	    return EXIT_SUCCESS;
	}
    }
    
    printf("Array doesn't contain target!\n");
    return EXIT_FAILURE;
}

/*
  Binary search algorithm
  Complexity: O(n log n)
*/
int binary_search()
{
    return EXIT_SUCCESS;
}

/*
  Main program logic
*/
int main()
{
    int array[5] = {1, 3, 2, 7, 6};
    linear_search(5, array, 7);
    binary_search();
    return EXIT_SUCCESS;
}
