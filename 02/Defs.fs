module Activity02.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let test1 fn =
  let result = invoke<int> fn [| -1; -1; -1; -1 |]
  let expectation = -1
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<int> fn [| 1; -1; 2; 2 |]
  let expectation = 2
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test3 fn =
  let result = invoke<int> fn [| -200; -100; -300; -400 |]
  let expectation = -100
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test4 fn =
  let result = invoke<int> fn [| 0; 0; 1; 2 |]
  let expectation = 2
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation
