let rec prod xs = 
    match xs with 
    | []    -> 1
    | x::xr -> x * prod xr

let rec proda xs a =
    match xs with
    | []    -> a
    | x::xr -> proda xr (x*a)

let rec prodc xs k =
  match xs with
    [] -> k 1
  | x::xr -> prodc xr (fun v -> k(v*x))

let xs = [3;4;5;23;3;453;4]
let x = prod xs = prodc xs id
let y = prod xs = proda xs 1

(* Evaluating prodc [1;2;3] id is as follows:

prodc [1;2;3] id
==> prodc [2;3] (fun v -> id(v*1))
==> prodc [3] (fun w -> (fun v -> id(v*1)) (w*2))
==> prodc [] (fun u -> (fun w -> (fun v -> id(v*1)) (w*2)) (u*3))
==> (fun u -> (fun w -> (fun v -> id(v*1)) (w*2)) (u*3)) 1
==> (fun w -> (fun v -> id(v*1)) (w*2)) (1*3)
==> (fun w -> (fun v -> id(v*1)) (w*2)) 3
==> (fun v -> id(v*1)) (3*2)
==> (fun v -> id(v*1)) 6
==> id(6*1)
==> id 6
==> 6

*)

(* To print "The answer is..." *)
let k = fun r -> printf "The result is %d\n" r
prodc xs k

let xsN = [-2;3;45]
let k = fun r -> if r < 0 then printf "WARNING - result %d is negative" r
                 r
prodc xs k
prodc xsN k
