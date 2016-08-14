namespace Authenticator.Tests

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote
open Authenticator.Api
open Authenticator.Data
open Authenticator.Utils.Rop

module AuthApi = 
    let findUser username email = 
        if username = "exists" 
        then Failure "User exists"
        else Success () 

    let defaultSignup: Signup.T = 
        {
            Username="username"
            Password="password"
            ConfirmationPassword="password"
            Email="email"
            FirstName="Pavlos"
            LastName="Polianidis"}

    [<Fact>]
    let ``Signup endpoint return Success when a new user is created`` () = 

        let actual = authEndpoints.signup defaultSignup findUser
        test <@ actual = Success "User created" @>
    
    [<Fact>]
    let ``Signup should return Failure when the password confirmation is not correct`` =
        let signup = { defaultSignup with ConfirmationPassword="wrong password" }
        
        let actual = authEndpoints.signup signup findUser
        test <@ actual = Failure "Password mismatch" @>

    [<Fact>]
    let ``Signup should return Failure when the username or email already exists`` =
        let signup = { defaultSignup with Username="exists" }
        let actual = authEndpoints.signup signup findUser
        test <@ actual = Failure "User exists" @>
