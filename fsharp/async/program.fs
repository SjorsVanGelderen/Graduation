(*
Async monad example
Copyright 2017, Sjors van Gelderen

Resources used:
https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/asynchronous-workflows - async workflow
*)

module Program

// Recursive Fibonacci sequence function
let rec fibonacci n =
    if n < 2 then
        n
    else
        (fibonacci (n - 1)) + (fibonacci (n - 2))

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Async monad example - \
             Copyright 2017, Sjors van Gelderen"

    // Asynchronous timestamping job
    let rec async_timestamps count =
        async {
            do! Async.Sleep 1000
            do printfn "%A" System.DateTime.Now
            if count > 1 then
                do! async_timestamps (count - 1)
        }

    // Asynchronous Fibonacci number calculation job
    let async_fibonacci n =
        async {
            let result = fibonacci n
            do printfn "Fibonacci of %i is %i" n result
        }
    
    // Jobs to schedule
    let jobs = [
        async_timestamps 15
        async_fibonacci 10
        async_fibonacci 42
        async_fibonacci 45
    ]
    
    jobs
    |> Async.Parallel         // Queue jobs supplied to run in in parallel
    |> Async.RunSynchronously // Run and block until async operations are complete
    |> ignore
    
    0
