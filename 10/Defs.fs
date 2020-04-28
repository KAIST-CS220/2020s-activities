module Activity10.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let m = Map.empty |> Map.add "aaa" "111"
  let result = invoke<Map<string, string>> fn [| "aaa"; "222"; m |]
  let expectation: Map<string, string> = m
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let m = Map.empty |> Map.add "aaa" "111"
  let result = invoke<Map<string, string>> fn [| "baa"; "222"; m |]
  let expectation: Map<string, string> = m |> Map.add "baa" "222"
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let m: Map<string, string> = Map.empty
  let result = invoke<Map<string, string>> fn [| "aaa"; "222"; m |]
  let expectation: Map<string, string> = m |> Map.add "aaa" "222"
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
