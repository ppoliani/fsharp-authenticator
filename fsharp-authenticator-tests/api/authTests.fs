namespace Authenticator.Tests

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote
open Authenticator.Api
open Authenticator.Utils.Rop

module AuthApi = 
    [<Fact>]
    let ``Signup endpoint return success when a new user is created`` () = 
        let actual = authEndpoints.signup ()
        test <@ actual = Success "user created" @>
    
    [<Fact>]
    let ``Signup should return failure when user already exist`` =
        let actual = authEndpoints.signup ()
        test <@ actual = Failure "User already exist" @>
