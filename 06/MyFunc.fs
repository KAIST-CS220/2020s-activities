module Activity06.MFIXME // FIXME = student id

let rec computeLength lst =
  match lst with
  | Cons (_, tl) -> 1 + computeLength tl
  | Nil -> 0

let myfunc (lst: int MyList) = // DO NOT TOUCH THIS LINE
  computeLength lst
