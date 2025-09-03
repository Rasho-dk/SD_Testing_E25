### Password field
A password field accepts a minimum of 6 characters and a maximum of 10 characters. Define:

1. Its corresponding equivalence partitions and test case values
2. The boundary values and resulting test case values with a 3-boundary value approach
3. The final list of test case values

### solution

| Partition type | Partition            | Test cases                | Boundary values | Boundary test cases      |
|----------------|---------------------|-------------------------------|----------------|-------------------------|
| Valid          | 6-10 characters     | "abcdef", "abcdefghij"        | 6, 7, 8, 9, 10          | "abcdef", "abcdefs", "abcdefaw", "abcdefrew",  "abcdefghij"  |
| Invalid        | 1-5 characters      | "a","wr2", "abcde"                  | 5              | "abcde"                 |
| Invalid        | >10 characters      | "abcdefghijk"                 | 11             | "abcdefghijk"           |
| Invalid        | Null                | Null                          | Null           | Null                    |
| Invalid        | Empty or space      | "", " "                       | "", " "        | "", " "                 |

**List of test cases:**

- "abcdef"        <!-- valid, 6 characters -->
- "abcdefs"       <!-- valid, 7 characters -->
- "abcdefaw"      <!-- valid, 8 characters -->
- "abcdefrew"     <!-- valid, 9 characters -->
- "abcdefghij"    <!-- valid, 10 characters -->
- "a"             <!-- invalid, 1 character -->
- "wr2"           <!-- invalid, 3 character-->
- "abcde"         <!-- invalid, 5 characters -->
- "abcdefghijk"   <!-- invalid, 11 characters -->
- Null            <!-- invalid, null input -->
- ""              <!-- invalid, empty string -->
- " "             <!-- invalid, single space -->
