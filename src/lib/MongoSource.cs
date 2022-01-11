using MongoDB.Driver;
using System.Collections.Generic;

namespace Workspace.Library
{
    public class MongoSource
    {
        private MongoClient client { get; }

        public MongoSource(string connectionString)
        {        
            client = new (connectionString);
        }

        public async Task<IEnumerable<string>> GetDatabaseNamesAsync() =>
            await (await client.ListDatabaseNamesAsync()).ToListAsync<string>();
    }
}