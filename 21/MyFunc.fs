module Activity21.MFIXME // FIXME = student id

type Expr =
  | Number of int
  | Add of Expr * Expr
  | Sub of Expr * Expr

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

// One or more
let many1 p =
  parser {
    let! x = p // one p
    let! xs = many p // zero or more ps
    return x :: xs
  }

let digit = // Parser<char>
  char '0' <|> char '1' <|> char '2' <|> char '3' <|> char '4' <|> char '5' <|>
  char '6' <|> char '7' <|> char '8' <|> char '9'

let toString chars =
  chars
  |> List.fold (fun str x -> str + x.ToString()) ""

let number = // Parser<Expr>
  many1 digit
  |>> (toString >> int >> Number)

let mutable exprRef = { Parse = fun _ -> failwith "XXX" }

/// The parser for our AST of AddSubLang
let expr = { Parse = fun s -> runOnInput exprRef s }

let exprAdd =
  parser {
    let! n = number
    let! _ = char '+'
    let! e = expr
    return Add (n, e)
  }

let exprSub =
  parser {
    let! n = number
    let! _ = char '-'
    let! e = expr
    return Sub (n, e)
  }

exprRef <- // Tying the knot
  exprAdd <|> exprSub <|> number

/// Expr -> int
let rec evalExpr = function
  | _ -> 42

let myfunc (input: string) =
  runOnInput expr input
  |> function
    | Ok (ast, _rest) -> evalExpr ast
    | Error (_) -> -1
