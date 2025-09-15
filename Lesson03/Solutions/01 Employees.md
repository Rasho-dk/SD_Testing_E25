5### Employees

**Part I**

Create an Employee class for employees of an online shop with the following `private` attributes:
- CPR. 10 numeric digits
  - Partitions: 
    - Valid: value == 10 digits
    - InValid: value < 10 digits, value > 10 digits
  - Boundary value: 9, 10, 11
  - Edge case: 
    - Empty, Null, whiteSpace
- First name. A minimum of 1 and a maximum of 30 characters. The characters can be alphabetic, spaces or a dash
  - Partitions:
    - Valid: value > 1 and value < 30 characters
    - InValid: value < 1, value > 30 characters
  - Boundary value: 
    - 0 char, 1 char, 2 char, 29 char, 30 char, 31 char
  - Edge case:
    - Null
    - whiteSpace/Empty
- Last name. A minimum of 1 and a maximum of 30 characters. The characters can be alphabetic, spaces or a dash
    - Partitions:
        - Valid: value > 1 and value < 30 characters
        - InValid: value < 1, value > 30 characters
    - Boundary value:
        - 0 char, 1 char, 2 char, 29 char, 30 char, 31 char
    - Edge case:
        - negatives: -1, -20, -30
        - 0 : 0
        - Null
        - whiteSpace/Empty
- Department. One among the following: HR, Finance, IT, Sales, General Services
    - Partitions:
        - Valid: HR, Finance, IT, Sales, General Services
        - InValid: value != HR, Finance, IT, Sales, General Services
    - Boundary value:
        - HR, Finance, IT, Sales, General Services
    - Edge case:
        - negatives: -1, -20, 6, 100
- Base salary. In Danish kroner. A minimum of 20000 and a maximum of 100000
  - Partitions 
    - Valid :  20000, 20001, 99999,100000
    - InValid : value < 20000, value > 100000
  - Boundary value : 
    - 19999.99, 20000, 20001, 99999,100000, 100000.01
  - Edge case : 
    - negatives : -1, -20000, -99999
    - 0 : 0
- Educational level. One among the following: 0 (none), 1 (primary), 2 (secondary), 3 (tertiary)
  - Partitions:
    - Valid: 0, 1, 2, 3
    - InValid: value != 0, 1, 2, 3
  - Boundary value:
    - 0, 1, 2, 3
  - Edge case:
    - negatives: -1, -20, -30
- Date of birth. dd/MM/yyyy. At least 18 years from the present day
  - Paritions:
    - Valid: value > 18 years from the present day
    - InValid: value < 18 years from the present day
  - Boundary value:
    - 18 years from the present day
  - Edge case: 
    - 31-12-2008 less than 18 
    - 01-01-2026 future date
    - 31-01-1908 before 1909
- Date of employment. dd/MM/yyyy. Equal or lower than the present day
- Country. Country name as a string

Write individual getter and setter methods for all private attributes.

The getter for the educational level will return the name of said level.

Write a `getSalary()` method that calculates and returns the actual salary based on the following formula:
- Actual salary = base salary + (educational level * 1220)

Employees can purchase company products with a discount.

Write a `getDiscount()` method that calculates and returns said discount based on the following formula:
- Discount = years of employment * 0,5

- discount cases for complete full year employment:

| Today      | DateOfEmployment | years | today.AddYears(-years) | DateOfEmployment > today.AddYears(-years)? | Final years |
|------------|------------------|-------|------------------------|--------------------------------------------|-------------|
| 2025-09-12 | 2020-12-01       | 5     | 2020-09-12             | Yes                                        | 4           |
| 2025-09-12 | 2020-08-01       | 5     | 2020-09-12             | No                                         | 5           |
  
Write a `getShippingCosts()` method that calculates and returns the shipping cost `percentage`, taking into account that employees from Denmark, Norway and Sweden do not pay shipping costs, employees from Iceland and Finland pay 50%, and employees from other countries pay 100%.

**Part II**

Write unit tests for the class.

Design a comprehensive set of test cases.

Use data providers when relevant.


