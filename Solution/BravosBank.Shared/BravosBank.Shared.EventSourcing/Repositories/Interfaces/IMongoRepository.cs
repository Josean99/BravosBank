using MongoDB.Driver;
using System.Linq.Expressions;

namespace BravosBank.Shared.EventSourcing.Persistance.Repositories.Interfaces
{
    public interface IMongoRepository<TDocument> :ISession where TDocument : IDocument
    {
        IQueryable<TDocument> AsQueryable();
        Task InsertOneAsync(TDocument document, IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken);
        Task<IEnumerable<TDocument>> FilterByAsync(Expression<Func<TDocument,bool>> filterExpression, CancellationToken cancellationToken);
    }
}
