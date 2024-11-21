let rec facr n = 
  if n=0 then 1 
  else n * facr(n-1)

let rec faca n a =
  if n=0 then a
  else faca (n-1) (n*a)
  
let rec facc n k = 
  if n=0 then k 1 
  else facc (n-1) (fun v -> k(n * v))


let ex = [1;2;3;30;323]
let x = List.map (fun n -> facr n = facc n id) ex
let y = List.map (fun n -> facr n = faca n 1) ex

(*

facc 3 id
==> facc 2 (fun v -> id(3 * v))
==> facc 1 (fun w -> (fun v -> id(3 * v)) (2 * w))
==> facc 0 (fun u -> (fun w -> (fun v -> id(3 * v)) (2 * w)) (1 * u))
==> (fun u -> (fun w -> (fun v -> id(3 * v)) (2 * w)) (1 * u)) 1
==> (fun w -> (fun v -> id(3 * v)) (2 * w)) (1 * 1)
==> (fun w -> (fun v -> id(3 * v)) (2 * w)) 1
==> (fun v -> id(3 * v)) (2 * 1)
==> (fun v -> id(3 * v)) 2
==> id(3 * 2)
==> id 6
==> 6

*)
