using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCnpjIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCnpjIsValid()
    {
      var doc = new Document("65484719000190", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Valid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCpfIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CPF);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCpfIsValid()
    {
      var doc = new Document("59535921088", EDocumentType.CPF);
      Assert.IsTrue(doc.Valid);
    }
  }
}