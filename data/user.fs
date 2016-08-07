namespace Authenticator.Data

module User = 
    type T = {
        Username: string
        Local: LocalCredentialsInfo.T
        Claims: Claim.T list
    }

    let defaultClaim = Claim.create "role" "admin"

    let getLocalCredentialsInfo password email =
        LocalCredentialsInfo.create email "hashedPassword" "salt"

    let create username password email = 
        {
            Username=username
            Local=getLocalCredentialsInfo password email
            Claims=[defaultClaim]
        }
