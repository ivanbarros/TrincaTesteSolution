using TrincaTeste.Domain.Entities.Base;

namespace TrincaTeste.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid IdUser { get; set; }

    }
}
