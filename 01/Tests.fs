module Activity01.Tests

open System
open System.Reflection
open Microsoft.VisualStudio.TestTools.UnitTesting
open Activity01.MFIXME // FIXME

let inline invoke<'T> (fn: MethodInfo) args =
  fn.Invoke (null, args) |> unbox<'T>

let test1 fn =
  let result = invoke<int> fn [| 42 |]
  let expectation = 74088
  result = expectation

let test2 fn =
  let result = invoke<int> fn [| -2 |]
  let expectation = -8
  result = expectation

[<TestClass>]
type TestClass () =

  let asm = Assembly.GetExecutingAssembly ()
  let m =
    asm.GetTypes ()
    |> Array.pick (fun ty ->
      ty.GetMethods ()
      |> Array.tryFind (fun m -> m.Name = "myfunc"))

  [<TestMethod>]
  member __.Test1 () =
    Assert.IsTrue (test1 m)

  [<TestMethod>]
  member __.Test2 () =
    Assert.IsTrue (test2 m)
