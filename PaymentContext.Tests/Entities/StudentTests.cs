using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTest
  {
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Student _student;

    public StudentTest()
    {
      _name = new Name("Bruce", "Wayne");
      _document = new Document("59535921088", Domain.Enums.EDocumentType.CPF);
      _email = new Email("batman@dc.com");
      _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SC", "BR", "88350000");
      _student = new Student(_name, _document, _email);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      var subscription = new Subscription(null);
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
      subscription.AddPayment(payment);
      _student.AddSubscription(subscription);
      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
      var subscription = new Subscription(null);
      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
      var subscription = new Subscription(null);
      var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
      subscription.AddPayment(payment);
      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Valid);
    }
  }
}