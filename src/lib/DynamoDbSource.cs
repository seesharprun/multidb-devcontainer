using Amazon.DynamoDBv2;
using System.Collections.Generic;

namespace Workspace.Library
{
    public class DynamoDbSource
    {
        private AmazonDynamoDBClient client { get; }

        public DynamoDbSource(string serviceUrl)
        {
            AmazonDynamoDBConfig config = new ()
            {
                ServiceURL = serviceUrl
            };
            client = new (
                awsAccessKeyId: $"{Guid.NewGuid()}",
                awsSecretAccessKey: $"{Guid.NewGuid()}",
                clientConfig: config
            );
        }
        
        public async Task<IEnumerable<string>> GetTableNamesAsync() =>
            (await client.ListTablesAsync()).TableNames;
    }
}