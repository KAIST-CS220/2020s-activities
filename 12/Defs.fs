module Activity12.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let result = invoke<uint32> fn [| 0u; 100u |]
  let expectation = 0u
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<uint32> fn [| 100u; 60u |]
  let expectation = 40u
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let result = invoke<uint32> fn [| 100u; 100u |]
  let expectation = 0u
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
