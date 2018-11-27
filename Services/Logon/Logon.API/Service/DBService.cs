using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Logon.API.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Logon.API.Service
{
    public class DBService : IDBService
    {
        public bool Login(string username, string password)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "lipsumusers.database.windows.net",
                UserID = "johanna.ruehrig",
                Password = "Passw0rd,.-,.-,.-,",
                InitialCatalog = "Lipsumuser"
            };

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var sb = new StringBuilder();
                sb.Append("SELECT COUNT(*) FROM [MLipsumUser]");
                sb.Append($"WHERE [MLipsumUser].[Username] = '{username}' AND [MLipsumUser].[Password] = '{password}'");

                using (var command = new SqlCommand(sb.ToString(), connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return int.Parse(reader.GetString(0)).Equals(1);
                    }
                }
            }
        }

        
    }
}