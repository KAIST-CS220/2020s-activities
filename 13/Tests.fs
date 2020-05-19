module Activity13.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open System.Reflection

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
    Assert.IsTrue (Defs.test1 m)

  [<TestMethod>]
  member __.Test2 () =
    Assert.IsTrue (Defs.test2 m)

  [<TestMethod>]
  member __.Test3 () =
    Assert.IsTrue (Defs.test3 m)
