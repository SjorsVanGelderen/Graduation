(*
Merge sort algorithm example
Copyright 2016, Sjors van Gelderen
*)

module Program

(*
Merge sort algorithm
Complexity: O(n log n)
*)
let merge_sort (collection : List<int>) =
    let half  = int(ceil <| (float collection.Length) / 2.0f)
    let left  = collection |> Seq.take (half) |> Seq.toList
    let right = collection |> Seq.skip (half) |> Seq.toList
    printfn "left: %A" left
    printfn "right: %A" right

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Merge sort algorithm example - \
             Copyright 2016, Sjors van Gelderen"

    let collection = [ 2; 5; 3; 1; 64; 75; 13 ]
    merge_sort collection
    
    0
