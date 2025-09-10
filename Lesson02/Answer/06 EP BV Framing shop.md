### Framing shop
The system calculates the price of picture framing based on the given parameters: width and height of the picture (in centimeters). The valid width of the picture is between 30 and 100 cm inclusive. The valid height of the picture is between 30 and 60 cm inclusive. The system calculates the area of the image as the product of width and height. If the surface area exceeds 1600 cm<sup>2</sup>, the framing price is 3500 kr. Otherwise, the framing price is 3000 kr.

Use black-box analysis to identify a comprehensive series of test cases:

1. Identify the corresponding equivalence partitions and propose test cases based on them
2. Use 3-value boundary value analysis to identify further test cases
3. Write down the full resulting list of test case values
4. Implement the discount calculation function in code and write the corresponding unit tests in the language and unit test framework of your choice

<sub>Adapted from Stapp, Lucjan, Roman, Adam, and Michaël Pilaeten (2024). _ISTQB Certified Tester Foundation Level: A Self-Study Guide Syllabus v4.0_. Springer.</sub>

### Solution

1. **Equivalence Partitions:**
   - Valid width: 30 cm to 100 cm (inclusive)
   - Invalid width: < 30 cm, > 100 cm
   - Valid height: 30 cm to 60 cm (inclusive)
   - Invalid height: < 30 cm, > 60 cm
   - Area ≤ 1600 cm²
   - Area > 1600 cm²
   
2. **3-Value Boundary Value Analysis:**
    - Width boundaries: 29 cm (invalid), 30 cm (valid), 31 cm (valid), 99 cm (valid), 100 cm (valid), 101 cm (invalid)
    - Height boundaries: 29 cm (invalid), 30 cm (valid), 31 cm (valid), 59 cm (valid), 60 cm (valid), 61 cm (invalid)
    - Area boundaries for valid dimensions:
      - Minimum area: 30 cm * 30 cm = 900 cm² (valid, price = 3000 kr)
      - Maximum area: 100 cm * 60 cm = 6000 cm² (valid, price = 3500 kr)
      - Area just below threshold: e.g., 40 cm * 40 cm = 1600 cm² (valid, price = 3000 kr)
      - Area just above threshold: e.g., 50 cm * 40 cm = 2000 cm² (valid, price = 3500 kr)

3. **List of Test Cases:**
   - Width test cases: `29`, `30`, `31`, `99`, `100`, `101` 
   - Height test cases: `29`, `30`, `31`, `59`, `60`, `61`
   - Area test cases: `900`,`1599`, `1600`, `1601`, `6000`

  **Test Cases Based on Equivalence Partitions:**
  - Test Case 1: Width = 50 cm, Height = 40 cm (Valid, Area = 2000 cm², Price = 3500 kr)
  - Test Case 2: Width = 30 cm, Height = 30 cm (Valid, Area = 900 cm², Price = 3000 kr)
  - Test Case 3: Width = 100 cm, Height = 60 cm (Valid, Area = 6000 cm², Price = 3500 kr)
  - Test Case 4: Width = 29 cm, Height = 40 cm (Invalid width)
  - Test Case 5: Width = 101 cm, Height = 40 cm (Invalid width)
  - Test Case 6: Width = 50 cm, Height = 29 cm (Invalid height)
  - Test Case 7: Width = 50 cm, Height = 61 cm (Invalid height)
  - Test Case 8: Width = 40 cm, Height = 40 cm (Valid, Area = 1600 cm², Price = 3000 kr)