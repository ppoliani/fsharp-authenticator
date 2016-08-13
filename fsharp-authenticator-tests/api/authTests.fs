namespace Authenticator.Tests

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote

module AuthApi = 
    [<Fact>]
    let ``test`` () = 
        test <@ 5 = 5 @> 
