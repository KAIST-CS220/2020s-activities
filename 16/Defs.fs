module Activity16.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let fromList lst =
  List.foldBack (fun elt stream ->
    Cons (elt, fun () -> stream)) lst Nil

let rec toList = function
  | Nil -> []
  | Cons (elt, thunk) ->
    elt :: toList (thunk ())

let test1 fn =
  let result = invoke<Stream<int>> fn [| 5 |]
  let expectation = [0; 1; 1; 2; 3]
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  toList result = expectation

let test2 fn =
  let result = invoke<Stream<int>> fn [| 10 |]
  let expectation = [0; 1; 1; 2; 3; 5; 8; 13; 21; 34]
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  toList result = expectation
