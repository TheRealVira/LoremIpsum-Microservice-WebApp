using System;
using Logon.API.Config;
using Logon.API.Controllers;
using Logon.API.Service;
using Microsoft.Extensions.Options;

namespace Logon.API.Tests
{
    class AuthenticationServiceFake:IAuthenticationService
    {
        public MyToken Authentication(string username, string password, IOptions<Audience> _settings)
        {
            return new MyToken{  
                AccessToken = "token",  
                ExpiresIn = (int)TimeSpan.FromMinutes(_settings.Value.Expiration).TotalSeconds  
            };
        }
    }
}
