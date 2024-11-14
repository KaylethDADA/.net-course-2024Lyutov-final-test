using FinalTest.Domain.Entities;
using System.Linq.Expressions;

namespace FinalTest.App.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter, int? pageNumber, int? pageSize, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
