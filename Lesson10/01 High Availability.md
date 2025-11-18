### High Availability Exercises

1. What is the availability of a system with MTTF = 17520h (2 years) and MTTR = 48h?
2. A system has MTTF = 48192h (5,5 years) and MTTR = 3h. Does it offer high availability?
3. Which should be the maximum MTTR for a high availability system with MTTF = 61320h (7 years)?
4. Which should be the MTTF for a system with MTTR = 24h so that it fulfills the following:
  - Three nines
  - Four nines
  - High availability

#### Solutions

1. What is the availability of a system with MTTF = 17520h (2 years) and MTTR = 48h?
```
Availability = (MTTF * 100) / (MTTF + MTTR) = (17520h * 100) / (17530h + 48h) = 99,73%
```

2. A system has MTTF = 48192h (5,5 years) and MTTR = 3h. Does it offer high availability?
```
Availability = (MTTF * 100) / (MTTF + MTTR) = (48192 * 100) / (48192 + 3) = 99,994%
```
It does not offer high availability

3. Which should be the maximum MTTR for a high availability system with MTTF = 61320h (7 years)?
```
High Availability = 99,999% = (61320h * 100) / (61320h + MTTR) 
MTTR = (6132000 – (99,999 * 61320)) / 99,999 = 0,613h = 36'47"
```

4. Which should be the MTTF for a system with MTTR = 24h so that it fulfills the following:
  - Three nines
    ```
    Availability * (MTTF + MTTR) = MTTF * 100
    (Availability * MTTF) + (Availability * MTTR) = MTTF * 100
    Availability * MTTR = (MTTF * 100) – (Availability * MTTF) = MTTF * (100 – Availability)
    MTTF = (Availability * MTTR) / (100 – Availability)
    MTTF = (99,9 * 24h) / (100 – 99,9) = 23976d = 2,74 years
    ```
  - Four nines
    ```
    MTTF = (99,99 * 24h) / (100 – 99,99) = 239976d = 27,39 years
    ```
  - High availability
    ```
    MTTF = (99,999 * 24h) / (100 – 99,999) = 2399976d = 273,97 years
    ```
