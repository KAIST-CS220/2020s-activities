module Activity20.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let input = "00aaa ZZZ"
  let result = invoke<Result<string * string, string>> fn [| input |]
  let expectation: Result<string * string, string> = Ok ("00aaa", " ZZZ")
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let input = "ZZZ"
  let result = invoke<Result<string * string, string>> fn [| input |]
  let expectation: Result<string * string, string> = Ok ("ZZZ", "")
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let input = ""
  let result = invoke<Result<string * string, string>> fn [| input |]
  let expectation: Result<string * string, string> = Error "No more input."
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test4 fn =
  let input = "   zzz"
  let result = invoke<Result<string * string, string>> fn [| input |]
  let expectation: Result<string * string, string> = Error "Invalid character."
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
