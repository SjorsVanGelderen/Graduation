(*
Binary search tree example
Copyright 2017, Sjors van Gelderen
*)

// Binary search tree type containing a generic type for values
type BST<'a> =
    { Value : 'a
      Left  : BST<'a> Option
      Right : BST<'a> Option }

(*
In-order traversal
Complexity: O(n)
*)
let rec in_order_traversal tree =
    match tree with
    | Some tree ->
        (in_order_traversal tree.Left) @ (tree.Value :: (in_order_traversal tree.Right))
    | None ->
        []

(*
Insertion operation
Complexity: O(n)
*)
let rec insert value tree =
    match tree with
    | Some tree ->
        if value < tree.Value then
            // Recursion on the left subtree
            Some { tree with Left = insert value tree.Left }
        else
            // Recursion on the right subtree
            Some { tree with Right = insert value tree.Right }
    | None ->
        // Return a tree
        Some { Value = value
               Left  = None
               Right = None }

(*
Delete operation
Complexity: O(MISSING)
*)
let rec delete value tree : BST<'a> Option =
    match tree with
    | Some tree ->
        if tree.Value = value then
            if tree.Left = None && tree.Right = None then
                None
            elif tree.Left <> None && tree.Right <> None then
                // Locate successor
                let predicate = (fun elem -> elem = tree.Value)
                let traversal = in_order_traversal tree // Some weird bug error here?
                None
                (*
                match List.tryFind predicate traversal with
                | Some successor ->
                    // Recursion on the rest of the subtree
                    Some { tree with Value = successor
                                     Right = delete successor tree.Right }
                    ()
                | None ->
                    printfn "Failed to locate successor of %A" tree.Value
                    None
                    ()*)
                //None
            elif tree.Left <> None then
                // Replace tree with left subtree
                tree.Left
            elif tree.Right <> None then
                // Replace tree with right subtree
                tree.Right
            else
                // Delete this tree
                None
        else
            if value < tree.Value then
                // Recursion on the left subtree
                Some { tree with Left = delete value tree.Left }
            else
                // Recursion on the right subtree
                Some { tree with Right = delete value tree.Right }
    | None ->
        // Value not found
        printfn "Value %A not found in tree..." tree.Value
        None

(*
Search operation
Complexity: O(n)
*)
let rec search value tree =
    match tree with
    | Some tree ->
        if tree.Value = value then
            // Value found
            printfn "Found %A in tree!" value
            true
        else
            if tree.Value < value then
                // Recursion on the left subtree
                search value tree.Left
            else
                // Recursion on the right subtree
                search value tree.Right
    | None ->
        // Value not found
        printfn "Value %A not found in tree..." tree.Value
        false

// Main program logic
[<EntryPoint>]
let main args =
    let tree = Some { Value = 10
                      Left  = None
                      Right = None }

    let tree =
        tree
        |> insert 5
        |> insert 16
        |> insert 2
        |> insert 7

    List.iter (fun elem -> printfn "%A" elem) <| in_order_traversal tree
    0
