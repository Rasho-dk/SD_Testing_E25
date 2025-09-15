using System.Globalization;

namespace EShop
{
    public class Employees
    {
        #region Constants for Employee class
        private const int YearOfStartBirth = 1909;
        private const decimal Free = 0m;
        private const decimal Half = 0.5m;
        private const decimal Full = 1.0m;
        #endregion

        #region Fields for Employee
        private string _cpr = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private Department _department;
        private decimal _salary;
        private EducationLevel _educationLevel;
        private DateOnly _birthDate = new(YearOfStartBirth, 1, 1);
        private DateOnly _dateOfEmployment; //= DateOnly.FromDateTime(DateTime.Now);
        public string? Country { get; init; }
        public string BirthDateFormatted => _birthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        #endregion

        #region Properties for Employee class
        public DateOnly DateOfEmployment
        {
            get => _dateOfEmployment;
            init
            {
                CheckDateOfEmployment(value);
                _dateOfEmployment = value;
            }
        }
        public DateOnly BirthDate
        {
            private get => _birthDate;
            set
            {
                CheckDateOfBirth(value);
                _birthDate = value;
            }
        }

        public string EducationLevel
        {
            get => _educationLevel.ToString();
            set
            {
                if (Enum.TryParse(value, out EducationLevel level))
                {
                    _educationLevel = level;
                }
                else
                {
                    throw new ArgumentException("Invalid education level.");
                }
            }
        }
        public decimal Salary
        {
            get => _salary;
            set
            {
                ValidateSalary(value);
                _salary = value;
            }
        }
        public string Department
        {
            get => _department.ToString();
            set
            {
                if (Enum.TryParse(value, out Department dept))
                {
                    ValidateDepartment(dept);
                    _department = dept;
                }
                else
                {
                    throw new ArgumentException("Invalid department.");
                }

            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                ValidateName(value);
                _lastName = value;
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                ValidateName(value);
                _firstName = value;
            }
        }

        public string Cpr
        {
            get => _cpr;
            set
            {
                ValidateCpr(value);
                _cpr = value;
            }
        }
        #endregion

        public EducationLevel GetEducationLevelWithIndexNo()
        {
            return _educationLevel;
        }
        #region Validation Methods
        private static void CheckDateOfEmployment(DateOnly hireDate)
        {
            if (hireDate > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Hire date cannot be in the future.", nameof(hireDate));
            }
        }
        private static void CheckDateOfBirth(DateOnly birthDate)
        {
            if (birthDate.Year < 1909 || birthDate > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException($"Invalid birth date can't be in the future or before {birthDate.Year}", nameof(birthDate));
            }
            var today = DateOnly.FromDateTime(DateTime.Now);
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            if (age < 18)
            {
                throw new ArgumentException("Employee must be at least 18 years old.");
            }
        }
        /* Not used but left for reference
        if (!birthDate.TryFormat(new char[10],
           out _,
           "dd/MM/yyyy",
           CultureInfo.InvariantCulture)
           )
           {
               throw new ArgumentException("Date must be in the format dd/MM/yyyy", nameof(birthDate));
           }
           private static bool IsDateInFormat(string dateFormat)
           {
               return DateOnly.TryParseExact(dateFormat, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
           }
         */


        public void ValidateSalary(decimal salary)
        {
            if (salary is < 20000 or > 100000)
            {
                throw new ArgumentOutOfRangeException(nameof(salary), "Salary must be between 20,000 kr and 100,000kr.");
            }

        }
        private static void ValidateDepartment(Department department)
        {
            if (!Enum.IsDefined(typeof(Department), department))
            {
                throw new ArgumentException("Invalid department.");
            }
        }
        private static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("First name cannot be empty.");
            }
            if (name.Any(c => !char.IsLetter(c) && c != ' ' && c != '-'))
            {
                throw new ArgumentException("First name can only contain alphabetic characters, spaces, or dashes.");
            }
            if (name.Length is < 1 or > 30)
            {
                throw new ArgumentException("First name must be between 1 and 30 characters long.");
            }
        }
        private static void ValidateCpr(string cpr)
        {
            if (string.IsNullOrWhiteSpace(cpr))
            {
                throw new ArgumentException("CPR cannot be empty.");
            }
            if (cpr.Length != 10 || !long.TryParse(cpr, out _))
            {
                throw new ArgumentException("CPR must be exactly 10 digits.");
            }

        }

        #endregion

    }
}

internal enum Department
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