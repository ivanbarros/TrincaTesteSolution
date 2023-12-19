using Trinca.Infra.Data;
using Trinca.Infra.Repositories.Base;
using Trinca.Domain.Entities;
using Trinca.Domain.Interfaces.Repoisitories;

namespace Trinca.Infra.Repositories
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(EFContext context) : base(context)
        {
        }
    }
}
