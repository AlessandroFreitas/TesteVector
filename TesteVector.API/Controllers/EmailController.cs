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
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Route("GetEmails")]
        [HttpGet]
        public async Task<IActionResult> GetEmails()
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

        [Route("GetEmailsByHour")]
        [HttpGet]
        public async Task<IActionResult> GetEmailsByHour()
        {
            try
            {
                var response = await _emailService.GetEmailsByHour();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
