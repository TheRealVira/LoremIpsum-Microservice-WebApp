using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Logon.API.Config;
using Logon.API.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Logon.API.Service
{
    public class AuthenticationService:IAuthenticationService
    {
        public MyToken Authentication(string username, string password, IOptions<Audience> _settings)
        {
            var now = DateTime.UtcNow;
  
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, username)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Secret));
  
            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Iss,
                audience: _settings.Value.Aud,
                claims: claims,  
                notBefore: now,  
                expires: now.Add(TimeSpan.FromMinutes(_settings.Value.Expiration)),  
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)  
            );  
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new MyToken()
            {
                AccessToken = encodedJwt,
                ExpiresIn = (int)TimeSpan.FromMinutes(_settings.Value.Expiration).TotalSeconds
            };
        }
    }
}
