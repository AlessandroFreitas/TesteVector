using Newtonsoft.Json;

namespace TesteVector.Domain.Models.Entities
{
    public class Email
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("id")]
        public string? IdRequest { get; set; }

        [JsonProperty("mail")]
        public string? Mail { get; set; }

        [JsonProperty("avatar")]
        public string? Avatar { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonIgnore]
        public AccessHistory AccessHistory { get; set; }
    }
}
