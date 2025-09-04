### E-shop
You are testing the payment functionality of an e-shop. The system receives a positive amount of purchases in kroner with an accuracy of 1 øre. Based on this value, a discount is calculated according to the following rules:

|Amount|Discount|
|-|--:|
|Up to 300 kr|0%|
|Over 300 kr, up to 800 kr|5%|
|Over 800 kr|10%|

Use black-box analysis to identify a comprehensive series of test cases:
1. Identify the corresponding equivalence partitions and propose test cases based on them
2. Use 3-value boundary value analysis to identify further test cases
3. Write down the full resulting list of test cases
4. Implement the discount calculation function in code and write the corresponding unit tests in the language and unit test framework of your choice

<sub>Adapted from Stapp, Lucjan, Roman, Adam, and Michaël Pilaeten (2024). _ISTQB Certified Tester Foundation Level: A Self-Study Guide Syllabus v4.0_. Springer.</sub>

#### Solution

| **_Partition type_**| **_Partition_**|**_Test case values_**|**_Expected output_**|**_Boundary values_**|**_Test case values_**|
|---------------|---------|------------------|--------------|-------------|------------------|
| **Valid**| `0.01 - 300`| `200.05`|`0%` discount|`0.01` - `300`|`0.00`, `0.01`, `0.02`, `299.99`, `300`, `300.01`|
| **Valid**|`300.01 - 800`| `450.99`|`5%` discount|`300.01` - `800`|`300` ,`300.01`, `300.02` ,`799.99`, `800`, `800.01`|
| **Valid**|`800.01` - `Max integer`|`1000.99`|`10%` discount|`800.01`|`800`, `800.01`, `800.02`|
| **Invalid**|`0`|`0`|error|`0`|`-1`, `0`, `0.01` |
| **Invalid**|`Min integer`- `-0.01`|`-20.45`|error|`-1`|`-0.02`, `-0.01`, `0` |

**List of test cases:**

- `-20.45`, `-0.02`, `-0.01`, `0.00`, `0.01`, `0.02`, `299.99`, `300`, `300.01`, `300.02` ,`799.99`, `800`, `800.01`, `800.02`
