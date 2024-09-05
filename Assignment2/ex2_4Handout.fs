(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)


printfn "hello"

(*
let sinstrToInt =
    function
    | SCstI i -> [ 0; i ]
    | SVar i -> [ 1; i ]
    | SAdd -> [ 2 ]
    | SSub -> [ 3 ]
    | SMul -> [ 4 ]
    | SPop -> [ 5 ]
    | SSwap -> [ 6 ] *)

(*
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
  *)

//let assemble instrs = List.fold

(* Output the integers in list inss to the text file called fname: *)

(*
let intsToFile (inss: int list) (fname: string) =
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text) *)
