﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Trinca.Domain.Entities.Base;

namespace Trinca.Domain.Interfaces.Repoisitories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> GetDbSet();
        Task BulkInsert(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetMany(
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            CancellationToken cancellationToken = default);

        Task<TEntity?> GetByIdAsync(
            Guid id,
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            CancellationToken cancellationToken = default);

        Task<TEntity?> GetFirstAsync(
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            CancellationToken cancellationToken = default, bool IgnoreRemovedItens = true);

        Task<int> CountAsync(
            Expression<Func<TEntity, bool>>? where = null,
            CancellationToken cancellationToken = default);

        Task<IList<TEntity>> GetPagedAsync(
            int skip,
            int take,
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            CancellationToken cancellationToken = default);
        Task<TEntity> FindByLogin(string email, string password);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? where = null, CancellationToken cancellationToken = default);

        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);

        Task<bool> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);

        Task<bool> Delete(TEntity entity, CancellationToken cancellationToken = default);

        Task<bool> Delete(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<bool> ForceDeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> ForceDeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<bool> ForceDeleteAsync(IEnumerable<TEntity> entities, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
