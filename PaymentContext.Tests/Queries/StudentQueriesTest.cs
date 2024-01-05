using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class SudentQueriesTests
  {
    private IList<Student> _students;
    public SudentQueriesTests()
    {
      _students = new List<Student>();
      for (var i = 0; i <= 10; i++)
      {
        _students.Add(new Student(
          new Name("Aluno", i.ToString()),
          new Document("1111111111" + i.ToString(), EDocumentType.CPF),
          new Email(i.ToString() + "@test.com")
        ));
      }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      var exp = StudentQueries.GetStudentInfo("12345678911");
      var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreEqual(null, studn);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
      var exp = StudentQueries.GetStudentInfo("11111111111");
      var student = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreNotEqual(null, student);
    }
  }
}