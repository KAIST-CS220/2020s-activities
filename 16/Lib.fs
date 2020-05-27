namespace Activity16

// DO NOT MODIFY THIS FILE
[<NoComparison; NoEquality>]
type Stream<'a> =
  | Nil
  | Cons of 'a * (unit -> Stream<'a>)
