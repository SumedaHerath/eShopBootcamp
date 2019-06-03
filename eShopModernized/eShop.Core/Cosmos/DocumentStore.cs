using eShop.Core.SeedWork;
using eShop.Utilities;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eShop.Core
{
    public class DocumentStore<T> : IDocumentStore<T> where T : Entity, new()
    {
        private readonly DocumentClient _documentClient;
        private readonly string _databaseName;

        public string Collection { get; set; }

        public DocumentStore(IOptions<DatabaseSettings> options)
        {
            var cosmosSettings = options.Value.Cosmos;
            var cosomosEndpoint = new Uri(cosmosSettings.CosmosUri);

            _documentClient = new DocumentClient(cosomosEndpoint, cosmosSettings.Key, new ConnectionPolicy
            {
                ConnectionMode = ConnectionMode.Direct
            });

            _databaseName = cosmosSettings.DbName;
        }

        private Uri GetDocumentCollectionUri()
        {
            return UriFactory.CreateDocumentCollectionUri(_databaseName, Collection);
        }

        private Uri GetDocumentUri(string id)
        {
            return UriFactory.CreateDocumentUri(_databaseName, Collection, id);
        }

        public async Task<T> CreateItemAsync(T entity)
        {
            entity.Id = Guid.NewGuid().ToString().ToLower();
            entity.Deleted = false;
            entity.CreatedOn = DateTime.UtcNow;

            await _documentClient.CreateDocumentAsync(GetDocumentCollectionUri(), entity);

            return entity;
        }

        public async Task<T> GetItemByIdAsync(string id)
        {
            var result = await _documentClient.ReadDocumentAsync<T>(GetDocumentUri(id));

            return result;
        }

        public async Task<T> UpdateItemAsync(string id, T entity)
        {
            await _documentClient.ReplaceDocumentAsync(GetDocumentCollectionUri(), entity);
            return entity;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate, bool AllowCrossPartition = false)
        {
            return _documentClient.CreateDocumentQuery<T>(GetDocumentCollectionUri(), new FeedOptions
                {
                    EnableCrossPartitionQuery = true
                })
                .Where(predicate)
                .ToList();
        }
    }
}
