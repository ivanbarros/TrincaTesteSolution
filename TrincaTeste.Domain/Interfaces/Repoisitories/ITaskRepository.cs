using TrincaTeste.Domain.Entities;
using TrincaTeste.Domain.Interfaces.Repoisitories.BaseRepository;

namespace TrincaTeste.Domain.Interfaces.Repoisitories
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
    }
}
