#r "packages/Suave/lib/net40/Suave.dll"
#load "api/router.fs"

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Authenticator.Api.Router

startWebServer defaultConfig routes
