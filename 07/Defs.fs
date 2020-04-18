module Activity07.Defs

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
  let lst1 = Nil |> cons 3 |> cons 2 |> cons 1
  let lst2 = Nil |> cons 1 |> cons 2 |> cons 3
  let result = invoke<bool> fn [| lst1; lst2 |]
  let expectation = false
#if TEST
  printfn "Expected: %b, and Actual: %b" expectation result
#endif
  result = expectation

let test2 fn =
  let result = invoke<bool> fn [| (Nil: int MyList); (Nil: int MyList) |]
  let expectation = true
#if TEST
  printfn "Expected: %b, and Actual: %b" expectation result
#endif
  result = expectation

let test3 fn =
  let lst1 = Nil |> cons 1 |> cons 2 |> cons 3 |> cons 4
  let lst2 = Nil |> cons 1 |> cons 2 |> cons 3 |> cons 4
  let result = invoke<bool> fn [| lst1; lst2 |]
  let expectation = true
#if TEST
  printfn "Expected: %b, and Actual: %b" expectation result
#endif
  result = expectation

