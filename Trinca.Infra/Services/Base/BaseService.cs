using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using TrincaTeste.Domain.Entities.Base;
using TrincaTeste.Domain.Interfaces.Repoisitories.BaseRepository;
using TrincaTeste.Domain.Interfaces.Services.BaseService;

namespace Trinca.Infra.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly ILogger<TEntity> _logger;
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(ILogger<TEntity> logger, IBaseRepository<TEntity> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task DeleteById(Guid Id)
        {
            await _repository.Delete(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var query = _repository.GetDbSet().AsQueryable();
                _logger.LogInformation("Sucesso na requisição Get");
                return query.ToList();
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Falha na requisição Get");
                throw;
            }
        }

        public async Task<TEntity> GetById(Guid Id)
        {
            try
            {
                var query = await _repository.GetByIdAsync(Id);
                _logger.LogInformation("Sucesso na requisição GetById");
                return query;
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Falha na requisição GetById");
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetByName(string Name)
        {
            try
            {
                var query = _repository.GetDbSet().Where(c => c.Name.Equals(Name)).AsQueryable();
                _logger.LogInformation("Sucesso na requisição GetByName");
                return query.OrderBy(c => c.Name);
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Falha na requisição GetByName");
                throw;
            }
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            try
            {
                await _repository.Insert(entity);
                _logger.LogInformation("Sucesso na requisição Insert");
                return entity;
            }
            catch (CosmosException ex)
            {

                _logger.LogError(ex, "Falha na requisição Insert");
                throw;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                await _repository.Update(entity);
                _logger.LogInformation("Sucesso na requisição Update");
                return entity;
            }
            catch (CosmosException ex)
            {

                _logger.LogError(ex, "Falha na requisição Update");
                throw;
            }
        }
    }
}
