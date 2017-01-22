/*
  Binary search tree data structure example
  Copyright 2017, Sjors van Gelderen
*/

#include <stdlib.h>
#include <stdio.h>

// Binary search tree data structure
typedef struct BST
{
    int key;
    struct BST* left;
    struct BST* right;
} BST;

// Function prototypes
void print_in_order_traversal(BST* _tree);
BST* bst_create();
void bst_insert(BST** _tree, int _key);
void bst_search(BST* _tree, int _key);
void terminate(BST** _tree);

// Prints in order traversal sequence of a tree
void print_in_order_traversal(BST* _tree)
{
    if(_tree != NULL)
    {
	print_in_order_traversal(_tree->left);
	printf("%d, ", _tree->key);
	print_in_order_traversal(_tree->right);
    }
}

// Allocates memory for the BST and returns a pointer to it
BST* bst_create(int _key)
{
    BST* tree = malloc(sizeof(BST));
    if(tree == NULL)
    {
	printf("Failed to allocate memory for the BST\n");
	return NULL;
    }
    
    tree->key = _key;
    tree->left = NULL;
    tree->right = NULL;
    return tree;
}

/*
  Inserts a node into the BST
  Complexity: O(n)
*/
void bst_insert(BST** _tree, int _key)
{
    if((*_tree) == NULL)
    {
	printf("Inserting node with key %d\n", _key);
	*_tree = bst_create(_key);
    }
    else
    {
	if(_key < (*_tree)->key)
	{
	    printf("Moving left from %d\n", (*_tree)->key);
	    bst_insert(&(*_tree)->left, _key);
	}
	else if(_key > (*_tree)->key)
	{
	    printf("Moving right from %d\n", (*_tree)->key);
	    bst_insert(&(*_tree)->right, _key);
	}
	else
	{
	    printf("Duplicate entry, ignoring insert!\n");
	}
    }
}

/*
  Find a node in the BST
  Complexity: O(n)
*/
void bst_search(BST* _tree, int _key)
{
    if(_tree == NULL)
    {
	printf("Couldn't find %d in the tree\n", _key);
    }
    else
    {
	if(_key < _tree->key)
	{
	    printf("Moving left from %d\n", _tree->key);
	    bst_search(_tree->left, _key);
	}
	else if(_key > _tree->key)
	{
	    printf("Moving right from %d\n", _tree->key);
	    bst_search(_tree->right, _key);
	}
	else
	{
	    printf("Found key %d in tree!\n", _key);
	}
    }
}

/*
  Frees and deallocates tree memory
  Complexity: O(n)
*/
void terminate(BST** _tree)
{
    if(*_tree != NULL)
    {
	BST* left = (*_tree)->left;
	BST* right = (*_tree)->right;
	free(*_tree);
	*_tree = NULL;
	terminate(&left);
	terminate(&right);
    }
}

// Main program logic
int main()
{
    printf("BST data structure example - ");
    printf("Copyright 2017, Sjors van Gelderen\n\n");
    
    // Empty tree
    BST* tree = NULL;

    // Insert nodes, pass pointer to pointer to tree
    bst_insert(&tree, 52);
    bst_insert(&tree, 3);
    bst_insert(&tree, 999);
    bst_insert(&tree, 33);

    // Print an in-order traversal
    printf("Traversal: ");
    print_in_order_traversal(tree);
    printf("\n");

    // Try to find these values in the tree
    bst_search(tree, 23);
    bst_search(tree, 55);
    bst_search(tree, 3);
    bst_search(tree, 999);

    // Free and deallocate memory
    terminate(&tree);
    
    return EXIT_SUCCESS;
}
