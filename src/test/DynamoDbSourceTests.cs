using Xunit;
using System.Collections.Generic;
using Workspace.Library;

namespace Workspace.Tests.Integration
{
    public class DynamoDbSourceIntegrationTests
    {
        [Fact]
        public async void DynamoDbSource_GetDatabaseNamesAsync()
        {
            DynamoDbSource source = new("http://dynamodb:8000");
            IEnumerable<string> results = await source.GetTableNamesAsync();

            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}