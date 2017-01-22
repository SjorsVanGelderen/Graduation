(*
Queue data structure example
Copyright 2016, Sjors van Gelderen
*)

module Program

//Queue data structure
type Queue<'a> =
    { Size     : int
      Segments : 'a List } with
    static member Zero =
        { Size     = 0
          Segments = List.empty }

(*
Enqueue element in queue
Complexity: O(n)
*)
let enqueue element queue =
    if queue.Segments.Length < queue.Size then
        printfn "ENQUEUE %A" element
        { queue with Segments = element :: queue.Segments }
    else
        printfn "ENQUEUE: Queue overflow"
        queue
    
(*
Dequeue element from queue
Complexity: O(n)
*)
let dequeue queue =
    if queue.Segments.IsEmpty then
        printfn "DEQUEUE: Queue underflow"
        queue
    else
        let predicate = fun (count, acc) elem ->
            if count < queue.Segments.Length then
                (count + 1, elem :: acc)
            else
                (count + 1, acc)
        
        printfn "DEQUEUE: Success"
        let _, segments = List.fold predicate (1, List.empty) queue.Segments 
        { queue with Segments = segments }

(*
Peek the front element of the stack
Complexity: O(1)
*)
let front queue =
    if queue.Segments.IsEmpty then
        printfn "FRONT: Invalid operation"
    else
        printfn "FRONT: %A" queue.Segments.Head

(*
Peek the rear element of the stack
Complexity: O(n)
*)
let rear queue =
    if queue.Segments.IsEmpty then
        printfn "REAR: Invalid operation"
    else
        printfn "REAR: %A" <| queue.Segments.[queue.Segments.Length - 1]

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
    printfn "Queue data structure example - \
             Copyright 2016, Sjors van Gelderen"

    printfn "Queue with size 4"
    let populate = List.fold (fun acc elem -> enqueue elem acc)
    let queue = populate { Queue<int>.Zero with Size = 4 } [ 1; 2; 3; 4; 5 ]
    print queue
    
    let queue = dequeue queue
    front queue
    rear queue
    
    let queue = queue |> dequeue |> dequeue
    print queue

    let queue = queue |> enqueue 10 |> enqueue 20
    print queue
    
    0
