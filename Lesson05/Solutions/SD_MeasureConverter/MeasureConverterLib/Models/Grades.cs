using MeasureConverterLib.Services;
using System.Text.RegularExpressions;

namespace MeasureConverterLib.Models
{
    public class Grade
    {
        private GradeSystem From { get; set; }
        private GradeSystem To { get; set; }
        public required string Value { get; set; }

        private GradesSQL _gradesSql = new GradesSQL();

        public string Convert(GradeSystem from, GradeSystem to, string value)
        {
            ValidateValue(value);
            ValidateGradeSystem(from);
            ValidateGradeSystem(to);

            From = from;
            To = to;

            //Get the grade from the database
            var grades = GradesSQL.Get().Result;
            if (grades is null || grades.Count == 0)
            {
                throw new Exception("No grades found in the database.");
            }

            switch (From)
            {
                case GradeSystem.Denmark when To == GradeSystem.USA:
                    {
                        var grade = grades.FirstOrDefault(g => g.Denmark == value);
                        return grade is null ? throw new ArgumentException("Grade not found in the database.") : grade.Usa;
                    }
                case GradeSystem.USA when To == GradeSystem.Denmark:
                    {
                        var grade = grades.FirstOrDefault(g => g.Usa == value);
                        return grade is null ? throw new ArgumentException("Grade not found in the database.") : grade.Denmark;
                    }
                default:
                    return string.Empty;
            }
        }

        private static void ValidateGradeSystem(GradeSystem inputGradeSystem)
        {
            if (!Enum.IsDefined(typeof(GradeSystem), inputGradeSystem))
            {
                throw new ArgumentException("Invalid grade system.");
            }
            if (inputGradeSystem != GradeSystem.Denmark && inputGradeSystem != GradeSystem.USA)
            {
                throw new ArgumentException("Grade system must be either Denmark or USA.");
            }

        }


        private static void ValidateValue(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue) || string.IsNullOrWhiteSpace(inputValue))
            {
                throw new ArgumentException("Grade system cannot be null or empty.");
            }

            if (inputValue.All(char.IsLetter))
            {
                if (!Enum.TryParse<GradeValue>(inputValue.Replace("+", "Plus"), out var _))
                {
                    throw new ArgumentException("Invalid grade system.");
                }
                if (inputValue.Length > 2 && !inputValue.Contains('+'))
                {
                    throw new ArgumentException("Grade system must contain '+' if length is greater than 2.");
                }
                if (inputValue.Length > 1)
                {
                    throw new ArgumentException("Grade system must be a single letter or a letter followed by '+'.");
                }
            }
            //TODO: Check this...
            if (inputValue.All(char.IsDigit))
            {
                if (!Enum.TryParse<GradeValueInDanish>($"_{inputValue}", out var _))
                {
                    throw new ArgumentException("Invalid grade system.");
                }
                if (inputValue.Length > 1 && !Regex.IsMatch(inputValue, "^(12|10|02|00|-3)$"))
                {
                    throw new ArgumentException("Grade system must be one of the following: 12, 10, 7, 4, 02, 00, -3.");
                }
            }


        }



    }


}


public enum GradeValue
{
    APlus, // Represents A+
    A,
    B,
    C,
    D,
    F
}
public enum GradeSystem
{
    Denmark,
    USA
}

public enum GradeValueInDanish
{
    _12 = 12,
    _10 = 10,
    _7 = 7,
    _4 = 4,
    _02 = 02,
    _00 = 00,
    _03 = -3,
}