using MeasureConverterLib.Services;

namespace TestMeasureConverterLib.integrationTests
{
    public class GradesTest
    {
        private GradesSQL _gradesSql;
        [SetUp]
        public void Setup()
        {
            _gradesSql = new GradesSQL();
        }

        [Test]
        public async Task TestGetGrades()
        {
            var grades = await GradesSQL.Get();
            Assert.That(grades.Count, Is.GreaterThan(0));

            foreach (var grade in grades)
            {
            }
        }

    }
}
