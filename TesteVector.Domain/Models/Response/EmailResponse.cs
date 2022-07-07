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
        public string Mail { get; set; }

        public EmailResponse(string mail)
        {
            Mail = mail;
        }
    }
}
