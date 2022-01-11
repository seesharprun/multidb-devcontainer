using Xunit;
using System.Collections.Generic;
using Workspace.Library;

namespace Workspace.Tests.Integration
{
    public class MongoSourceIntegrationTests
    {
        [Fact]
        public async void MongoSource_GetDatabaseNamesAsync()
        {
            MongoSource source = new("mongodb://mongo:27017");
            IEnumerable<string> results = await source.GetDatabaseNamesAsync();

            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }
    }
}