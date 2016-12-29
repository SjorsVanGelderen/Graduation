(*
Fibonacci algorithm example
Copyright 2016, Sjors van Gelderen
*)

(*
Recursive fibonacci algorithm
Very inefficient, no memoization
Complexity: O(2^n)
*)
let rec fibonacci n =
    if n < 2 then
        1
    else
        fibonacci (n - 1) + fibonacci (n - 2)

(*
Recursive fibonacci algorithm
Uses memoization for efficiency
Complexity: O(n)
This algorithm is currently WRONG!
*)
let rec fibonacci_memo n memo =
    if n < 2 then
        1, memo
    else
        match List.tryFind (fun (i, _) -> i = n) memo with
        | Some (_, result) -> result, memo
        | None ->
            let left, memo' = (fibonacci_memo (n - 1) memo)
            let right, memo'' = (fibonacci_memo (n - 2) memo')
            let result = left + right
            result, (left + right) :: memo''

(*
Iterative fibonacci algorithm
Better space complexity: O(1)
Complexity: O(n)
*)

let main args =
    printfn "Fibonacci algorithm example -
             Copyright 2016, Sjors van Gelderen"

    printfn "Inefficient Fibonacci algorithm:"
    List.iter (fun elem -> printfn "%A" <| fibonacci elem) [ 0; 1; 2; 3; 4; 5 ]
    printfn ""
    
    printfn "Efficient Fibonacci algorithm:"
    List.iter (fun elem -> printfn "%A" <| fibonacci_memo elem []) [0; 1; 2; 3; 4; 5 ]
    printfn ""
    
    0
