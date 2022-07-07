using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TesteVector.Domain.Models.Entities;
using TesteVector.Domain.Models.Response;
using TesteVector.Infra.Data.Context;

namespace TesteVector.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        private readonly TesteVectorContext _context;
        public EmailController(TesteVectorContext context)
        {
            _context = context;
        }

        [Route("GetEmails")]
        [HttpGet]
        public async Task<IActionResult> GetEmails()
        {
            try
            {
                var result = _context.AccessHistories.Include("Emails").FirstOrDefault(x => x.AccessDate.Date == DateTime.Today);
                if (result != null)
                {
                    JObject obj = new JObject();
                    obj["emails"] = new JArray(result.Emails.Select(x => x.Mail));
                    return Ok(obj.ToString());
                }
                else
                {
                    var uri = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
                    using (var httpClient = new HttpClient { BaseAddress = uri })
                    {
                        HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
                        var dados = await response.Content.ReadAsStringAsync();

                        var emailResponse = JsonConvert.DeserializeObject<List<Email>>(dados)?.Select(x => x.Mail).ToArray();
                        JObject obj = new JObject();
                        obj["emails"] = new JArray(emailResponse);

                        return Ok(obj.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetEmailsByHour")]
        [HttpGet]
        public async Task<IActionResult> GetEmailsByHour()
        {
            try
            {
                var uri = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
                using (var httpClient = new HttpClient { BaseAddress = uri })
                {
                    HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
                    var dados = await response.Content.ReadAsStringAsync();

                    var emailResponse = JsonConvert.DeserializeObject<List<Email>>(dados);

                    var groupedResult = emailResponse.GroupBy(x => x.CreatedAt.Value.Hour)
                        .Select(y => new
                        {
                            hour = y.Key,
                            names = y.Select(x => x.Name)
                        })
                        .OrderBy(z => z.hour)
                        .ToList();

                    //JObject obj = new JObject();
                    //obj["emails"] = new JArray(emailResponse);

                    return Ok(groupedResult);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
