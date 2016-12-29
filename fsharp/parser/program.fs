(*
Parser combinator monad example
https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
Copyright 2016, Sjors van Gelderen
*)

module Program

type Result<'a> =
    | Success of 'a
    | Failure of string

// Parse a string for a single character
let parse_character character stream =
    printfn "Looking for '%c' in %A" character stream
    if String.IsNullOrEmpty(character) then
        Failure "End of stream"
    else
        let first = str.[0]
        if first = character then
            let remaining = str.[1..]
            let message = sprintf "Found '%c'" character
            Success (message, remaining)
        else
            let message = sprintf "Expecting '%c'. Got '%c'" character first
            Failure message

// Parse a string for hardcoded character 'A'
let parse_a stream =
    printfn "Looking for 'A' in %A" stream
    if String.IsNullOrEmpty(stream) then
        (false, "")
    else if stream.[0] = "A" then
        let remaining = stream.[1..]
        (true, remaining)
    else
        (false, stream)

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Parser combinator monad example - \
             Copyright 2016, Sjors van Gelderen"
    
    let stream = "ABC"
    let result, stream' = parse_a inputABC
    printfn "%A, %A" result stream'

    let stream = "ZBC"
    let result, stream' = parse_a inputZBC
    printfn "%A, %A" result stream'

    let stream = "ABC"
    let message, stream' = parse_char ("A", stream)
    printfn "%A, %A" message stream'

    let stream = "ZBC"
    let message, stream' = parse_char ("A", stream)
    printfn "%A, %A" message stream'

    let stream = "ZBC"
    let message, stream' = parse_char ("Z", stream)
    printfn "%A, %A" message stream'
    
    0
