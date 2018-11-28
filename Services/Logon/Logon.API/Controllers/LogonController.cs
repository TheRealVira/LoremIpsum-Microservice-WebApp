using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Logon.API.Config;
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
        private IOptions<Audience> _audienceOptions;
        private IOptions<DebuggingMode> _debuggingModeOptions;

        public LogonController(IDBService dbService, IAuthenticationService authenticationService,
            IOptions<Audience> audienceOptions, IOptions<DebuggingMode> debuggingModeOptions)
        {
            _dbService = dbService;
            _authenticationService = authenticationService;
            _audienceOptions = audienceOptions;
            _debuggingModeOptions = debuggingModeOptions;
        }


        // GET: api/Logon/username/password
        [HttpGet("{username}/{password}")]
        public ActionResult<MyToken> Get(string username, string password)
        {
            if (_debuggingModeOptions.Value.IsOn)
            {
                if (username.Equals("Tester1") && password.Equals("Tester1"))
                {
                    return Ok(_authenticationService.Authentication(username, password, _audienceOptions));
                }

                return BadRequest();
            }

            if (!_dbService.Login(username, password)) return BadRequest();
  
            return Ok(_authenticationService.Authentication(username, password, _audienceOptions));
        }
    }

    public class MyToken
    {
        public string AccessToken { get;set;}
        public int ExpiresIn { get; set; }
    }
}
