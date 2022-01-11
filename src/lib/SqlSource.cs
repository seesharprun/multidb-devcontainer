using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Workspace.Library
{
    public class SqlSource
    {
        private SqlConnection client { get; }

        public SqlSource(string connectionString)
        {
            client = new(connectionString);
        }

        public async Task<IEnumerable<string>> GetDatabaseNamesAsync() =>
            await client.QueryAsync<string>("SELECT name FROM sys.databases");
    }
}