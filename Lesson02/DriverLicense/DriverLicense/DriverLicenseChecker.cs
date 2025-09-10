namespace DriverLicense
{
    public class DriverLicenseChecker
    {
        public static ExamResult CheckDriverLicense(int points, int errors)
        {
            if (points is < 0 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(points), "Points must be between 0 and 100.");
            }
            if (errors < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(errors), "Errors cannot be negative.");
            }
            var result = new ExamResult()
            {
                IsPassed = points >= 85 && errors <= 2,
                MustRepeatTheory = points < 85,
                MustRepeatPractical = errors > 2,
                IsAdditionalLessonsRequired = points < 85 && errors > 2
            };
            return result;
        }

    }
}

public record ExamResult
{
    public bool IsPassed { get; set; }
    public bool MustRepeatTheory { get; set; }
    public bool MustRepeatPractical { get; set; }
    public bool IsAdditionalLessonsRequired { get; set; }

}