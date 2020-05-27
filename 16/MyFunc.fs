module Activity16.MFIXME // FIXME = student id

let car = function
  | Nil -> failwith "Nil"
  | Cons (elt, _) -> elt

let cdr = function
  | Nil -> failwith "Nil"
  | Cons (_, thunk) -> thunk ()

let rec take stream n =
  if n <= 0 then Nil
  else Cons (car stream, fun () -> take (cdr stream) (n-1))

// DO NOT MODIFY the function def
let myfunc (size: int): Stream<int> =
  ignore size; Nil
