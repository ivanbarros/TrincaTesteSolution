namespace TrincaTeste.Domain.Interfaces.Services.BaseService
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> GetByName(string Name);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task DeleteById(Guid Id);
    }
}
