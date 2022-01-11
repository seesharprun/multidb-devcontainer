using MongoDB.Driver;
using Amazon.DynamoDBv2;

MongoClient mongoClient = new ("mongodb://mongo:27017");
Console.WriteLine("[Mongo]\tConnected");

var databaseList = await mongoClient.ListDatabaseNamesAsync();

Console.WriteLine("[Mongo]\tDatabases:");
foreach (var database in await databaseList.ToListAsync<string>())
{
    Console.WriteLine($"- {database}");
}



AmazonDynamoDBConfig dynamodbConfig = new ()
{
    ServiceURL = "http://dynamodb:8000"
};
AmazonDynamoDBClient dynamodbClient = new (
    awsAccessKeyId: $"{Guid.NewGuid()}",
    awsSecretAccessKey: $"{Guid.NewGuid()}",
    clientConfig: dynamodbConfig
);
Console.WriteLine("[DynamoDB]\tConnected");

var tableList = await dynamodbClient.ListTablesAsync();

Console.WriteLine("[DynamoDB]\tTables:");
foreach (var table in tableList.TableNames)
{
    Console.WriteLine($"- {table}");
}