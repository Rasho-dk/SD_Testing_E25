### Bank account
Suppose you have a bank account that offers variable interest rates:

- 0.5 per cent for the first 10000 kr credit
- 1 per cent for the next 10000 kr
- 1.5 per cent for the rest

If you wanted to check that the bank was handling your account correctly: 
1. What input partitions might you use?
2. What test case values could be inferred from said partitions?

<sub>Adapted from Hambling, Brian (2019). *Software Testing: An ISTQB-BCS Certified Tester Foundation Guide*, 4th ed.</sub>

#### Solution

|Partition type|Partition|Test case values|
|-|--:|--:|
|Valid|0.01 kr - 10000 kr|5000 kr|
|Valid|10000.01 kr - 20000 kr|15000 kr|
|Valid|20000.01 kr - MAX DOUBLE|30000 kr|
|Invalid|MIN DOUBLE - -0.01|-5000 kr|
|Invalid|0|0|
