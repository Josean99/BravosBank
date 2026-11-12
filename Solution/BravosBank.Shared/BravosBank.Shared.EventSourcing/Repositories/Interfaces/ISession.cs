using MongoDB.Driver;

namespace BravosBank.Shared.EventSourcing.Persistance.Repositories.Interfaces
{
    public interface ISession
    {
        Task<IClientSessionHandle> BeginSessionAsync(CancellationToken cancellationToken);
        void BeginTransaction(IClientSessionHandle clientSessionHandle);
        Task CommitTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken);
        Task RollBackTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken);
        void DisposeSession(IClientSessionHandle clientSessionHandle);
    }
}
