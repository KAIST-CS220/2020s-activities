module Activity18.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let lst = ["aa"; "bb"; "cc"]
  let result = invoke<string list> fn [| lst |]
  let expectation = ["aa"; "aa"; "bb"; "bb"; "cc"; "cc"]
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let lst: string list = []
  let result = invoke<string list> fn [| lst |]
  let expectation: string list = []
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let lst = ["abcd"]
  let result = invoke<string list> fn [| lst |]
  let expectation = ["abcd"; "abcd"]
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
