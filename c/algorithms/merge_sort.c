/*
  Merge sort algorithm
  Complexity: O(n log n)
  Copyright 2016, Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

void print_int_array(int _collection[], int _size)
{ 
  int i;
  for(i = 0; i < _size; i++)
  {
    if(i < _size - 1)
    {
      printf("%d, ", _collection[i]);
    }
    else
    {
      printf("%d", _collection[i]);
    }
  }
}

void merge(int _collection[], int _size, int _left, int _middle, int _right)
{
  int result[_size];
  int left_index = _left;
  int right_index = _middle + 1;
  int result_index = 0;

  //Sort initial elements
  while(left_index <= _middle && right_index <= _right)
  {
    if(_collection[left_index] <= _collection[right_index])
    {
      printf("%d <= %d\n",
	     _collection[left_index],
	     _collection[right_index]);

      result[result_index] = _collection[left_index];
      left_index++;
    }
    else
    {
      printf("%d >= %d\n",
	     _collection[left_index],
	     _collection[right_index]);

      result[result_index] = _collection[right_index];
      right_index++;
    }

    result_index++;
  }

  //Add remaining elements
  while(left_index <= _middle)
  {
    printf("Appending remaining element from left: %d\n",
	   _collection[left_index]);

    result[result_index] = _collection[left_index];
    left_index++;
    result_index++;
  }

  while(right_index <= _right)
  {
    printf("Appending remaining element from right: %d\n",
	   _collection[right_index]);

    result[result_index] = _collection[right_index];
    right_index++;
    result_index++;
  }

  printf("Intermediate result: ");
  print_int_array(result, _size);
  printf("\n");

  //Introduce results into the original collection
  for(int i = 0; i < _size; i++)
  {
    _collection[_left + i] = result[i];
  }
}

void merge_sort(int _collection[], int _size, int _left, int _right)
{
  int middle;
  
  if(_right > _left)
  {
    middle = (_left + _right) / 2;

    //Divide the current subproblem into two subproblems
    merge_sort(_collection, _size / 2, _left, middle);
    merge_sort(_collection, _size / 2, middle + 1, _right);

    merge(_collection, _size, _left, middle, _right);
  }
}

int main()
{
  printf("Merge sort example - Copyright 2016, Sjors van Gelderen\n\n");
  
  int collection_0[] = { 14, 2, 6, 23, 6, 753, 2 };
  int collection_1[] = { 0, 4, 2, 6, 3, 745, 7, 3 };
  int collection_2[] = { 6, 6, 6, 6, 6, 6, 3 };
  
  int size_0 = sizeof(collection_0) / sizeof(collection_0[0]);
  int size_1 = sizeof(collection_1) / sizeof(collection_1[0]);
  int size_2 = sizeof(collection_2) / sizeof(collection_2[0]);
  
  merge_sort(collection_0, size_0, 0, size_0 - 1);
  printf("Final result: ");
  print_int_array(collection_0, size_0);
  printf("\n\n");
  
  merge_sort(collection_1, size_1, 0, size_1 - 1);
  printf("Final result: ");
  print_int_array(collection_1, size_1);
  printf("\n\n");
  
  merge_sort(collection_2, size_2, 0, size_2 - 1);
  printf("Final result: ");
  print_int_array(collection_2, size_2);
  printf("\n\n");

  return EXIT_SUCCESS;
}
