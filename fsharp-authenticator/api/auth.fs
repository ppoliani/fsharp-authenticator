namespace Authenticator.Api

open Authenticator.Utils
open Authenticator.Data

module authEndpoints = 
    let private verifyConfirmationPassword signup = 
        if Signup.verifyConfirmationPassword signup = true
        then Success signup
        else Failure "Password mismatch"

    let private verifyUserUniqueness findUser (signup:Signup.T) = 
        match findUser signup.Username signup.Email with
                | Failure f -> Failure f
                | Success _ -> Success signup

    let signup (signup:Signup.T) findUser = 
        signup 
        |> verifyConfirmationPassword
        >>= verifyUserUniqueness findUser
        >>= (fun signup -> 
            Success "User created")
            

