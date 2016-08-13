namespace Authenticator.Tests

open System.Net
open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote
open Authenticator.Api
open Authenticator.Utils.Rop

module AuthApi = 
    [<Fact>]
    let ``test`` () = 
        let actual = authEndpoints.signup ()
        test <@ actual = Success "ok" @>
