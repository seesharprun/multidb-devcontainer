using Microsoft.Azure.Cosmos;
using System.Collections.Generic;

namespace Workspace.Library
{
    public class AzureCosmosDbSource
    {
        private CosmosClient client { get; }

        public AzureCosmosDbSource(string connectionString)
        {
            CosmosClientOptions options = new ()
            {
                HttpClientFactory = () =>
                {
                    HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };

                    return new HttpClient(httpMessageHandler);
                },
                ConnectionMode = ConnectionMode.Gateway
            };
            client = new (connectionString, options);
        }

        public async Task<IEnumerable<string>> GetDatabaseNamesAsync()
        {
            QueryDefinition query = new ("SELECT * FROM d");
            FeedIterator<Database> feed = client.GetDatabaseQueryIterator<Database>(query);

            List<Database> databases = new ();
            while(feed.HasMoreResults)
            {
                databases.AddRange(
                    await feed.ReadNextAsync()
                );
            }

            return databases.Select(database => database.Id);
        }
    }
}