(*
Binary tree data structure example
Copyright 2016, Sjors van Gelderen
*)

module Program

(*
Binary trees may be populated or not
Each node has a value and at most two children
*)
type BinaryTree<'a> =
    | Node of 'a * BinaryTree<'a> * BinaryTree<'a>
    | Empty

(*
Inserts an element
Complexity: O(n)
*)
let rec insert tree element =
    match tree with
    | Node (value, left, right) ->
        if right <> Empty then
            Node(value, insert left element, right)
        else
            Node(value, left, insert right element)
    | Empty -> Node(element, Empty, Empty)

(*
Finds an element
Complexity: O(n)
*)
let rec search tree element =
    match tree with
    | Node (value, left, right) ->
        if value = element then
            printfn "Found element %A!" element
        else
            search left element
            search right element
    | Empty -> ()

(*
Prints all elements
Complexity: O(n)
*)
let rec print tree =
    match tree with
    | Node (value, left, right) ->
        printfn "%A" value
        print left
        print right
    | Empty -> ()

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Binary tree data structure example - \
             Copyright 2016, Sjors van Gelderen"

    let tree = List.fold (fun acc elem -> insert acc elem) Empty [ 1; 2; 3; 4; 5; 6 ]
    print tree
    
    0
