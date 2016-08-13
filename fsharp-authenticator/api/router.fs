namespace Authenticator.Api

open Suave
open Suave.Web
open Suave.Successful
open Suave.Http
open Suave.Operators
open Suave.Filters
open Suave.RequestErrors

[<AutoOpen>]
module Router =
    let routes = 
        choose 
            [ GET >=> choose 
                [ path "/signup" >=> OK "signup"]]
