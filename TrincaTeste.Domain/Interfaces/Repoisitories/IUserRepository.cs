using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Repoisitories.BaseRepository;

namespace Trinca.Domain.Interfaces.Repoisitories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email, string password);
    }
}
