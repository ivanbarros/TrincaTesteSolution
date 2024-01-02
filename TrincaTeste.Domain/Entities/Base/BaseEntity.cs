using System.Text.Json.Serialization;

namespace Trinca.Domain.Entities.Base
{
    public class BaseEntity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("createAt")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("updateAt")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonPropertyName("deleteAt")]
        public DateTime DeletedAt { get; set; }
    }
}
