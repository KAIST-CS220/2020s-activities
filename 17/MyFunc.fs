module Activity17.MFIXME // FIXME = student id

/// FIX this function
let map (input: string) =
  async {
    ignore input
    return 0
  }

/// DO NOT MODIFY BELOW

let reduce (count1: int) (count2: int) =
  count1 + count2

let mapReduce (arr: string []) =
  arr
  |> Array.map map
  |> Async.Parallel 
  |> Async.RunSynchronously
  |> Array.reduce reduce

// DO NOT MODIFY the function
let myfunc (arr: string []): int =
  mapReduce arr
