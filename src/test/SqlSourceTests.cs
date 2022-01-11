using Xunit;
using System.Collections.Generic;
using Workspace.Library;

namespace Workspace.Tests.Integration
{
    public class SqlSourceIntegrationTests
    {
        [Fact]
        public async void SqlSource_GetDatabaseNamesAsync()
        {
            SqlSource source = new("Data Source=sql,1433;User ID=sa;Password=Passw0rd;");
            IEnumerable<string> results = await source.GetDatabaseNamesAsync();

            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }
    }
}