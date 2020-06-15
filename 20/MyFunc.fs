module Activity20.MFIXME // FIXME = student id

[<NoComparison; NoEquality>]
type Parser<'a> = {
  Parse: string -> Result<'a * string, string>
}

let runOnInput parser str =
  parser.Parse str

type ParserBuilder () =
  member __.Bind (p, f) =
    { Parse = (fun s ->
        match runOnInput p s with
        | Ok (v, rest) -> runOnInput (f v) rest
        | Error e -> Error e) }

  member __.Return (v) =
    { Parse = (fun s -> Ok (v, s)) }

let parser = ParserBuilder ()

let char ch =
  { Parse = fun s ->
      if s = "" then Error "No more input."
      else
        if s.[0] = ch then Ok (s.[0], s.[1..])
        else Error "Invalid character." }

let rec sequence parsers =
  match parsers with
  | [] -> parser { return [] }
  | hd :: tl ->
    parser {
      let! h = hd
      let! t = sequence tl
      return h :: t
    }

let orElse p1 p2 =
  { Parse = fun s ->
      match runOnInput p1 s with
      | Ok (v, rest) -> Ok (v, rest)
      | Error _ -> runOnInput p2 s }

let (<|>) = orElse

let map f parser =
  { Parse = fun s ->
      match runOnInput parser s with
      | Ok (v, rest) -> Ok (f v, rest)
      | Error e -> Error e }

let (|>>) p f = map f p

let rec zeroOrMore p s = 
  match runOnInput p s with
  | Error _ -> ([], s)
  | Ok (v, s) ->
    let v', s' = zeroOrMore p s
    v :: v', s'

/// Match zero or more parser.
let many p = { Parse = fun s -> Ok (zeroOrMore p s) }

/// Match one or more parser.
let many1 _ =
  { Parse = fun _ -> Error "implement me" }

let alphaNumeric =
  let allChars =
    ['a' .. 'z'] @ ['A' .. 'Z'] @ ['0' .. '9']
  allChars
  |> List.map char
  |> List.reduce (<|>)

let toString chars =
  chars
  |> List.fold (fun str x -> str + x.ToString()) ""

let alphaNumerics =
  many1 alphaNumeric
  |>> toString

let myfunc (input: string) =
  runOnInput alphaNumerics input
