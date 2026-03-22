using System;
using Azure;
using Azure.Search.Documents.Indexes;
using Puls.Cloud.Framework.Infrastructure.AzureSearch;

namespace Puls.Cloud.Framework.AzureSearch
{
    internal class SearchIndexClientFactory : ISearchIndexClientFactory
    {
        private readonly AzureSearchConfig _azureSearchConfig;

        public SearchIndexClientFactory(AzureSearchConfig azureSearchConfig)
        {
            _azureSearchConfig = azureSearchConfig;
        }

        public SearchIndexClient Create()
        {
            var endPoint = new Uri(_azureSearchConfig.EndPoint);
            var credential = new AzureKeyCredential(_azureSearchConfig.AdminKey);
            var searchIndexClient = new SearchIndexClient(endPoint, credential);

            return searchIndexClient;
        }
    }
}