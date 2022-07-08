using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TesteVector.Domain.Interfaces.Repositories;
using TesteVector.Domain.Interfaces.Services;
using TesteVector.Domain.Models.Entities;
using TesteVector.Domain.Models.Response;

namespace TesteVector.Services
{
    public class EmailService : IEmailService
    {
        private IBaseRepository<Email> _baseRepository;
        public EmailService(IBaseRepository<Email> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<EmailResponse> GetEmails()
        {
            var emailsDB = _baseRepository.Include(x => x.AccessHistory).Where(x => x.AccessHistory.AccessDate.Date == DateTime.Today);
            if (emailsDB.Count() > 0)
            {
                return ReturnEmailList(emailsDB.ToList());
            }
            else
            {
                var uri = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
                using (var httpClient = new HttpClient { BaseAddress = uri })
                {
                    HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
                    var dados = await response.Content.ReadAsStringAsync();

                    var emailList = JsonConvert.DeserializeObject<List<Email>>(dados);

                    AddAccessHistory(emailList);

                    EmailResponse result = ReturnEmailList(emailList);
                    return result;
                }
            }
        }

        private void AddAccessHistory(List<Email>? emailList)
        {
            //AccessHistory accessHistory = new AccessHistory()
            //{
            //    AccessDate = DateTime.Now,
            //    Emails = emailList
            //};

            //_repositoryAccessHistory.Insert(accessHistory);
        }



        public async Task<List<GroupedEmailResponse>> GetEmailsPerHour()
        {
            var emailsDB = _baseRepository.Include(x => x.AccessHistory).Where(x => x.AccessHistory.AccessDate.Date == DateTime.Today);
            if (emailsDB.Count() > 0)
            {
                return ReturnGroupedEmailList(emailsDB.ToList());
            }
            else
            {
                var uri = new Uri("https://6064ac2bf09197001778660d.mockapi.io/api/test-api");
                using (var httpClient = new HttpClient { BaseAddress = uri })
                {
                    HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
                    var dados = await response.Content.ReadAsStringAsync();

                    var emailList = JsonConvert.DeserializeObject<List<Email>>(dados);

                    AddAccessHistory(emailList);

                    List<GroupedEmailResponse> result = ReturnGroupedEmailList(emailList);
                    return result;
                }
            }
        }

        private EmailResponse ReturnEmailList(List<Email>? emails)
        {
            var listEmails = new EmailResponse(emails.Select(x => x.Mail).ToList());
            return listEmails;
        }

        private List<GroupedEmailResponse> ReturnGroupedEmailList(List<Email>? emails)
        {
            var groupedResult = emails.GroupBy(x => x.CreatedAt.Value.Hour)
                .Select(y => new GroupedEmailResponse()
                {
                    hour = y.Key,
                    names = y.Select(x => x.Name).ToList(),
                })
                .OrderBy(z => z.hour)
                .ToList();

            return groupedResult;
        }
    }
}
