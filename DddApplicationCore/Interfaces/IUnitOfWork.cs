using System;
using System.Threading;
using System.Threading.Tasks;

namespace ANIONO.DddCommon.DddApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}