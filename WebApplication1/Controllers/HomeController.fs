namespace WebApplication1.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.Diagnostics

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

open WebApplication1.Models
open File

type HomeController (logger : ILogger<HomeController>, s : ServiceXXX) =
    inherit Controller()

    member this.Index () =
        this.ViewData.["number"] <- s.Next()
        this.ViewData.["counter"] <- s.Counter()
        this.View()

    member this.Privacy () =
        this.View()

    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error () =
        let reqId = 
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })
