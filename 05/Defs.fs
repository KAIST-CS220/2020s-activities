module Activity05.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let result = invoke<float> fn [| Circle 1.0 |]
  let expectation = 3.141592654
#if TEST
  printfn "Expected: %f, and Actual: %f" expectation result
#endif
  similar result expectation

let test2 fn =
  let result = invoke<float> fn [| Triangle (2.0, 2.0, 2.0) |]
  let expectation = 1.73205080756888
#if TEST
  printfn "Expected: %f, and Actual: %f" expectation result
#endif
  similar result expectation

let test3 fn =
  let result = invoke<float> fn [| Square (3.0) |]
  let expectation = 9.0
#if TEST
  printfn "Expected: %f, and Actual: %f" expectation result
#endif
  similar result expectation

let test4 fn =
  let result = invoke<float> fn [| Triangle (2.0, 1.0, 1.0) |]
  let expectation = 0.0
#if TEST
  printfn "Expected: %f, and Actual: %f" expectation result
#endif
  similar result expectation
