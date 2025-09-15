using EShop;
using System.Globalization;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        private Employees _employee;
        private IEShop _eShop;
        [SetUp]
        public void Setup()
        {
            _employee = new Employees();
            _eShop = new EmployeesService(_employee);
        }
        #region DateOfBirth Tests
        [TestCase("31-12-2008")] // Partition value less than 18 years old - upper boundary
        [TestCase("01-01-2026")] // Edge case, future date
        [TestCase("31-01-1908")] // Edge case, before 1909
        public void TestDataOfBirthThrowException(string? inputData)
        {
            //Arrange
            var dt = DateOnly.Parse(inputData!);
            var ex = Assert.Throws<ArgumentException>(() => _employee.BirthDate = dt);
            //Assert
            Assert.That(
                ex.Message,
                Does.Contain("Employee must be at least 18 years old.")
                .Or
                .Contain($"Invalid birth date can't be in the future or before {DateOnly.FromDateTime(DateTime.Now).Year}")
                .Or
                .Contain($"Invalid birth date can't be in the future or before {dt.Year}")
            );
        }
        [Test, TestCaseSource(nameof(BoundaryDateOfBirthTestCase))] // Boundary value, exactly 18 years ago from current date
        [TestCase("13/09/2006", "13/09/2006")] // Partition value 18 years - upper boundary.  19 years old
        public void TestDateOfBirth(string inputDate, string expectedValue)
        {
            //Arrange
            var dob = DateOnly.Parse(inputDate);
            //Act
            _employee.BirthDate = dob;
            //Assert
            Assert.That(_employee.BirthDateFormatted, Is.EqualTo(expectedValue));
        }
        //Helper for boundary value, exactly 18 years ago from current date
        private static IEnumerable<TestCaseData> BoundaryDateOfBirthTestCase()
        {
            var boundaryData = DateOnly.FromDateTime(DateTime.Today.AddYears(-18)); // subtract 18 years from today's date
            var formattedDate = boundaryData.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            yield return new TestCaseData(formattedDate, formattedDate);
        }
        #endregion
        //TODO Write Unit Tests for EducationLevel Property
        #region Salary Tests

        [TestCase(19999.99)] // Partition value 20000 - 100000 lower boundary
        [TestCase(100000.01)] // Partition value 20000 - 100000 upper boundary
        //Edge cases
        [TestCase(0)]
        [TestCase(-20000)]
        [TestCase(-99999)]
        public void TestSalary_ArgumentOutOfRangeException(decimal salary)
        {
            //Arrange && Act
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _employee.Salary = salary);
            Assert.That(ex.Message, Does.Contain("Salary must be between 20,000 kr and 100,000kr."));
        }
        [TestCase(20000.00)] // Partition value 20000 - 100000 lower boundary
        [TestCase(20001.00)]
        [TestCase(50000.00)]
        [TestCase(99999.00)]
        [TestCase(100000.00)] // Partition value 20000 - 100000 upper boundary
        public void TestSalary_ValidValues(decimal salary)
        {
            //Arrange && Act
            _employee.Salary = salary;
            //Assert
            Assert.That(_employee.Salary, Is.EqualTo(salary));
        }
        #endregion
        #region Test GetSalary
        //TODO Write Unit Tests throw ArgumentOutOfRangeException for GetSalary method
        [TestCase(20000.00, EducationLevel.Tertiary, 23660.00)] // Partition value 20000 - 100000 lower boundary
        [TestCase(20001.00, EducationLevel.Primary, 21221.00)]
        [TestCase(99999, EducationLevel.Secondary, 102439.00)]
        [TestCase(100000, EducationLevel.None, 100000)] // Partition value 20000 - 100000 upper boundary
        public void TestGetSalary(decimal salary, EducationLevel level, decimal expectedValue)
        {
            //arrange
            _employee.Salary = salary;
            _employee.EducationLevel = level.ToString();
            //act
            var result = _eShop.GetSalary();
            //assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
        #endregion
        //TODO Write Unit Tests for EducationLevel Property
        #region Test Department Property
        [TestCase((Department)(-1))]
        [TestCase((Department)(-20))]
        [TestCase((Department)6)]
        [TestCase((Department)100)]
        public void TestEducationLevel_ThrowsArgumentException(Department level)
        {
            //Arrange && Act
            var ex = Assert.Throws<ArgumentException>(() => _employee.Department = level.ToString());
            //Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid department."));
        }
        [TestCase(Department.Finance, "Finance")]
        [TestCase(Department.HR, "HR")]
        [TestCase(Department.IT, "IT")]
        [TestCase(Department.Sales, "Sales")]
        [TestCase(Department.GeneralServices, "GeneralServices")]
        public void TestDepartment_ValidEnum(Department department, string expectedValue)
        {
            //Arrange && Act
            _employee.Department = department.ToString();
            //Assert
            Assert.That(_employee.Department, Is.EqualTo(expectedValue));
        }
        #endregion
        //TODO LastName Unit Tests
        #region Test FirstName Property
        [TestCase(null)] // Edge cases
        [TestCase("")] // Edge cases
        [TestCase(" ")] // Edge cases
        [TestCase("Nathaniel Alexander-James Smith")] // Partition value mimi 1 - max 30 characters - upper boundary
        [TestCase("Nathaniel Alexander#James Smith")]
        [TestCase("Nathaniel Alexander@James Smith")]
        public void TestFirstNameThrowException(string? firstName)
        {
            //Arrange && Act
            var ex = Assert.Throws<ArgumentException>(() => _employee.FirstName = firstName!);
            //Assert
            Assert.That(
                ex.Message,
                Does.Contain("First name cannot be empty.")
                    .Or
                    .Contain("First name can only contain alphabetic characters, spaces, or dashes.")
                    .Or
                    .Contain("First name must be between 1 and 30 characters long.")
            );

        }
        [TestCase("B", "B")] // Partition value mimi 1 - max 30 characters - lower boundary
        [TestCase("Bo", "Bo")]
        [TestCase("Maximiliano-Alexander-James", "Maximiliano-Alexander-James")]
        [TestCase("Nathaniel AlexanderJames Smith", "Nathaniel AlexanderJames Smith")] // Partition value mimi 1 - max 30 characters - upper boundary
        public void TestFirstName_ValidNames(string name, string expectedValue)
        {
            //Arrange && Act
            _employee.FirstName = name;
            //Assert
            Assert.That(_employee.FirstName, Is.EqualTo(expectedValue));
        }
        #endregion
        #region CPR Tests
        [TestCase("1234567890", "1234567890")] // Partition value 10 characters - upper boundary
        public void TestCpr10NumericDigits(string cpr, string expectedValue)
        {
            //Arrange && Act
            _employee.Cpr = cpr;
            //Assert
            Assert.That(_employee.Cpr, Is.EqualTo(expectedValue));
        }
        //Edge cases
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("123456789")] // Partition value 10 characters - lower boundary
        [TestCase("12345678901")] // Partition value 10 characters - upper boundary
        //Edge cases
        [TestCase("1234W678a0")] // non-numeric
        [TestCase("12!34-#567")] // non-numeric
        public void TestCpr10NumericDigits_ThrowsArgumentException(string? cpr)
        {
            //Arrange && Act
            var ex = Assert.Throws<ArgumentException>(() => _employee.Cpr = cpr!);
            //Assert
            Assert.That(
                ex.Message,
                Does.Contain("CPR cannot be empty.").Or.Contain("CPR must be exactly 10 digits.")
            );
        }
        #endregion
    }
}


public enum Department
{
    HR,
    Finance,
    IT,
    Sales,
    GeneralServices
}

public enum EducationLevel
{
    None = 0,
    Primary = 1,
    Secondary = 2,
    Tertiary = 3
}