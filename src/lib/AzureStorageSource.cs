using Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;

namespace Workspace.Library
{
    public class AzureStorageSource
    {
        private CloudTableClient client { get; }

        public AzureStorageSource(string connectionString)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
            client = account.CreateCloudTableClient();
        }

        public async Task<IEnumerable<string>> GetTableNamesAsync()
        {
            TableContinuationToken? token = null;
            var tables = new List<CloudTable>();
            do
            {
                var result = await client.ListTablesSegmentedAsync(token);
                tables.AddRange(result.Results);
                token = result.ContinuationToken;
            }
            while (token != null);
            return tables.Select(table => table.Name);
        }            
    }
}