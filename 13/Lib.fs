namespace Activity13

// DO NOT MODIFY THIS FILE

[<AbstractClass>]
type Animal (age: int) =
  abstract Breathe: unit -> unit
  member __.Age with get() = age

type Dog (age) =
  inherit Animal (age)
  override __.Breathe () =
    printfn "Dog is breathing."

type Cat (age) =
  inherit Animal (age)
  override __.Breathe () =
    printfn "Cat is breathing."
