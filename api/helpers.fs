namespace Authenticator.Api

open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave
open Suave.Successful
open Suave.Operators

[<AutoOpen>]
module Helpers =
    let JSON v =
        let jsonSerializerSettings = new JsonSerializerSettings()
        jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()

        JsonConvert.SerializeObject(v, jsonSerializerSettings)
            |> OK
            >=> Writers.setMimeType "application/json; charset=utf-8"

    let fromJson<'a> json =
        JsonConvert.DeserializeObject(json, typeof<'a>) :?> 'a 

    let getResourceFromReq<'a> req = 
        let getString = System.Text.Encoding.UTF8.GetString
        req.rawForm 
            |> getString 
            |> fromJson<'a>
    