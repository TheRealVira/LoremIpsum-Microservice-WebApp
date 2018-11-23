using Logon.API.Service;

namespace Logon.API.Tests
{
    class DBServiceFake:IDBService
    {
        public bool Login(string username, string password)
        {
            return username.Equals("username") && password.Equals("password");
        }
    }
}
