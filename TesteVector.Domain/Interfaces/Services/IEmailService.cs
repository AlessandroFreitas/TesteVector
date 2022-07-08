using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVector.Domain.Models.Entities;
using TesteVector.Domain.Models.Response;

namespace TesteVector.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task<EmailResponse> GetEmails();
        Task<List<GroupedEmailResponse>> GetEmailsPerHour();
    }
}
