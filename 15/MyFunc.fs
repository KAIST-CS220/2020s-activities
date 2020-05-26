module Activity15.MFIXME // FIXME = student id

[<AbstractClass>]
type Shape () =
  abstract Perimeter: float

type Triangle (a: Point, b: Point, c: Point) =
  inherit Shape ()
  member __.Distance a b =
    ignore a; ignore b; 0.0 // FIXME
    
  override __.Perimeter =
    __.Distance a b + __.Distance b c + __.Distance c a

type Rectangle (width: float, height: float) =
  inherit Shape ()
  override __.Perimeter =
    ignore width; ignore height; 0.0 // FIXME

// DO NOT MODIFY the function
let myfunc (q: Question) =
  match q with
  | ComputeRectanglePerimeter (width, height) ->
    Rectangle(width, height).Perimeter
  | ComputeTrianglePerimeter (a, b, c) ->
    Triangle(a, b, c).Perimeter
