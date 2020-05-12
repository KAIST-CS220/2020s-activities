module Activity11.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let st = { Count = 42 }
  let result = invoke<CounterState> fn [| st |]
  let expectation = { Count = 43 }
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let st = { Count = 0 }
  let result = invoke<CounterState> fn [| st |]
  let expectation = { Count = 1 }
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
