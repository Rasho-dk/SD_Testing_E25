# Coverage calculation

**_Statement coverage_** means ensuring every executable line runs at least once.

**_Decision coverage_** goes deeper—it ensures every possible branch (true/false) of each decision is tested.

## Number
Define a minimum set of test cases for the following pseudocode to reach
1. 100% statement coverage
2. 100% decision coverage

```BASIC
    lContinue = true;
    
    while(lContinue)
    Write "Enter number: ";
    Read nNumber;
    
    if(nNumber = 0) 
        lContinue = false;
    else  
        Write "Choose an option: ";
        Write "Choose an option: ";
        Write "0. Quit";
        Write "1. Check if even or odd";
        Write "2. Check if prime";
    Read nOption;
    
    if(nOption = 0)
         lContinue = false;
    else
        if(nOption = 1)
        if(nNumber MOD 2 = 0)
            Write "Even";
    else 
        Write "Odd";
    else 
        if(nOption = 2)
        if(IsPrime(nNumber))
    Write "Prime";
    else 
        Write "Not prime";
        Write "Goodbye";
```
### **Statement coverage:**
- Number = 4, nOption = 1 \--> print "Even"
- Number = 5, nOption = 1 \--> print "Odd"
- Number = 7, nOption = 2 \--> print "Prime"
- Number = 8, nOption = 2 \--> print "Not prime"
- Number = 0, exits immediately
- Number = 9, nOption = 0 \--> print "Goodbye"

#### **decision coverage:**

| TestCase | nNumber | nOption | Expected output             | Covered Decisions          |
|----------|---------|---------|-----------------------------|----------------------------|
| TC1      | 0       | -       | Goodbye                     | #1(T)                      |
| TC2      | 5       | 0       | Goodbye                     | #1(F), #2(T)               |
| TC3      | 4       | 1       | Even                        | #1(F), #2(F), #3(T), #4(T) |
| TC4      | 5       | 1       | Odd                         | #1(F), #2(F), #3(T), #4(F) |
| TC5      | 7       | 2       | Prime                       | #5(T), #6(T)               |
| TC6      | 8       | 2       | Not prime                   | #6(F)                      |
| TC7      | 9       | 3       | No output or Invalid option | -                          |


## Employees

Define a minimum set of test cases for the following pseudocode to reach
1. 100% statement coverage
2. 100% decision coverage

```
NumEmployees = 0

Write "Insert country code"
Read CountryCode

Open employees file 
If not error
    While not eof
        Read file line
        If employee's country code = CountryCode
            Write "Name: " + employee's name
            NumEmployees++
        Endif
    Endwhile
    Close employees file
    Write "Total employees: " + NumEmployees
Else
    Write "Error opening the file"
Endif
```
### **Statement coverage:**
- Open employees file
- CountryCode = "DK" → Employees = 2
- CountryCode = "NO" → Employees = 0
- Error with opening the file

### **Decision coverage:**

| TestCase | CountryCode | File Status | Employee Data | Expected Output                      |
|----------|-------------|-------------|---------------|--------------------------------------|
| TC1      | DK          | Success     | DK, SE, DK    | Names of DK employees <br/> Total :2 |
| TC2      | SE          | Success     | DK, SE, DK    | Names of SE employees <br/> Total :1 |
| TC3      | NO          | Success     | DK, SE        | No names printed + Total = 0         |
| TC4      | DK          | Error       | -             | Error opening the file               |


Exercises based on Brian Hambling’s*Software Testing: An ISTQB-BCS Certified Tester Foundation Guide*, 4thed. (2019)

