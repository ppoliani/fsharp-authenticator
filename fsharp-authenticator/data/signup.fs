namespace Authenticator.Data

module Signup = 
    type T = {
        Username: string
        Password: string
        ConfirmationPassword: string
        Email: string
        FirstName: string
        LastName: string
    }

    let verifyConfirmationPassword signup = 
        signup.Password = signup.ConfirmationPassword
