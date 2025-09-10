using DriverLicense;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        private DriverLicenseChecker _checker;
        private ExamResult _result;

        [SetUp]
        public void Setup()
        {
            _checker = new DriverLicenseChecker();
            _result = new ExamResult();
        }

        [TestCase(85, 0, true, false, false, false)] //lower boundary for passing theory passed 
        [TestCase(92, 1, true, false, false, false)] 
        [TestCase(99, 2, true, false, false, false)]
        [TestCase(100, 2, true, false, false, false)] //upper boundary for passing theory passed
        public void TestPassedDriverLicense(int points, int errors, bool isPassed, bool mustRepeatTheory, 
            bool mustRepeatPractical, bool isAdditionalLessonsRequired)
        {
            _result = DriverLicenseChecker.CheckDriverLicense(points, errors);
            Assert.Multiple(() =>
            {
                Assert.That(_result.IsPassed, Is.EqualTo(isPassed));
                Assert.That(_result.MustRepeatTheory, Is.EqualTo(mustRepeatTheory));
                Assert.That(_result.MustRepeatPractical, Is.EqualTo(mustRepeatPractical));
                Assert.That(_result.IsAdditionalLessonsRequired, Is.EqualTo(isAdditionalLessonsRequired));
            });
        }

        [TestCase(85, 3, false, false, true, false)] 
        [TestCase(92, 10, false, false, true, false)]
        [TestCase(100, 100, false, false, true, false)]
        public void TestNotPassedPracticalExam(int points, int errors, bool isPassed, bool mustRepeatTheory,
            bool mustRepeatPractical, bool isAdditionalLessonsRequired)
        {
            _result = DriverLicenseChecker.CheckDriverLicense(points, errors);
            Assert.Multiple(() =>
            {
                Assert.That(_result.IsPassed, Is.EqualTo(isPassed));
                Assert.That(_result.MustRepeatTheory, Is.EqualTo(mustRepeatTheory));
                Assert.That(_result.MustRepeatPractical, Is.EqualTo(mustRepeatPractical));
                Assert.That(_result.IsAdditionalLessonsRequired, Is.EqualTo(isAdditionalLessonsRequired));
            });
        }

        [TestCase(84, 0, false, true, false, false)]
        [TestCase(42, 1, false, true, false, false)]
        [TestCase(0, 2, false, true, false, false)]
        public void TestNotPassedTheoryExam(int points, int errors, bool isPassed, bool mustRepeatTheory,
            bool mustRepeatPractical, bool isAdditionalLessonsRequired)
        {
            _result = DriverLicenseChecker.CheckDriverLicense(points, errors);
            Assert.Multiple(() =>
            {
                Assert.That(_result.IsPassed, Is.EqualTo(isPassed));
                Assert.That(_result.MustRepeatTheory, Is.EqualTo(mustRepeatTheory));
                Assert.That(_result.MustRepeatPractical, Is.EqualTo(mustRepeatPractical));
                Assert.That(_result.IsAdditionalLessonsRequired, Is.EqualTo(isAdditionalLessonsRequired));
            });
        }

        [TestCase(84, 3, false, true, true, true)]
        [TestCase(42, 10, false, true, true, true)]
        [TestCase(0, 100, false, true, true, true)]
        public void TestNotPassedBothExams(int points, int errors, bool isPassed, bool mustRepeatTheory,
            bool mustRepeatPractical, bool isAdditionalLessonsRequired)
        {
            _result = DriverLicenseChecker.CheckDriverLicense(points, errors);
            Assert.Multiple(() =>
            {
                Assert.That(_result.IsPassed, Is.EqualTo(isPassed));
                Assert.That(_result.MustRepeatTheory, Is.EqualTo(mustRepeatTheory));
                Assert.That(_result.MustRepeatPractical, Is.EqualTo(mustRepeatPractical));
                Assert.That(_result.IsAdditionalLessonsRequired, Is.EqualTo(isAdditionalLessonsRequired));
            });
        }

        //Edge cases
        [TestCase(-10, -5, typeof(ArgumentOutOfRangeException))]
        [TestCase(1000, 1000, typeof(ArgumentOutOfRangeException))]

        //Test for just out of boundary values for both parameters
        [TestCase(-1, -1, typeof(ArgumentOutOfRangeException))]
        [TestCase(101, 200, typeof(ArgumentOutOfRangeException))]
        public void TestInvalidInput(int points, int errors, Type exceptionType)
        {
            var ex = Assert.Throws(exceptionType, () => DriverLicenseChecker.CheckDriverLicense(points, errors));
            Assert.That(ex, Is.TypeOf(exceptionType));

        }
    }
}
