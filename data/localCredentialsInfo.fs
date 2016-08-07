namespace Authenticator.Data

open System

module LocalCredentialsInfo = 
    type T = {
        Email: string
        HashedPassword: string
        CreatedAt: string
        UpdatedAt: string
    }

    let create email hashedPassword = 
        {  
            Email=email
            HashedPassword=hashedPassword
            CreatedAt=DateTime.Now.ToString()
            UpdatedAt=DateTime.Now.ToString()
        }

