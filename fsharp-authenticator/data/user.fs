namespace Authenticator.Data

open Authenticator.Auth

module User = 
    type T = {
        Username: string
        Local: LocalCredentialsInfo.T
        Claims: Claim.T list
    }

    let defaultClaim = Claim.create "role" "admin"

    let getLocalCredentialsInfo password email =
        let hashedPassword = strongHash password 
        LocalCredentialsInfo.create email hashedPassword

    let create username password email = 
        {
            Username=username
            Local=getLocalCredentialsInfo password email
            Claims=[defaultClaim]
        }

    let verifyPassword (user:T) password = 
        verify user.Local.HashedPassword password
