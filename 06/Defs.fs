module Activity06.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let cons elt lst = Cons (elt, lst)

let test1 fn =
  let lst = Nil |> cons 3 |> cons 2 |> cons 1
  let result = invoke<int> fn [| lst |]
  let expectation = 3
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<int> fn [| (Nil: int MyList) |]
  let expectation = 0
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

let test3 fn =
  let lst = Nil |> cons 1 |> cons 2 |> cons 3 |> cons 4
  let result = invoke<int> fn [| lst |]
  let expectation = 4
#if TEST
  printfn "Expected: %d, and Actual: %d" expectation result
#endif
  result = expectation

