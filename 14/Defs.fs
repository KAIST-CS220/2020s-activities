module Activity14.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let lst1 = [ BadGuy ("A")
               BadGuy ("B")
               BadGuy ("C") ]
  let lst2 = [ Boss () ]
  let result = invoke<float> fn [| lst1; lst2 |]
  let expectation = 103.0
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  similar result expectation

let test2 fn =
  let lst1: BadGuy list = []
  let lst2 = [ Boss (); Boss () ]
  let result = invoke<float> fn [| lst1; lst2 |]
  let expectation = 200.0
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  similar result expectation

let test3 fn =
  let lst1: BadGuy list = []
  let lst2: Boss list = []
  let result = invoke<float> fn [| lst1; lst2 |]
  let expectation = 0.0
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  similar result expectation
