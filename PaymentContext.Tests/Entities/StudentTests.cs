using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTest
  {
    [TestMethod]
    public void TestMethod()
    {
      var subscription = new Subscription(null);
      var student = new Student("Victor", "Schlindwein", "12345678912", "victorwilbert@gmail.com");
      student.AddSubscription(subscription);
    }
  }
}