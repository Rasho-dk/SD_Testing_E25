### Input form
An input form has two textboxes ("Username" and "Password"). Access to the homepage will be granted only if both fields are correct. Represent the situation in a decision table.

| **Textbox**  | **Rule1** | **Rule2** | **Rule3** | **Rule4** |
|:------------:|:--------:|:--------:|:--------:|:--------:|
| **UserName** |    T     |    T     |    F     |    F     |
| **Password** |    T     |    F     |    T     |    F     |
| **Action**   |          |          |          |          |
| Login        |    T     |    F     |    F     |    F     |
| No Access    |    F     |    T     |    T     |    T     |
