namespace Activity15

// DO NOT MODIFY THIS FILE

type Point = {
  X: float
  Y: float
}

type Question =
  | ComputeTrianglePerimeter of a: Point * b: Point * c: Point
  | ComputeRectanglePerimeter of width: float * height: float
