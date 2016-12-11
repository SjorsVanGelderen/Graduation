(*
Stack data structure example
Copyright 2016, Sjors van Gelderen
*)

module Program

//Stack data structure
type Stack<'a> =
    { Size     : int
      Segments : 'a List } with
    static member Zero =
        { Size = 0
          Segments = List.empty }

(*
Push an element onto the stack
Complexity: O(1)
*)
let push element stack =
    if stack.Segments.Length < stack.Size then
        printfn "PUSH: %A" element
        { stack with Segments = element :: stack.Segments }
    else
        printfn "PUSH: Stack overflow"
        stack

(*
Pop an element from the stack
Complexity: O(1)
*)
let pop stack =
    if stack.Segments.Length > 0 then
        printfn "POP: %A" stack.Segments.Head
        { stack with Segments = stack.Segments.Tail }
    else
        printfn "POP: Stack underflow"
        stack

(*
Peek the top element of the stack
Complexity: O(1)
*)
let peek stack =
    if stack.Segments.IsEmpty then
        printfn "PEEK: Stack underflow"
    else
        printfn "PEEK: %A" stack.Segments.Head

(*
Print all elements in the stack
Complexity: O(n)
*)
let print stack =
    printfn "REVEAL:"
    List.iter (fun elem -> printfn "%A" elem) stack.Segments

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Stack data structure example - \
             Copyright 2016, Sjors van Gelderen"

    printfn "Stack with size 4"
    let populate = List.fold (fun acc elem -> push elem acc)
    let stack = populate { Stack<int>.Zero with Size = 4 } [ 1; 2; 3; 4; 5 ]
    print stack
    
    let stack = pop stack
    peek stack
    
    let stack = stack |> pop |> pop
    peek stack
    print stack

    let stack = stack |> push 10 |> push 20
    print stack
    
    0
