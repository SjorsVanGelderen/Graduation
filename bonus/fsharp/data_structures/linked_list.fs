(*
Linked list data structure example
Copyright 2016, Sjors van Gelderen
*)

module Program

// Linked list data structure
type LinkedList<'a> =
    | Node of 'a * LinkedList<'a>
    | Empty

(*
Insert an element into the list
Complexity: O(1)
*)
let rec insert element list =
    printfn "Inserting element %A" element
    Node (element, list)
        
(*
Delete an element from the list
Complexity: O(n)
*)
let rec delete element list =
    match list with
    | Node (value, tail) ->
        if value = element then
            printfn "Deleting element %A" element
            tail
        else
            Node (value, delete element tail)
    | Empty ->
        printfn "Element %A not in collection" element
        list

(*
Find an element in the list
Complexity: O(n)
*)
let rec search element list =
    match list with
    | Node (value, tail) ->
        if value = element then
            printfn "Found element %A" element
        else
            search element tail
    | Empty ->
        printfn "Element %A not in list" element

(*
Print all values in the list
Complexity: O(n)
*)
let rec print list =
    match list with
    | Node (value, tail) ->
        printfn "%A" value
        print tail
    | Empty ->
        ()

[<EntryPoint>]
let main args =
    printfn "Linked list data structure example - \
             Copyright 2016, Sjors van Gelderen"
    
    let list = Node(10, Node(12, Node(16, Empty)))
    print list
    
    let list = Empty |> insert 10 |> insert 12 |> insert 50
    print list

    let list = list |> delete 50 |> delete 24 |> delete 5
    print list

    List.iter (fun elem -> search elem list) [ 10; 2; 56; 12 ]
    
    0
