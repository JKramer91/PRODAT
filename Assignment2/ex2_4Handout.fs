(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)


printfn "hello"

type sinstr =
    | SCstI of int (* push integer           *)
    | SVar of int (* push variable from env *)
    | SAdd (* pop args, push sum     *)
    | SSub (* pop args, push diff.   *)
    | SMul (* pop args, push product *)
    | SPop (* pop value/unbind var   *)
    | SSwap (* exchange top and next  *)

let sinstrToInt =
    function
    | SCstI i -> [ 0; i ]
    | SVar i -> [ 1; i ]
    | SAdd -> [ 2 ]
    | SSub -> [ 3 ]
    | SMul -> [ 4 ]
    | SPop -> [ 5 ]
    | SSwap -> [ 6 ]





let assemble instrs =
    List.foldBack (fun x acc -> sinstrToInt x :: acc) instrs []
    |> List.collect (fun x -> x)

let e1 =
    [ SCstI 17
      SCstI 22
      SCstI 100
      SVar 1
      SMul
      SSwap
      SPop
      SVar 1
      SAdd
      SSwap
      SPop ]

printfn "%A" (assemble e1)

(* Output the integers in list inss to the text file called fname: *)


let intsToFile (inss: int list) (fname: string) =
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text)
