using Microsoft.Extensions.Logging;
using Trinca.Infra.Services.Base;
using TrincaTeste.Domain.Entities;
using TrincaTeste.Domain.Interfaces.Repoisitories.BaseRepository;
using TrincaTeste.Domain.Interfaces.Services;

namespace Trinca.Infra.Services
{
    public class TaskService : BaseService<TaskEntity>, ITaskService
    {
        public TaskService(ILogger<TaskEntity> logger, IBaseRepository<TaskEntity> repository) : base(logger, repository)
        {
        }
    }
}
