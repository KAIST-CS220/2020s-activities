module Activity17.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let arr = [| "aaa bbb ccc"; "xxx yyy zzz"; "a" |]
  let result = invoke<int> fn [| arr |]
  let expectation = 7
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let arr = [| "aaa bbb ccc"; ""; "aaa aaa aaa aaa aaa"; "" |]
  let result = invoke<int> fn [| arr |]
  let expectation = 8
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let arr = [| "aaa bbb ccc ddd"
               "a b c d e f g h"
               "a b c d e f g h"
               "a b c d e f g h"
               "aaa aaa aaa aaa aaa" |]
  let result = invoke<int> fn [| arr |]
  let expectation = 33
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
