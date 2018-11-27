using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Logon.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Logon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : Controller
    {
        private IDBService _dbService;
        private IAuthenticationService _authenticationService;
        private IOptions<Audience> _settings;

        public LogonController(IDBService dbService, IAuthenticationService authenticationService, IOptions<Audience> settings)
        {
            _dbService = dbService;
            _authenticationService = authenticationService;
            _settings = settings;
        }


        // GET: api/Logon/username/password
        [HttpGet("{username}/{password}")]
        public ActionResult<MyToken> Get(string username, string password)
        {
            if (!_dbService.Login(username, password)) return BadRequest();
  
            return Ok(_authenticationService.Authentication(username, password, _settings));
        }
    }

    public class MyToken
    {
        public string AccessToken { get;set;}
        public int ExpiresIn { get; set; }
    }

    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
        public int Expiration { get; set; }
    }
}
