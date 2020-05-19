module Activity13.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let lst = [ Dog (42) :> Animal
              Cat (42) :> Animal ]
  let result = invoke<int> fn [| lst |]
  let expectation = 84
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test2 fn =
  let lst: Animal list = []
  let result = invoke<int> fn [| lst |]
  let expectation = 0
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation

let test3 fn =
  let lst = [ Cat (42) :> Animal ]
  let result = invoke<int> fn [| lst |]
  let expectation = 42
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  result = expectation
