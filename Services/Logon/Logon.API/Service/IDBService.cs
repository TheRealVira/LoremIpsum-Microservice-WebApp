namespace Logon.API.Service
{
    interface IDBService
    {
        bool Login(string username, string password);
    }
}