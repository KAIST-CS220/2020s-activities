module Activity19.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let f = Some (fun x y -> x + y)
  let fst = Some 42
  let snd = Some 42
  let result = invoke<int option> fn [| f; fst; snd  |]
  let expectation = Some 84
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let f = Some (fun x y -> x + y)
  let fst = None
  let snd = Some 42
  let result = invoke<int option> fn [| f; fst; snd  |]
  let expectation = None
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let f = None
  let fst = Some 42
  let snd = None
  let result = invoke<int option> fn [| f; fst; snd  |]
  let expectation = None
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test4 fn =
  let f = Some (fun x y -> x * y)
  let fst = Some 42
  let snd = Some 1
  let result = invoke<int option> fn [| f; fst; snd  |]
  let expectation = Some 42
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
