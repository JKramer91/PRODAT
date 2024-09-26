(* Lexing and parsing of micro-ML programs using fslex and fsyacc *)

module Parse

open System
open System.IO
open System.Text
open FSharp.Text.Lexing
open Absyn

(* Plain parsing from a string, with poor error reporting *)

let fromString (str: string) : expr =
    let lexbuf = (*Lexing. insert if using old PowerPack *)
        LexBuffer<char>.FromString(str)

    try
        FunPar.Main FunLex.Token lexbuf
    with exn ->
        let pos = lexbuf.EndPos
        failwithf "%s near line %d, column %d\n" (exn.Message) (pos.Line + 1) pos.Column

(* Parsing from a file *)

let fromFile (filename: string) =
    use reader = new StreamReader(filename)

    let lexbuf = (* Lexing. insert if using old PowerPack *)
        LexBuffer<char>.FromTextReader reader

    try
        FunPar.Main FunLex.Token lexbuf
    with exn ->
        let pos = lexbuf.EndPos
        failwithf "%s in file %s near line %d, column %d\n" (exn.Message) filename (pos.Line + 1) pos.Column

(* Exercise it *)

let e1 = fromString "5+7"
let e2 = fromString "let f x = x + 7 in f 2 end"

(* Examples in concrete syntax *)

let ex1 = fromString @"let f1 x = x + 1 in f1 12 end"

(* Example: factorial *)

let ex2 =
    fromString
        @"let fac x = if x=0 then 1 else x * fac(x - 1)
              in fac n end"

(* Example: deep recursion to check for constant-space tail recursion *)

let ex3 =
    fromString
        @"let deep x = if x=0 then 1 else deep(x-1) 
              in deep count end"

(* Example: static scope (result 14) or dynamic scope (result 25) *)

let ex4 =
    fromString
        @"let y = 11
              in let f x = x + y
                 in let y = 22 in f 3 end 
                 end
              end"

(* Example: two function definitions: a comparison and Fibonacci *)

let ex5 =
    fromString
        @"let ge2 x = 1 <s x
              in let fib n = if ge2(n) then fib(n-1) + fib(n-2) else 1
                 in fib 25 
                 end
              end"


// (4.2)

//4.2a
let ex6 =
    fromString @"let sum n = if n = 1 then 1 else n + sum (n-1) in sum 1000 end"


//4.2b
let ex7 = fromString @"let pow e = if e = 0 then 1 else 3 * pow (e-1) in pow 8 end"

//4.2c
let ex8 =
    fromString
        @"let pow e = if e = 0 then 1 else 3 * pow (e-1) in 
                         let threeToEleven e = if e = 0 then 1 else pow e + threeToEleven (e-1) in threeToEleven 11 
                         end
                      end "


//4.2d

// This is how we first thought of doing it before the hacky solution below (this threw an exception though and thus didn't work)
(*let ex9 =
    fromString
        @"let e = 8 in 
                  let pow b = if e = 0 then 1 else b * pow (e-1) in 
                  let sumExp b = if b = 1 then 1 else pow b + sumExp (b-1)
                  in sumExp 10 
                  end
                end
            end"*)

let ex9 =
    fromString
        @"let pow x = x*x*x*x*x*x*x*x
                  in let sumExp b = if b = 1 then 1 else pow b + sumExp (b-1) 
                  in sumExp 10 
                  end
                end"

// 4.4 test
let ex10 =
    fromString @"let pow x n = if n=0 then 1 else x * pow x (n-1) in pow 3 8 end"

let ex11 =
    fromString
        @"let max2 a b = if a<b then b else a
        in let max3 a b c = max2 a (max2 b c)
        in max3 25 6 62 end
        end"

// 4.5 Tests
let ex12 = fromString @"let test x = if true || false then 1 else 0 in test 5 end"

let ex13 = fromString @"let test = true || false in test end"
