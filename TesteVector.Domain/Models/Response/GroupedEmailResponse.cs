using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteVector.Domain.Models.Response
{
    public class GroupedEmailResponse
    {
        public int hour { get; set; }
        public List<string> names { get; set; }
    }
}
