using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVector.Domain.Interfaces.Repositories;
using TesteVector.Domain.Interfaces.Services;
using TesteVector.Domain.Models.Entities;
using TesteVector.Services;
using Xunit;

namespace TesteVector.Tests.Services
{
    public class EmailServiceTests
    {
        private EmailService emailService;

        public EmailServiceTests()
        {
            emailService = new EmailService(new Mock<IBaseRepository<Email>>().Object, new Mock<IAccessHistoryService>().Object);
        }

        [Fact]
        public void Test_ReturnEmailList()
        {
            //arrange
            var _emailList = new List<Email>();
            _emailList.Add(new Email() { Id = 1, Mail = "test1@test.com" });
            _emailList.Add(new Email() { Id = 2, Mail = "test2@test.com" });
            _emailList.Add(new Email() { Id = 3, Mail = "test3@test.com" });

            //act
            var result = emailService.ReturnEmailList(_emailList);

            //assert
            Assert.Equal(3, result.Mails.Count);
        }

        [Fact]
        public void Test_ReturnEmailListGroupedByHour_WithCreatedAt()
        {
            //arrange
            var _emailList = new List<Email>();
            _emailList.Add(new Email() { Id = 1, Mail = "test1@test.com", Name = "test1", CreatedAt = new DateTime(2022, 06, 29, 19, 00, 00) });
            _emailList.Add(new Email() { Id = 2, Mail = "test2@test.com", Name = "test2", CreatedAt = new DateTime(2022, 06, 29, 20, 00, 00) });
            _emailList.Add(new Email() { Id = 3, Mail = "test3@test.com", Name = "test3", CreatedAt = new DateTime(2022, 06, 29, 21, 00, 00) });
            _emailList.Add(new Email() { Id = 4, Mail = "test4@test.com", Name = "test4", CreatedAt = new DateTime(2022, 06, 30, 21, 00, 00) });
            _emailList.Add(new Email() { Id = 5, Mail = "test5@test.com", Name = "test5", CreatedAt = new DateTime(2022, 06, 30, 21, 00, 00) });

            //act
            var result = emailService.ReturnEmailListGroupedByHour(_emailList);

            //assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Test_ReturnEmailListGroupedByHour_WithoutCreatedAt()
        {
            //arrange
            var _emailList = new List<Email>();
            _emailList.Add(new Email() { Id = 1, Mail = "test1@test.com", Name = "test1" });
            _emailList.Add(new Email() { Id = 2, Mail = "test2@test.com", Name = "test2" });
            _emailList.Add(new Email() { Id = 3, Mail = "test3@test.com", Name = "test3" });

            //act / assert
            var exception = Assert.Throws<Exception>(() => emailService.ReturnEmailListGroupedByHour(_emailList));
            Assert.Equal("Email must have a createdAt value", exception.Message);
        }

    }
}
