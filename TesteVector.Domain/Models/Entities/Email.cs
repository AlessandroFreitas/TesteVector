using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteVector.Domain.Models.Entities
{
    public class Email
    {
        public string Id { get; set; }
        public string? Mail { get; set; }
        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        [JsonIgnore]
        public AccessHistory AccessHistory { get; set; }
    }
}
