using TrincaTeste.Domain.Entities.Base;

namespace TrincaTeste.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public DateTime DtBirth { get; set; }
        public string Document { get; set; }
        public string Login { get; set; }
        public string Pwd { get; set; }
    }
}
