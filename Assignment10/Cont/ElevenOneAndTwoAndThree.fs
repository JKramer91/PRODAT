//11.1

// i

//Unoptimised version of the length function
let rec len xs =
    match xs with
    | [] -> 0
    | x :: xr -> 1 + len xr

// Optimised version of the length function
let rec lenCont xs c =
    match xs with
    | [] -> c 0
    | x :: xr -> lenCont xr (fun y -> c (1 + y))


printfn "%A" (lenCont [ 2; 5; 7 ] id)

printfn "%A" (lenCont [ 2; 5; 7 ] (printf "The answer is ’% d’ \n"))

// ii
printfn "%A" (lenCont [ 2; 5; 7 ] (fun v -> 2 * v))
// What happens is that we double the result of the length function, since the continuation gets applied as the last step in the function.

// iii
let rec leni xs acc =
    match xs with
    | [] -> acc
    | x :: xr -> leni xr (1 + acc)

printfn "%A" (leni [ 2; 5; 7 ] 0)

// leni uses an accumulator to store the result of the length function, which is then returned when the list is empty.
// This is a more efficient way of calculating the length of a list, since it avoids the overhead of using a continuation.
// lenCont builds up a continuation function that is applied at the end of the function, which is less efficient than using an accumulator.
// The relation between them is that they are both tail recursive as they apply the recursive call as the last step in the function.

// 11.2

// i

//Unoptimised rev
let rec rev xs =
    match xs with
    | [] -> []
    | x :: xr -> rev xr @ [ x ]

//Optimised rev with continuation
let rec revCont xs c =
    match xs with
    | [] -> c []
    | x :: xr -> revCont xr (fun y -> c (y @ [ x ]))

printfn "%A" (rev [ 2; 5; 7 ])
printfn "%A" (revCont [ 2; 5; 7 ] id)


// ii
printfn "%A" (revCont [ 2; 5; 7 ] (fun v -> v @ v))
// It basically duplicates the length within itself, since continuation gets applied as last step, it has build up the reversed list, and then it concatenates with "itself".

// iii
let rec revi xs acc =
    match xs with
    | [] -> acc
    | x :: xr -> revi xr (x :: acc)

printfn "%A" (revi [ 2; 5; 7 ] [])

// 11.3


//Unoptimised version of prod
let rec prod xs =
    match xs with
    | [] -> 1
    | x :: xr -> x * prod xr


//Optimised version of prod using continuation
let rec prodCont xs c =
    match xs with
    | [] -> c 1
    | x :: xr -> prodCont xr (fun y -> c (x * y))

printfn "%A" (prod [ 2; 5; 7 ])
printfn "%A" (prodCont [ 2; 5; 7 ] id)

let rec prodContOptimised xs c =
    match xs with
    | [] -> c 1
    | x :: xr ->
        if x = 0 then
            c 0
        else
            prodContOptimised xr (fun y -> c (x * y))

let rec prodContOptimised2 xs c =
    match xs with
    | [] -> c 1
    | x :: xr when x = 0 -> c 0
    | x :: xr -> prodContOptimised2 xr (fun y -> c (x * y))


printfn "%A" "Optimised for returning 0 when encountering 0"
printfn "%A" (prodContOptimised [ 0; 2; 5; 7 ] id)
printfn "%A" (prodContOptimised [ 0; 2; 5; 7 ] (printf "The answer is ’% d’ \n"))
printfn "%A" (prodContOptimised2 [ 0; 2; 5; 7 ] id)
printfn "%A" (prodContOptimised2 [ 0; 2; 5; 7 ] (printf "The answer is ’% d’ \n"))

let rec prodi xs acc = 
    match xs with 
    | [] -> 1 * acc 
    | x :: xr -> 