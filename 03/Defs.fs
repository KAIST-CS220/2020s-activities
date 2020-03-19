module Activity03.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let test1 fn =
  let result = invoke<int64> fn [| -1L; 2000L |]
  let expectation = -2001L
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<int64> fn [| -100L; 9223372036854775807L |]
  let expectation = 0L
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test3 fn =
  let result = invoke<int64> fn [| -9223372036854775802L; 42L |]
  let expectation = 0L
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test4 fn =
  let result = invoke<int64> fn [| 100L; -9223372036854775807L |]
  let expectation = 0L
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation
