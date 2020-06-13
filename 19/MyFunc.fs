module Activity19.MFIXME // FIXME = student id

type MaybeBuilder () =
  member __.Bind (m, f) = Option.bind f m
  member __.Return (m) = Some m

let maybe = MaybeBuilder ()

// Make this function in such a way that the output is None if any of the three
// parameters are None. If all the parameters are "Some", then the output
// should be Some of (fn x y).
let myfunc (fn: (int -> int -> int) option) (x: int option) (y: int option) =
  ignore fn
  ignore x
  ignore y
  Some 0
