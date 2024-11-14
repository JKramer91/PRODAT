(* The use of ! and := is depricated, see
   https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1111-refcell-op-information-messages.md

   Below introduces the operators again.
*)

module Util

let (!) (r: 'T ref)  = r.Value
let (:=) (r: 'T ref) (v: 'T)  = r.Value <- v
//let incr (r: int ref)  = r.Value <- r.Value + 1
//let decr (r: int ref)  = r.Value <- r.Value - 1
