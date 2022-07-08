using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVector.Domain.Interfaces.Repositories;
using TesteVector.Domain.Interfaces.Services;
using TesteVector.Domain.Models.Entities;

namespace TesteVector.Services
{
    public class AccessHistoryService : IAccessHistoryService
    {
        private IBaseRepository<AccessHistory> _repositoryAccessHistory;

        public AccessHistoryService(IBaseRepository<AccessHistory> repositoryAccessHistory)
        {
            _repositoryAccessHistory = repositoryAccessHistory;
        }

        public void AddAccessHistory(List<Email> emailList)
        {
            AccessHistory accessHistory = new AccessHistory()
            {
                AccessDate = DateTime.Now,
                Emails = emailList
            };

            _repositoryAccessHistory.Insert(accessHistory);
        }
    }
}
