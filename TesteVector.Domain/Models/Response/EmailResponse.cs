using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteVector.Domain.Models.Response
{

    public class EmailResponse
    {
        [JsonProperty("emails")]
        public List<string> Mails { get; set; }

        public EmailResponse(List<string> mails)
        {
            Mails = mails;
        }
    }
}
