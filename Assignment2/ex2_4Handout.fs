

(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)
let sinstrToInt = function
  | SCstI i -> [0;i]
  | SVar i  -> failwith "Not implemented"
  | SAdd    -> failwith "Not implemented"
  | SSub    -> failwith "Not implemented"
  | SMul    -> failwith "Not implemented"
  | SPop    -> failwith "Not implemented"
  | SSwap   -> failwith "Not implemented"

let assemble instrs = failwith "Not implemented"

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;
