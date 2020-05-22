namespace Activity14

// DO NOT MODIFY THIS FILE

type IMovable =
  abstract Speed: float

type IScorable =
  abstract Kill: unit -> float

type BadGuy (name) =
  member __.Name: string = name
  interface IMovable with
    override __.Speed = 1.0
  interface IScorable with
    override __.Kill () = 1.0

type Boss () =
  interface IMovable with
    override __.Speed = 100.0
  interface IScorable with
    override __.Kill () = 100.0
