let rec merge a b =
    match a, b with
    | [], b -> b
    | a, [] -> a
    | x :: xs, y :: ys when x > y -> y :: merge a ys
    | x :: xs, y :: ys when x <= y -> x :: merge xs b

let test1 = (merge [ 3; 5; 12 ] [ 2; 3; 4; 7 ])

printfn "%A" test1

