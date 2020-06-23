module Activity21.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let input = "1+2"
  let result = invoke<int> fn [| input |]
  let expectation = 3
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let input = "1 + 2"
  let result = invoke<int> fn [| input |]
  let expectation = 1
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let input = "1+2-4"
  let result = invoke<int> fn [| input |]
  let expectation = -1
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test4 fn =
  let input = "0+0-0"
  let result = invoke<int> fn [| input |]
  let expectation = 0
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
