using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVector.Domain.Models.Entities;

namespace TesteVector.Domain.Interfaces.Services
{
    public interface IAccessHistoryService
    {
        void AddAccessHistory(List<Email> emailList);
    }
}
