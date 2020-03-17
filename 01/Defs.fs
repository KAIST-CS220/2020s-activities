module Activity01.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let test1 fn =
  let result = invoke<int> fn [| 42 |]
  let expectation = 74088
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<int> fn [| -2 |]
  let expectation = -8
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation
