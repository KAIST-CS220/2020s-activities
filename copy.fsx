open System
open System.IO

let copyFile src dst name =
  let s = Path.Combine (src, name)
  let d = Path.Combine (dst, name)
  File.Copy (s, d)
  d

let sed file oldString newString =
  let t = File.ReadAllText file
  let t = t.Replace (oldValue=oldString, newValue=newString)
  File.WriteAllText (file, t)

let run src dst =
  Directory.CreateDirectory dst |> ignore
  let newlib = copyFile src dst "Lib.fs"
  let newdef = copyFile src dst "Defs.fs"
  let newmyfunc = copyFile src dst "MyFunc.fs"
  let _ = copyFile src dst "Program.fs"
  let newtests = copyFile src dst "Tests.fs"
  let newproj = Path.Combine (dst, dst + ".fsproj")
  File.Copy (Path.Combine (src, src + ".fsproj"), newproj)
  sed newlib ("Activity" + src) ("Activity" + dst)
  sed newdef ("Activity" + src) ("Activity" + dst)
  sed newmyfunc ("Activity" + src) ("Activity" + dst)
  sed newtests ("Activity" + src) ("Activity" + dst)
  sed newproj ("Activity" + src) ("Activity" + dst)

let copy src dst =
  if (Directory.Exists src && not (Directory.Exists dst)) then run src dst
  else
    printfn "Invalid args given."
    exit 1

match fsi.CommandLineArgs.[1..] with
| [| src; dst |] ->
  let src = src.TrimEnd([| Path.DirectorySeparatorChar |])
  let dst = dst.TrimEnd([| Path.DirectorySeparatorChar |])
  printfn "%s -> %s" src dst
  copy src dst
| _ ->
  printfn "Usage: dotnet fsi copy.fsx [src] [dst]"
  exit 1
