module File

open System

type ServiceXXX () =
    let x = Random()
    let mutable f = 0
    let mutable counter = 0

    let run () =
        async {
            while true do
              f <- x.Next()
              counter <- counter + 1
              do! Async.Sleep 1000
        }

    do
       run () |> Async.Start

    member this.Next () =
        f

    member this.Counter () =
      counter