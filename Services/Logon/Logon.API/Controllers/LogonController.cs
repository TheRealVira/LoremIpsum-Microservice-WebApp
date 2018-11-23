using Logon.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Logon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private IDBService _service;

        public LogonController(IDBService service)
        {
            _service = service;
        }


        // GET: api/Logon/username/password
        [HttpGet("{username}/{password}")]
        public ActionResult<bool> Get(string username, string password)
        {
            return Ok(_service.Login(username, password));
        }
    }
}
