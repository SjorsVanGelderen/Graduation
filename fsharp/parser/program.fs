(*
Parser combinator monad example
Copyright 2017, Sjors van Gelderen

Resources used:
https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/computation-expressions and
https://fsharpforfunandprofit.com/series/computation-expressions.html - Computation expressions
https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/ - Parser combinators
*)

module Program

(*
Tokens to be gathered by the parser
This could later be updated with functions, branches, variables and more
Thus, it could elegantly form the tokens for an abstract syntax tree
*)
type Token =
    | LETTER
    | DIGIT
    | SPACE

// Signature of a parser function
type Parser = Token List -> string -> Result

// Parser functions may return successes or failures
and Result =
    | Match   of Token List * string // Parsed token
    | NoMatch of Token List * string // No valid token found
    | Failure of Token List * string // Error in the pipeline or input

(*
Bind operation for parser combinator monad
p and k are the left and right operations bound by this function
The bind operation threads parsed tokens and the stream through
the parser operations specified in the monadic pipeline
*)
let bind (p : Parser) (k : Result -> Parser) =
    fun (tokens : Token List) (stream : string) ->
        // The match expression executes the current step of the pipeline
        let result = p tokens stream
        match result with
        | Match (tokens, stream) -> Match (tokens, stream)
        | NoMatch (tokens, stream) -> k result tokens stream
        | Failure (tokens, msg) ->
            // Unexpected end of the pipeline
            Failure (tokens, msg)

// Infix bind operator for parser combinator monad
let (>>=) = bind

// Return operation for parser combinator monad
let return_op (result : Result) : Parser =
    fun (tokens : Token List) (stream : string) -> result

// Computation expression builder for parser systems
type ParserCombinatorMonad() =
    member this.Bind (p, k) = p >>= k
    member this.Return x = return_op x
let pipeline = ParserCombinatorMonad()

// Parse a string for a single character
let parse_letter : Parser =
    fun (tokens : Token List) (stream : string) ->
        printfn "Looking for a letter in: %s" stream
        if List.exists (fun elem -> elem = stream.[0]) (['A'..'Z'] @ ['a'..'z']) then
            // Add the token
            Match (LETTER :: tokens, stream.[1..])
        else
            NoMatch (tokens, stream)

// Parse a string for hardcoded character 'A'
let parse_digit : Parser =
    fun (tokens : Token List) (stream : string) ->
        printfn "Looking for a digit in:  %s" stream
        if List.exists (fun elem -> elem = stream.[0]) ['0'..'9'] then
            // Add the token
            Match (DIGIT :: tokens, stream.[1..])
        else
            NoMatch (tokens, stream)

// Parse a string for a whitespace character
let parse_whitespace : Parser =
    fun (tokens : Token List) (stream : string) ->
        printfn "Looking for a space in:  %s" stream
        if stream.[0] = ' ' then
            // Add the token
            Match (SPACE :: tokens, stream.[1..])
        else
            NoMatch (tokens, stream)

// If there hasn't been any match, this will trigger a failure in the pipline
let parse_no_match : Parser =
    fun (tokens : Token List) (stream : string) ->
        Failure (tokens, "No matching token found!")

// Runs the actual computation expression until parsing is complete
let rec run parser_pipeline tokens stream =
    match parser_pipeline tokens stream with
    | Match (tokens, stream) ->
        if stream = "" then
            printfn "Success! Tokens gathered from stream: %A" (List.rev tokens)
            0 // No errors
        else
            run parser_pipeline tokens stream
    | NoMatch (tokens, stream) ->
        printfn "Error: NoMatch as final result! - Tokens gathered: %A" (List.rev tokens)
        1 // Error
    | Failure (tokens, msg) ->
        printfn "Error: %s - Tokens gathered: %A" msg (List.rev tokens)
        1 // Error

// Main program logic
[<EntryPoint>]
let main args =
    printfn "Parser combinator monad example - \
             Copyright 2016, Sjors van Gelderen"
    
    // Define the parser pipeline with the computation expression syntax
    let parser_pipeline =
        pipeline {
            let! result = parse_letter
            let! result = parse_digit
            let! result = parse_whitespace
            let! result = parse_no_match
            return result
        }
    
    // Run the parser pipeline
    run parser_pipeline List.empty "George Orwell wrote 1984 in 1948"
