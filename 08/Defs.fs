module Activity08.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let f a b = a + b
  let lst = [10; 20; 30; -40]
  let result = invoke<int> fn [| f; lst |]
  let expectation = 20
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test2 fn =
  let f a b = a * a + b * b
  let lst = [1; -1]
  let result = invoke<int> fn [| f; lst |]
  let expectation = 2
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test3 fn =
  let f a b = a + b
  let lst = [42]
  let result = invoke<int> fn [| f; lst |]
  let expectation = 42
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

