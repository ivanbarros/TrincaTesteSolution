using Microsoft.Extensions.Logging;
using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Repoisitories.BaseRepository;
using Trinca.Domain.Interfaces.Services;
using Trinca.Infra.Services.Base;

namespace Trinca.Infra.Services
{
    public class UserSrvice : BaseService<UserEntity>, IUserService
    {
        public UserSrvice(ILogger<UserEntity> logger, IBaseRepository<UserEntity> repository) : base(logger, repository)
        {
        }
    }
}
