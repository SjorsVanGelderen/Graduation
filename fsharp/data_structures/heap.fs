(*
Heap data structure example
Copyright 2017, Sjors van Gelderen

Resources used:
https://en.wikipedia.org/wiki/Heap_(data_structure) - Heap data structure
*)

module Program

// Type to specify the heap property
type Property =
    | Min
    | Max

// Type for the heap data structure
type Heap<'a> =
    { Property : Property
      Values   : 'a List }

(*
Returns whether the element at the left index is
smaller than the element at the right index
*)
let less (left : int) (right : int) (heap : Heap<'a>) : bool =
    if left  < heap.Values.Length &&
       right < heap.Values.Length then
        let left_value  = heap.Values.[left]
        let right_value = heap.Values.[right]
        let result = left_value < right_value
        if result then
            printfn "%A < %A" left_value right_value
        else
            printfn "%A > %A" left_value right_value
        result
    else
        printfn "Error, list indices out of range!"
        false

(*
Swap operation
Complexity: O(n)
Returns a list with left and right index elements swapped
*)
let swap (left : int) (right : int) (heap : Heap<'a>) : Heap<'a> =
    let swap_operation =
        fun (list, index) elem -> elem
        (*
            if index = left then
                (right :: list, index + 1)
            elif index = right then
                (left :: list, index + 1)
            else
                (elem :: list, index + 1)
                *)
    
    if left  < heap.Values.Length &&
       right < heap.Values.Length then
        let left_value  = heap.Values.[left]
        let right_value = heap.Values.[right]
        printfn "%A <-> %A" left_value right_value
        heap
        (*
        { heap with
            Values = List.foldBack swap_operation heap.Values ([], 0) }*)
    else
        printfn "Error, list indices out of range!"
        heap

(*
Swim operation
Complexity: O(log n)
Moves a key up the heap
*)
(*
let rec swim index heap =
    if index > 0 && index < heap.Values.Length then
        printfn "Swimming from index %A" index
        let operation =
            match heap.Property with
            | Min -> less
            | Max -> more
        
        if operation index (index / 2) heap then
            let heap = swap index (index / 2) heap
            swim (index / 2) heap
            *)

(*
Insert operation
Complexity: O(1)
*)
let insert (value : 'a) (heap : Heap<'a>) : Heap<'a> =
    printfn "Inserting %A" value
    let heap = { heap with Values = value :: heap.Values }
    // swim (heap.Values.Length - 1)
    heap

[<EntryPoint>]
let main args =
    printfn "Heap data structure example - Copyright 2017, Sjors van Gelderen"

    let heap =
        { Property = Min
          Values   = [] }

    let heap =
        heap
        |> insert 10
        |> insert 16
        |> insert 5

    printfn "Heap values: %A" heap.Values
    
    0
