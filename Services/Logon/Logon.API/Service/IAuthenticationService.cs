using Logon.API.Controllers;
using Microsoft.Extensions.Options;

namespace Logon.API.Service
{
    public interface IAuthenticationService
    {
        MyToken Authentication(string username, string password, IOptions<Audience> _settings);
    }
}
