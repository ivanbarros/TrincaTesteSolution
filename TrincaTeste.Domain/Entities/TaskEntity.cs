using System.Text.Json.Serialization;
using Trinca.Domain.Entities.Base;

namespace Trinca.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime End { get; set; }

        [JsonPropertyName("idUser")]
        public Guid IdUser { get; set; }

    }
}
