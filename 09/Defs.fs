module Activity09.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let lst1 = [10; 20; 30]
  let lst2 = [-10; -20; -30]
  let result = invoke<int list> fn [| lst1; lst2 |]
  let expectation: int list = []
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  List.sort result = List.sort expectation

let test2 fn =
  let lst1 = [10; 20; 30]
  let lst2 = [20; 10; 0]
  let result = invoke<int list> fn [| lst1; lst2 |]
  let expectation = [10; 20]
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  List.sort result = List.sort expectation

let test3 fn =
  let lst1 = [10; 20; 30; 40]
  let lst2 = [40; 20; 10; 30]
  let result = invoke<int list> fn [| lst1; lst2 |]
  let expectation = [10; 20; 30; 40]
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  List.sort result = List.sort expectation

