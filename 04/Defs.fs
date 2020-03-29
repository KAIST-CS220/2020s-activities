module Activity04.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let test1 fn =
  let result = invoke<int> fn [| 59129123; 1929149 |]
  let expectation = 1
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<int> fn [| 10502050; 4012032 |]
  let expectation = 2
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test3 fn =
  let result = invoke<int> fn [| 54; 24 |]
  let expectation = 6
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test4 fn =
  let result = invoke<int> fn [| 100; 0 |]
  let expectation = 100
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation
