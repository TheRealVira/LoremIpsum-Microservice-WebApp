namespace Logon.API.Service
{
    public interface IDBService
    {
        bool Login(string username, string password);
    }
}