namespace Authenticator.Data

module Claim = 
    type T = {
        Type: string
        Value: string
    }

    let create claimType value = 
        { T.Type=claimType; T.Value=value }
