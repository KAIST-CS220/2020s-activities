module Activity15.Defs

open System.Reflection

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let [<Literal>] threshold = 0.00001

let similar result expectation =
  let high = expectation + threshold
  let low = expectation - threshold
  result < high && result > low

let test1 fn =
  let q = ComputeRectanglePerimeter (4.0, 2.0)
  let result = invoke<float> fn [| q |]
  let expectation = 12.0
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  similar result expectation

let test2 fn =
  let a = { X = 1.0; Y = 1.0 }
  let b = { X = 3.0; Y = 3.0 }
  let c = { X = -1.0; Y = 4.0 }
  let q = ComputeTrianglePerimeter (a, b, c)
  let result = invoke<float> fn [| q |]
  let expectation = 10.557084025
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  similar result expectation

let test3 fn =
  let a = { X = 1.0; Y = 2.0 }
  let b = { X = 3.0; Y = -4.0 }
  let c = { X = -4.0; Y = 5.0 }
  let q = ComputeTrianglePerimeter (a, b, c)
  let result = invoke<float> fn [| q |]
  let expectation = 23.557261466
#if TEST
  printfn "Expected: %A, and Actual: %A" expectation result
#endif
  similar result expectation
