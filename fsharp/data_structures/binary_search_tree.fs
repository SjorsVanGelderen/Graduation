
let rec delete tree element =
    match tree with
    | Node (value, left, right) ->
        match left with
        | Node (left_value, _, _) ->
            match right with
            | Node (right_value, _, _) ->
                if left_value = element then
                    ()
                else
                    if right_value = element then
                        ()
                    else
                        ()
            | Empty ->
                if left_value = element then
                    
        | Empty -> ()
    | Empty -> ()
