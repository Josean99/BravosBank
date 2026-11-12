using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;
using BravosBank.Shared.EventSourcing.Persistance.Repositories.Interfaces;
using BravosBank.Shared.EventSourcing.Settings;
using BravosBank.Shared.EventSourcing.Bson;

namespace BravosBank.Shared.EventSourcing.Persistance.Repositories
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {      
        
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoClient mongoClient, IOptions<MongoSettings> options)
        {
            _collection = mongoClient
                .GetDatabase(options.Value.DatabaseName)
                .GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            BsonCollectionAttribute? bsonCollectionAttribute = documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault() as BsonCollectionAttribute;
            if (bsonCollectionAttribute is not null)
            {
                return bsonCollectionAttribute.CollectionName;
            }
            throw new InvalidOperationException($"BsonCollection attribute is not defined in {documentType.Name}");
        }
        public async Task<IClientSessionHandle> BeginSessionAsync(CancellationToken cancellationToken)
        {
            var options = new ClientSessionOptions
            {
                DefaultTransactionOptions = new TransactionOptions() { }
            };
            return await _collection.Database.Client.StartSessionAsync(options, cancellationToken);
        }

        public void BeginTransaction(IClientSessionHandle clientSessionHandle)
        {
            clientSessionHandle.StartTransaction();
        }

        public Task CommitTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken)
        {
            return clientSessionHandle.CommitTransactionAsync(cancellationToken);
        }

        public void DisposeSession(IClientSessionHandle clientSessionHandle)
        {
            clientSessionHandle.Dispose();
        }

        public Task RollBackTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken)
        {
            return clientSessionHandle.AbortTransactionAsync(cancellationToken);
        }

        public async Task InsertOneAsync(TDocument document, IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(clientSessionHandle, document, null, cancellationToken);
        }

        public IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable<TDocument>();
        }

        public async Task<IEnumerable<TDocument>> FilterByAsync(Expression<Func<TDocument, bool>> filterExpression, CancellationToken cancellationToken)
        {
            var result = await _collection.FindAsync(filterExpression, null, cancellationToken);

            var resultList = await result.ToListAsync();
            return resultList.Any() ? resultList : Enumerable.Empty<TDocument>();
        }
    }
}
