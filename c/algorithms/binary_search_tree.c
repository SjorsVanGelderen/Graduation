/*
  Binary search tree example
  Copyright 2016, Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

// Binary search tree data structure
typedef struct BST
{
    struct BST* parent;
    struct BST* left;
    struct BST* right;
    int key;
} BST;


// Function prototypes
int print_array(int _n, int _array[_n]);
BST* bst_create();
void bst_insert(BST* _tree, int _key);
void bst_find(BST* _tree, int _key);

// Prints an array
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

    printf("]\n");
    return EXIT_SUCCESS;
}

// Creates a BST and returns a pointer to it
BST* bst_create(BST* _parent, int _key)
{
    BST* tree = malloc(sizeof(BST));
    if(tree == NULL)
    {
	printf("Error, malloc for BST failed!\n");
	return NULL;
    }
  
    tree->parent = _parent;
    tree->key = _key;
    return tree;
}

/*
  Inserts a node into the BST
  Complexity: O(h) where h = height of BST
*/
void bst_insert(BST* _tree, int _key)
{
    if(_tree->parent == NULL)
    {
	printf("Starting insertion of %d\n", _key);
    }
    
    if(_key < _tree->key)
    {
	if(_tree->left == NULL)
	{
	    printf("Inserting node with key %d left of %d\n", _key, _tree->key);
	    _tree->left = bst_create(_tree, _key);
	}
	else
	{
	    printf("Moving left from %d\n", _tree->key);
	    bst_insert(_tree->left, _key);
	}
    }
    else if(_key > _tree->key)
    {
	if(_tree->right == NULL)
	{
	    printf("Inserting node with key %d right of %d\n", _key, _tree->key);
	    _tree->right = bst_create(_tree, _key);
	}
	else
	{
	    printf("Moving right from %d\n", _tree->key);
	    bst_insert(_tree->right, _key);
	}
    }
    else
    {
	printf("Duplicate entry, ignoring insert!\n");
	return;
    }
}

/*
  Find a node in the BST
  Complexity: O(h) where h = height of BST
*/
void bst_find(BST* _tree, int _key)
{
    if(_tree->parent == NULL)
    {
	printf("Looking for %d\n", _key);
    }

    if(_key < _tree->key)
    {
	if(_tree->left == NULL)
	{
	    printf("Could not find key!\n");
	}
	else
	{
	    printf("Moving left from %d\n", _tree->key);
	    bst_find(_tree->left, _key);
	}
    }
    else if(_key > _tree->key)
    {
	if(_tree->right == NULL)
	{
	    printf("Could not find key!\n");
	}
	else
	{
	    printf("Moving right from %d\n", _tree->key);
	    bst_find(_tree->right, _key);
	}
    }
    else
    {
	printf("Found key!\n");
    }
}

// Main program logic
int main()
{
    int array[5] = {1, 3, 2, 7, 6};

    BST tree;
    bst_insert(&tree, 49);
    bst_insert(&tree, 52);
    bst_insert(&tree, 3);
    bst_insert(&tree, 999);
    bst_insert(&tree, 33);

    bst_find(&tree, 23);
    bst_find(&tree, 55);
    bst_find(&tree, 3);
    bst_find(&tree, 999);
    
    return EXIT_SUCCESS;
}
