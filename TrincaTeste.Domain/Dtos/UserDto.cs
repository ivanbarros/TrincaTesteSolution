using System.Text.Json.Serialization;

namespace Trinca.Domain.Dtos
{
    public class UserDto
    {
        public DateTime DtBirth { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

        [JsonPropertyName("createAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updateAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("deleteAt")]
        public DateTime? DeletedAt { get; set; }
    }
}
