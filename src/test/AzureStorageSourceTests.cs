using Xunit;
using System.Collections.Generic;
using Workspace.Library;

namespace Workspace.Tests.Integration
{
    public class AzureStorageSourceIntegrationTests
    {
        [Fact]
        public async void AzureStorageSource_GetDatabaseNamesAsync()
        {
            AzureStorageSource source = new("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://azurestorage:10002/devstoreaccount1;");
            IEnumerable<string> results = await source.GetTableNamesAsync();

            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}