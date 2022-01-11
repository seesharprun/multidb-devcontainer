using System.Collections.Generic;
using Workspace.Library;

AzureCosmosDbSource cosmosSource = new("AccountEndpoint=https://azurecosmosdb:8081;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==;");
var cosmosDatabases = await cosmosSource.GetDatabaseNamesAsync();
PrintResults("Azure Cosmos DB", cosmosDatabases);

AzureStorageSource storageSource = new("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://azurestorage:10002/devstoreaccount1;");
var storageTables = await storageSource.GetTableNamesAsync();
PrintResults("Azure Storage Tables", storageTables);

SqlSource sqlSource = new("Data Source=sql,1433;User ID=sa;Password=Passw0rd;");
var sqlDatabases = await sqlSource.GetDatabaseNamesAsync();
PrintResults("SQL", sqlDatabases);

MongoSource mongoSource = new("mongodb://mongo:27017");
var mongoDatabases = await mongoSource.GetDatabaseNamesAsync();
PrintResults("Mongo DB", mongoDatabases);

DynamoDbSource dynamodbSource = new ("http://dynamodb:8000");
var dynamodbTables = await dynamodbSource.GetTableNamesAsync();
PrintResults("DynamoDB", dynamodbTables);

void PrintResults(string header, IEnumerable<string> results)
{
    Console.WriteLine($"[{header}]\tConnected");
    Console.WriteLine($"[{header}]\tEntities:");
    if (results.Any())
    {
        foreach (var result in results)
        {
            Console.WriteLine($"- {result}");
        }
    }
    else
    {
        Console.WriteLine($"  None found");
    }
}