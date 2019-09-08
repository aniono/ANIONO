using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ANIONO.DddCommon.DddApplicationCore.SeedWork;

namespace ANIONO.DddCommon.DddApplicationCore.Interfaces
{
    public interface IAsyncRepository<TEntity, TId>
        where TEntity : Entity<TId>, IAggregateRoot
        where TId : IEquatable<TId>
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TEntity> GetAsync(TId id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec);
        Task<int> CountAsync(ISpecification<TEntity> spec);

        Task<TEntity> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteAsync(TId id);
    }
}
