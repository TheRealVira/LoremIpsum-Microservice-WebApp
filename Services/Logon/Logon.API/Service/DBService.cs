using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Logon.API.Controllers;
using Microsoft.AspNetCore.Http;
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
                InitialCatalog = "master",
                PersistSecurityInfo = false,
                Encrypt = true,
                Pooling = false,
                MultipleActiveResultSets = false,
                TrustServerCertificate = false
            };

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var sb = new StringBuilder();
                sb.Append("SELECT COUNT(*) FROM [dbo].[lipsum_user].[MLipsumUser]");
                sb.Append($"WHERE [dbo].[lipsum_user].[MLipsumUser].[Username] = '{username}' AND [dbo].[lipsum_user].[MLipsumUser].[Password] = '{password}'");

                using (var command = new SqlCommand(sb.ToString(), connection))
                {
                    var count = command.ExecuteScalar();
                    return int.Parse(count.ToString()).Equals(1);
                }
            }
        }
    }
}