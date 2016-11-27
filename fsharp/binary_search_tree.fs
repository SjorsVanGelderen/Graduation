(*
	Elementary binary search tree implementation
	Copyright 2016, Sjors van Gelderen
*)

module Program

//Recursive data structure
type Leaf = Tree | None

type Tree =
     Parent      of Leaf
     Left_child  of Leaf
     Right_child of Leaf
     Key         of int

let rec insert (tree: Tree) (key: int) =
    if tree.Left_child

//Main program logic
let main args =
    printfn "Binary search tree example - Copyright 2016, Sjors van Gelderen"

    if args.length > 0:
       printfn "This program does not accept any arguments!"

    //Show example of binary tree usage here
    0