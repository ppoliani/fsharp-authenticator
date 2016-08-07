namespace Authenticator.Data

open System

module LocalCredentialsInfo = 
    type T = {
        Email: string
        HashedPassword: string
        Salt: string
        CreatedAt: string
        UpdatedAt: string
    }

    let create email hashedPassword salt = 
        {  
            Email=email
            HashedPassword=hashedPassword
            Salt=salt
            CreatedAt=DateTime.Now.ToString()
            UpdatedAt=DateTime.Now.ToString()
        }

