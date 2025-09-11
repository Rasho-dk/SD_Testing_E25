### Airline discount policy
An airline offers only flights to India and Asia. Under special conditions, a discount is offered on the normal airfare:
- `Passengers older than 18` with `destinations in India` are offered a `discount of 20%`, as long as the departure is `*not* on a Monday or Friday`
- For destinations `outside` of India, passengers are offered a discount of `25%`, if the departure is `not on a Monday or Friday`
- Passengers who stay `at least 6 days` at their destination receive an `additional` discount of `10%`
- Passengers `older than 2 but younger than 18 years` are offered a discount of `40%` for `all destinations` <!--Is Monday or Friday incl. in this age...?-->
- Children `2 and under travel for free`

Apply black-box test design:
1. Represent this information in a decision table.
2. Write the corresponding unit tests (one test case per business rule) using the programming language and unit test framework of your choice

<sub>Adapted from FlexRule, ["Preparing a decision table"](https://resource.flexrule.com/knowledge-base/preparing-a-decision-table/)</sub>

### Solution

#### 1. Decision table
| Condition            | TC1 | TC2 | TC3 | TC4 | TC5 | TC6 | TC7 | TC8 | TC9 | TC10 | TC11 |
|----------------------|-----|-----|-----|-----|-----|-----|-----|-----|-----|------|------|
| Age > 18             | T   | T   | T   | T   | T   | T   | T   | T   | F   | -    | -    |
| Age > 2 and <  18    | -   | -   | -   | -   | -   | -   | -   | -   | T   | T    | -    |
| Age <= 2             | -   | -   | -   | -   | -   | -   | -   | -   | -   | -    | T    |
| Destination in India | T   | T   | T   | T   | F   | F   | F   | F   | -   | -    | -    |
| Departure  Mon/Fri   | F   | T   | F   | T   | F   | F   | T   | T   | -   | -    | -    |
| Stay >= 6 days       | -   | T   | T   | F   | F   | T   | T   | F   | F   | T    | -    | 
| Action               | --- | --- | --- | --- | --- | --- | --- | --- | --- | ---  | ---  |
| Discount %           | 20% | 10% | 30% | 0%  | 25% | 35% | 10% | 0%  | 40% | 50%  | -    |
| Free travel          | N   | N   | N   | N   | N   | N   | N   | N   | N   | N    | Y    |

#### 2. Unit tests : in C#
