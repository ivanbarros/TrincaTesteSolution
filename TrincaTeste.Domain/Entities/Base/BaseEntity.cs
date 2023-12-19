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
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        
        [JsonPropertyName("updateAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        [JsonPropertyName("deleteAt")]
        public DateTime DeletedAt { get; set; } = DateTime.Now;
    }
}
