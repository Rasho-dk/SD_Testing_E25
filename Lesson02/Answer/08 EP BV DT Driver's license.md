### Driver's license
The operator of the driver's license test support system enters the following information into the system, for a candidate who is taking the exams for the first time:
- The number of points from the theoretical exam (integer number from 0 to 100)
- The number of errors made by the candidate during the practical exam (integer number 0 or greater)
The candidate must take both exams. `**_A candidate is granted a driver's license if they meet the following two conditions_**`:
  - they scored at least 85 points on the theoretical test and made no more than two errors on the practical test. 
  - If a candidate fails one of the exams, they must repeat this exam. 
  - In addition, if the candidate fails both exams, they are required to take additional hours of driving lessons.

Use black-box analysis to identify a comprehensive series of test cases:
1. Create the corresponding decision table
2. Write test cases based on the decision table
3. Identify the corresponding equivalence partitions
4. Use 3-value boundary value analysis to identify further test cases
5. Identify edge cases
6. List all test case values
7. Implement in code a function that receives as parameters the number of points for the theory exam and the number of errors for the practical exam and that returns a data structure with four boolean properties:
   - whether the driver's license is granted,
   - whether the theory exam must be repeated,
   - whether the practical exam must be repeated,
   - and whether additional driving lessons must be taken.
   - Write the corresponding unit tests based on the above analysis.
   - Use the programming language and unit test framework of your choice

<sub>Adapted from Stapp, Lucjan, Roman, Adam, and Michaël Pilaeten (2024). _ISTQB Certified Tester Foundation Level: A Self-Study Guide Syllabus v4.0_. Springer.</sub>

### Solution

#### 1. Decision table

| Condition                  | TC1   | TC2   | TC3   | TC4   |
|----------------------------|-------|-------|-------|-------|
| Theory exam points >= 85   | T     | T     | F     | F     |
| Practical exam errors <= 2 | T     | F     | T     | F     |
| Action                     | ----- | ----- | ----- | ----- |
| Grant driver's license     | T     | F     | F     | F     |
| Repeat theory exam         | F     | F     | T     | T     |
| Repeat practical exam      | F     | T     | F     | T     |
| Additional driving lessons | F     | F     | F     | T     |

#### 2. Test cases based on the decision table

| Test Case | Theory exam points | Practical exam errors | Grant driver's license | Repeat theory exam | Repeat practical exam | Additional driving lessons |
|-----------|--------------------|-----------------------|------------------------|--------------------|-----------------------|----------------------------|
| TC1       | 85                 | 1                     | **_True_**             | False              | False                 | False                      |
| TC2       | 90                 | 3                     | False                  | False              | **_True_**            | False                      |
| TC3       | 80                 | 2                     | False                  | **_True_**         | False                 | False                      |
| TC4       | 70                 | 5                     | False                  | **_True_**         | **_True_**            | **_True_**                 | 


#### 3. Equivalence partitions

| Partition type | Partition                      | Test case values |
|----------------|--------------------------------|------------------|
| Valid          | Theory exam points: 0 - 84     | 0, 42, 84        |
| Valid          | Theory exam points: 85 - 100   | 85, 92, 100      |
| Valid          | Practical exam errors: 0 - 2   | 0, 1, 2          |
| Valid          | Practical exam errors: 3 - MAX | 3, 10, 100       |

#### 4. Boundary value analysis

| Boundary type | Boundary value             | Test case values |
|---------------|----------------------------|------------------|
| Lower         | Theory exam points: 0      | -1, 0, 1         |
| Upper         | Theory exam points : 100   | 99, 100, 101     |
| Lower         | Practical exam errors: 0   | -1, 0, 1         |
| Upper         | Practical exam errors: MAX | Max integer      |

#### 5. Edge cases

Depending on the programming language and data types used, edge cases may include:
e.g. C# is strongly typed so it won't accept non-integer values, that mean we don't need to test strings, floats, nulls, etc.

| Edge case description                 | Test case values |
|---------------------------------------|------------------|
| Negative theory exam points           | -10              |
| Negative practical exam errors        | -5               |
| Extremely high theory exam points     | 1000             |
| Extremely high practical exam errors  | 1000             |

#### 6. List of all test case values

Listing all unique test case values from the above analyses:

* List of unique test case values:
  - Theory exam points: -10, -1, 0, 1, 42, 84, 85, 92, 99, 100, 101, 1000
  - Practical exam errors: -5, -1, 0, 1, 2, 3, 10, 100, 1000

#### 7. Implementation in code (C# example)...





