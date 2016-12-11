(*
Linear search algorithm example
Copyright 2016, Sjors van Gelderen
*)

module Program

(*
Linear search algorithm
Complexity: O(n)
*)
let linear_search collection target =
    printfn "Performing linear search on %A" collection
    printfn "Looking for %A" target
    
    let predicate = fun element -> element = target
    List.tryFindIndex predicate collection

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Linear search algorithm example - \
             Copyright 2016, Sjors van Gelderen"
    
    let collection = [ 2; 4; 5; 2; 5; 1; 5; 7; 9 ]
    match linear_search collection 5 with
    | Some index -> printfn "Found element at index %i" index
    | None       -> printfn "Element was not found in the collection"

    0
