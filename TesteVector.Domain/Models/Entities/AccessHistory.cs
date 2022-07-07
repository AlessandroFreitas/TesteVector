using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteVector.Domain.Models.Entities
{
    public class AccessHistory
    {
        public int Id { get; set; }
        public DateTime AccessDate { get; set; }
        public List<Email>? Emails { get; set; }
    }
}
