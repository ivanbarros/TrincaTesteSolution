using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Trinca.Infra.Data;
using TrincaTeste.Domain.Entities.Base;
using TrincaTeste.Domain.Interfaces.Repoisitories.BaseRepository;

namespace Trinca.Infra.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly EFContext _context;

        public DbSet<TEntity> DBSet { get; private set; }

        public BaseRepository(EFContext context)
        {
            _context = context;
            DBSet = context.Set<TEntity>();
        }
        public DbSet<TEntity> GetDbSet() => DBSet;
        public virtual async Task BulkInsert(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await DBSet.AddRangeAsync(entities.Select(c => { c.CreatedAt = DateTime.Now; return c; }));
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async virtual Task<IEnumerable<TEntity>> GetMany(
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            CancellationToken cancellationToken = default)
        {
            var dbSet = AllNotRemoved();

            if (where != null)
                dbSet = dbSet.Where(where);

            if (include != null)
                dbSet = include(dbSet);

            if (orderBy != null)
                dbSet = orderBy(dbSet);

            return await dbSet.ToListAsync(cancellationToken);
        }

        public virtual Task<TEntity?> GetByIdAsync(
            Guid id,
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            CancellationToken cancellationToken = default)
        {
            var dbSet = AllNotRemoved();

            if (where != null)
                dbSet = dbSet.Where(where);

            if (include != null)
                dbSet = include(dbSet);

            return dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public virtual Task<TEntity?> GetFirstAsync(
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            CancellationToken cancellationToken = default, bool ignoreRemovedItens = true)
        {
            var dbSet = ignoreRemovedItens ? AllNotRemoved() : DBSet;
            if (where != null)
                dbSet = dbSet.Where(where);

            if (include != null)
                dbSet = include(dbSet);

            return dbSet.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual Task<int> CountAsync(
            Expression<Func<TEntity, bool>>? where = null,
            CancellationToken cancellationToken = default)
        {
            var dbSet = AllNotRemoved();

            if (where != null)
                dbSet = dbSet.Where(where);

            return dbSet.CountAsync(cancellationToken);
        }

        public virtual async Task<IList<TEntity>> GetPagedAsync(
            int skip,
            int take,
            Expression<Func<TEntity, bool>>? where = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            CancellationToken cancellationToken = default)
        {
            var dbSet = AllNotRemoved();

            if (where != null)
                dbSet = dbSet.Where(where);

            if (include != null)
                dbSet = include(dbSet);

            if (orderBy != null)
                dbSet = orderBy(dbSet);

            var a = dbSet.Skip(skip).Take(take);
            var str = a.ToQueryString();

            return await a.ToListAsync(cancellationToken);
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? where = null, CancellationToken cancellationToken = default)
        {
            var dbSet = DBSet.AsQueryable();

            if (where != null)
                dbSet = dbSet.Where(where);

            return dbSet.AnyAsync(cancellationToken);
        }

        public virtual async Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedAt = DateTime.Now;

            DBSet.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
                entity.CreatedAt = DateTime.Now;

            DBSet.AddRange(entities);

            await _context.SaveChangesAsync(cancellationToken);

            return entities;
        }

        public virtual async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedAt = DateTime.Now;

            DBSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<bool> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
                entity.UpdatedAt = DateTime.Now;

            DBSet.UpdateRange(entities);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public virtual async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken: cancellationToken);
            if (entity == null)
                return false;

            return await Delete(entity, cancellationToken);
        }

        public virtual async Task<bool> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.DeletedAt = DateTime.Now;

            DBSet.Update(entity);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public virtual async Task<bool> Delete(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                entity.DeletedAt = DateTime.Now;
            }

            DBSet.UpdateRange(entities);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public virtual async Task<bool> ForceDeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken: cancellationToken);
            if (entity == null)
                return false;

            return await ForceDeleteAsync(entity, cancellationToken);
        }

        public virtual async Task<bool> ForceDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DBSet.Remove(entity);

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public virtual async Task<bool> ForceDeleteAsync(IEnumerable<TEntity> entities, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            DBSet.RemoveRange(entities);

            if (saveChanges)
                return (await _context.SaveChangesAsync(cancellationToken)) > 0;

            return true;
        }

        private IQueryable<TEntity> AllNotRemoved() => DBSet.Where(x => x.DeletedAt == null);
    }
}

