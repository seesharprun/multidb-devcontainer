using Xunit;
using System.Collections.Generic;
using Workspace.Library;

namespace Workspace.Tests.Integration
{
    public class AzureCosmosDbSourceIntegrationTests
    {
        [Fact]
        public async void AzureCosmosDbSource_GetDatabaseNamesAsync()
        {
            AzureCosmosDbSource source = new("AccountEndpoint=https://azurecosmosdb:8081;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==;");
            IEnumerable<string> results = await source.GetDatabaseNamesAsync();

            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}