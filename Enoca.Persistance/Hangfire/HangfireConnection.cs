using Enoca.ApplicationLayer.Interface.Hangfire.Connection;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistance.Hangfire
{
    public class HangfireConnection : IHangfireConnection
    {
        public void EnsureHangfireDatabaseExists(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = builder.InitialCatalog;

            // Connect to the master database
            builder.InitialCatalog = "master";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
                IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{databaseName}')
                BEGIN
                    CREATE DATABASE [{databaseName}]
                END";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
