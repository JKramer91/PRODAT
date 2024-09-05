(* Code from Niels *)
let env = [ ("a", 3); ("c", 78); ("baf", 666); ("b", 111) ]

let emptyenv = [] (* the empty environment *)

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let cvalue = lookup env "c"



// Exercise 1.1  (Our code)

//(i)
type expr =
    | CstI of int
    | Var of string
    | Prim of string * expr * expr
    | If of expr * expr * expr

let max x y = if x > y then x else y
let min x y = if x < y then x else y

let (==) x y = if x = y then 1 else 0

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2) -> (==) (eval e1 env) (eval e2 env)
    | If(e1, e2, e3) -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env)
    | Prim _ -> failwith "unknown primitive"


let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

//Happy path
let e4 = Prim("max", CstI 5, CstI 3)
let e5 = Prim("min", CstI 3, CstI 5)
let e6 = Prim("==", CstI 5, CstI 5)

//Unhappy path
let e7 = Prim("==", CstI 2, CstI 5)

let e8 = If(Var "a", CstI 11, CstI 22)

// (ii)
let e1v = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [ ("a", 314) ]
let e3v = eval e3 env
printfn "Tests for (ii)"
printfn "Expect 5 as result. (5>3): %A" (eval e4 env)
printfn "Expect 3 as result. (3<5):%A" (eval e5 env)
printfn "Expect 1 as result. (5 = 5):%A" (eval e6 env)
printfn "Expect 0 as result. (2 != 5 ): %A" (eval e7 env)

// (iii)
let rec eval2 e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim(ope, e1, e2) ->
        let i1 = eval e1 env
        let i2 = eval e2 env

        match ope with
        | "+" -> i1 + i2
        | "*" -> i1 * i2
        | "-" -> i1 - i2
        | "max" -> max i1 i2
        | "min" -> min i1 i2
        | "==" -> (==) i1 i2
        | _ -> failwith "unknown primitive"
    | If(e1, e2, e3) ->
        let i1 = (eval e1 env)
        let i2 = (eval e2 env)
        let i3 = (eval e3 env)
        if i1 <> 0 then i2 else i3

printfn "Tests for (iii)"
printfn "Expect 5 as result. (5>3): %A" (eval2 e4 env)
printfn "Expect 3 as result. (3<5):%A" (eval2 e5 env)
printfn "Expect 1 as result. (5 = 5):%A" (eval2 e6 env)
printfn "Expect 0 as result. (2 != 5 ): %A" (eval2 e7 env)

printfn "Tests for (iiii)"
printfn "Expect 11 as result. : %A" (eval e8 env)

//Exercise 1.2

//(i)
type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr 

//(ii)
let e9 = Sub(Var "V", Add(Var "w", Var "z"))

let e10 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))

let e11 = Add(Add(Var "x", Var "y"), (Add(Var "z", Var "v")))

let e12 = Sub(Var "x", CstI 34)

// (iii)
let rec fmt (e: aexpr) =
    match e with
    | CstI i -> string (i)
    | Var x -> x
    | Add(e1, e2) -> "(" + (fmt e1) + " + " + (fmt e2) + ")"
    | Mul(e1, e2) -> "(" + (fmt e1) + " * " + (fmt e2) + ")"
    | Sub(e1, e2) -> "(" + (fmt e1) + " - " + (fmt e2) + ")"


printfn "%A" (fmt e12)

// (iv)

let e13 = Add(Var "x", CstI 0)
let e14 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0))

let rec simplify (e: aexpr) =
    match e with
    | CstI _ -> e
    | Var _ -> e
    | Add(e1, CstI 0) -> simplify e1
    | Add(CstI 0, e1) -> simplify e1
    | Sub(e1, CstI 0) -> simplify e1
    | Mul(e1, CstI 1) -> simplify e1
    | Mul(CstI 1, e1) -> simplify e1
    | Mul(CstI 0, e1) -> simplify (CstI 0)
    | Mul(e1, CstI 0) -> simplify (CstI 0)
    | Sub(e1, e2) when e2 = e1 -> simplify (CstI 0)
    | Add(e1, e2) -> Add(simplify e1, simplify e2)
    | Sub(e1, e2) -> Sub(simplify e1, simplify e2)
    | Mul(e1, e2) -> Mul(simplify e1, simplify e2)


printfn "Test e13 %A" (simplify e13)
printfn "Test e14 %A" (fmt (simplify e14))

// (v)
let rec diff (e: aexpr) (x: string) =
    match e with
    | CstI _ -> CstI 0
    | Var v -> if v = x then CstI 1 else CstI 0
    | Add(e1, e2) -> Add(diff e1 x, diff e2 x)
    | Sub(e1, e2) -> Sub(diff e1 x, diff e2 x)
    | Mul(e1, e2) -> Add(Mul(diff e1 x, e2), Mul(e1, diff e2 x))

let e15 = Add(Mul(CstI 3, Var "x"), CstI 5)
let e16 = Add(Mul(CstI 5, Var "x"), Add(Mul(CstI 3, Var "y"), CstI 7))

printfn "Test e15. Expected result is 3. : %A" (fmt (simplify (diff e15 "x")))
printfn "Test e16. Expected result is 5. : %A" (fmt (simplify (diff e16 "x")))

// Exercise 2.1
type expr2 =
    | CstI of int
    | Var of string
    | Let of (string * expr2) list * expr2
    | Prim of string * expr2 * expr2

let rec eval3 e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Let(lst, ebody) ->
        let env1 =
            List.fold
                (fun acc (x, erhs) ->
                    let xval = eval3 erhs acc
                    (x, xval) :: acc)
                env
                lst

        eval3 ebody env1
    | Prim("+", e1, e2) -> eval3 e1 env + eval3 e2 env
    | Prim("*", e1, e2) -> eval3 e1 env * eval3 e2 env
    | Prim("-", e1, e2) -> eval3 e1 env - eval3 e2 env
    | Prim _ -> failwith "unknown primitive"

// Exercise 2.2


let mem x vs = List.exists (fun y -> x = y) vs

let rec union (xs, ys) =
    match xs with
    | [] -> ys
    | x :: xr -> if mem x ys then union (xr, ys) else x :: union (xr, ys)

(* minus xs ys  is the set of all elements in xs but not in ys *)

let rec minus (xs, ys) =
    match xs with
    | [] -> []
    | x :: xr -> if mem x ys then minus (xr, ys) else x :: minus (xr, ys)

(* Find all variables that occur free in expression e *)

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x -> [ x ]
    | Let(x, ebody) ->
        let vars = List.map fst x
        let bindings = List.collect (fun (_, s) -> freevars s) x
        union (bindings, minus (freevars ebody, vars))
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)

let e17: expr2 =
    Let([ ("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2)) ], Prim("+", Var "x1", Var "x2"))

let e18 = Let([ "z", CstI 17 ], Prim("+", Var "z", Var "z"))
printfn "Test e17. Expected result is empty []. : %A" (freevars e17)
printfn "Test e17. Expected result is empty []. : %A" (freevars e18)

// Exercise 2.3

type texpr = (* target expressions *)
    | TCstI of int
    | TVar of int (* index into runtime environment *)
    | TLet of texpr * texpr (* erhs and ebody                 *)
    | TPrim of string * texpr * texpr

let rec getindex vs x =
    match vs with
    | [] -> failwith "Variable not found"
    | y :: yr -> if x = y then 0 else 1 + getindex yr x

let rec tcomp (e: expr2) (cenv: string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x -> TVar(getindex cenv x)
    | Let(lst, ebody) ->
        match lst with
        | [] -> tcomp ebody cenv
        | x :: xs ->
            let cenv1 = fst x :: cenv
            TLet(tcomp (snd x) cenv, tcomp (Let(xs, ebody)) cenv1)
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)

printfn "e17: %A" (e17)
printfn "Test tcomp: %A" (tcomp e17 [])
