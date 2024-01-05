using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Document = "99999999999",
                Email = "mail@test.com2",
                BarCode = "123456789",
                BoletoNumber = "11231",
                PaymentNumber = "132132",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "WAYNE CORP",
                PayerDocument = "12345678911",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "batman@dc.com",
                Street = "asdasd",
                Number = "37",
                Neighborhood = "dasd",
                City = "as",
                State = "das",
                Country = "dasd",
                ZipCode = "7465465"
            };

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}