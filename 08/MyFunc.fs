module Activity08.MFIXME // FIXME = student id

let myfunc (fn: int -> int -> int) (lst: int list) = // DO NOT TOUCH THIS LINE
  match lst with
  | [] -> failwith "Empty"
  | _ ->
    ignore fn // Just to suppress warning =)
    0
