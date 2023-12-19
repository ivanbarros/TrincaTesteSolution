using Microsoft.Extensions.Logging;
using Trinca.Infra.Services.Base;
using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Repoisitories.BaseRepository;
using Trinca.Domain.Interfaces.Services;

namespace Trinca.Infra.Services
{
    public class TaskService : BaseService<TaskEntity>, ITaskService
    {
        public TaskService(ILogger<TaskEntity> logger, IBaseRepository<TaskEntity> repository) : base(logger, repository)
        {
        }
    }
}
