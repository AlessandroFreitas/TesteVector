using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TesteVector.Domain.Interfaces.Repositories;
using TesteVector.Domain.Interfaces.Services;
using TesteVector.Domain.Models.Entities;
using TesteVector.Domain.Models.Response;
using TesteVector.Infra.Data.Context;

namespace TesteVector.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        //private readonly TesteVectorContext _context;
        //public EmailController(TesteVectorContext context)
        //{
        //    _context = context;
        //}

        //private readonly IBaseRepository<AccessHistory> _repositoryAccessHistory;
        //private readonly IBaseRepository<Email> _repositoryEmail;
        //public EmailController(IBaseRepository<AccessHistory> repositoryAccessHistory,
        //    IBaseRepository<Email> repositoryEmail)
        //{
        //    _repositoryAccessHistory = repositoryAccessHistory;
        //    _repositoryEmail = repositoryEmail;
        //}

        //[Route("GetEmails")]
        //[HttpGet]
        //public async Task<IActionResult> GetEmails()
        //{
        //    try
        //    {
        //        //var result = _context.AccessHistories.Include("Emails").FirstOrDefault(x => x.AccessDate.Date == DateTime.Today);
        //        //var emailsDB = _repositoryAccessHistory.Include(x => x.Emails).Where(x=>x.AccessDate == DateTime.Today);
        //        var emailsDB = _repositoryEmail.Include(x => x.AccessHistory).Where(x => x.AccessHistory.AccessDate.Date == DateTime.Today);
        //        if (emailsDB.Count() > 0)
        //        {
        //            JObject obj = new JObject();
        //            obj["emails"] = new JArray(emailsDB.Select(x => x.Mail));
        //            return Ok(obj.ToString());
        //        }
        //        else
        //        {
        //            var uri = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
        //            using (var httpClient = new HttpClient { BaseAddress = uri })
        //            {
        //                HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
        //                var dados = await response.Content.ReadAsStringAsync();

        //                var emailList = JsonConvert.DeserializeObject<List<Email>>(dados);

        //                AccessHistory accessHistory = new AccessHistory()
        //                {
        //                    AccessDate = DateTime.Now,
        //                    Emails = emailList
        //                };

        //                _repositoryAccessHistory.Insert(accessHistory);

        //                var emailResponse = emailList?.Select(x => x.Mail).ToArray();
        //                JObject obj = new JObject();
        //                obj["emails"] = new JArray(emailResponse);

        //                return Ok(obj.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[Route("GetEmailsByHour")]
        //[HttpGet]
        //public async Task<IActionResult> GetEmailsByHour()
        //{
        //    try
        //    {
        //        var uri = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
        //        using (var httpClient = new HttpClient { BaseAddress = uri })
        //        {
        //            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
        //            var dados = await response.Content.ReadAsStringAsync();

        //            var emailResponse = JsonConvert.DeserializeObject<List<Email>>(dados);

        //            var groupedResult = emailResponse.GroupBy(x => x.CreatedAt.Value.Hour)
        //                .Select(y => new
        //                {
        //                    hour = y.Key,
        //                    names = y.Select(x => x.Name)
        //                })
        //                .OrderBy(z => z.hour)
        //                .ToList();

        //            //JObject obj = new JObject();
        //            //obj["emails"] = new JArray(emailResponse);

        //            return Ok(groupedResult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Route("GetEmails2")]
        [HttpGet]
        public async Task<IActionResult> GetEmails2()
        {
            try
            {
                var response = await _emailService.GetEmails();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetEmailsPerHour2")]
        [HttpGet]
        public async Task<IActionResult> GetEmailsPerHour2()
        {
            try
            {
                var response = await _emailService.GetEmailsPerHour();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
