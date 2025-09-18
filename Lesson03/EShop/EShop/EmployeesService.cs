using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop
{
    public class EmployeesService : IEShop
    {
        #region Constants for Employee class
        private const int YearOfStartBirth = 1909;
        private const decimal Free = 0m;
        private const decimal Half = 0.5m;
        private const decimal Full = 1.0m;
        #endregion

        private readonly Employees _employee;

        public EmployeesService(Employees employee)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public decimal GetShippingCosts()
        {
            var country = _employee.Country?.Trim().ToLower() ?? string.Empty;
            return country switch
            {
                "denmark" or "norway" or "sweden" => Free,
                "iceland" or "finland" => Half,
                _ => Full,
            };

        }
        public decimal GetDiscount()
        {
            return CountYearOfEmployment() * 0.5m; // 5% discount
        }

        private int CountYearOfEmployment()
        {
            var today = DateOnly.FromDateTime(DateTime.Now); // Current date
            var years = today.Year - _employee.DateOfEmployment.Year; // difference in years
            if (_employee.DateOfEmployment > today.AddYears(-years)) years--; // If the hire date hasn't completed this year, subtract one year
            return years;
        }

        public decimal GetSalary()
        {
            _employee.ValidateSalary(_employee.Salary);
            var baseSalary = _employee.Salary;
            return baseSalary + ((int)_employee.GetEducationLevelWithIndexNo() * 1220);
        }
    }
}
