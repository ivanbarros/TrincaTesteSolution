using TrincaTeste.Domain.Entities.Base;

namespace TrincaTeste.Domain.Entities
{
    public class EventEntity : BaseEntity
    {
        public DateTime EventDate { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTask { get; set;}

    }
}
