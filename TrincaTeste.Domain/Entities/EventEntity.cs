using Trinca.Domain.Entities.Base;

namespace Trinca.Domain.Entities
{
    public class EventEntity : BaseEntity
    {
        public DateTime EventDate { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTask { get; set;}

    }
}
