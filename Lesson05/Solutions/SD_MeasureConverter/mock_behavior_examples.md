# MockBehavior.Strict vs MockBehavior.Loose in C#

In **Moq**, you can define how a mock object should behave when methods are called:

---

## 1. MockBehavior.Strict

- The mock **only allows methods/properties you explicitly set up**.  
- If you call anything else, it **throws an exception**.  
- Useful when you want to **catch unexpected interactions** with your dependency.

### Example

```csharp
using Moq;
using Xunit;

public class CalculatorTests
{
    [Fact]
    public void StrictMock_ThrowsIfUnexpectedMethodCalled()
    {
        // Create strict mock
        var mock = new Mock<Calculator>(MockBehavior.Strict);

        // Only setup Add
        mock.Setup(m => m.Add(2, 3)).Returns(5);

        // This works
        var result = mock.Object.Add(2, 3);
        Assert.Equal(5, result);

        // This throws! Subtract was not setup
        Assert.Throws<MockException>(() => mock.Object.Subtract(5, 2));
    }
}
```

**Explanation:**

- `Add(2,3)` works because it was explicitly set up.  
- `Subtract(5,2)` throws a `MockException` because strict mode does **not allow calls that weren’t explicitly set up**.  

---

## 2. MockBehavior.Loose

- The mock **allows any call**, even if you didn’t set it up.  
- Returns default values automatically (`null`, `0`, `false`, etc.).  
- Useful when you only care about certain methods and don’t want your test to break for other calls.

### Example

```csharp
[Fact]
public void LooseMock_ReturnsDefaultForUnsetMethods()
{
    // Create loose mock
    var mock = new Mock<Calculator>(MockBehavior.Loose);

    // Only setup Add
    mock.Setup(m => m.Add(2, 3)).Returns(5);

    // Works
    var resultAdd = mock.Object.Add(2, 3);
    Assert.Equal(5, resultAdd);

    // Does NOT throw, returns default value (0 for int)
    var resultSubtract = mock.Object.Subtract(5, 2);
    Assert.Equal(0, resultSubtract); 
}
```

**Explanation:**

- `Add(2,3)` works because it was set up.  
- `Subtract(5,2)` **does not throw**; loose mode returns the default value of the return type (`0` for int).  

---

## 3. When to use which

| Mock Behavior | When to Use | Pros | Cons |
|---------------|------------|------|------|
| **Strict**    | You want to verify **all interactions exactly** | Catches unexpected calls; ensures test correctness | More setup required; brittle to class changes |
| **Loose**     | You only care about **specific methods** | Less setup; easier tests | Might hide unexpected calls; less strict verification |

---

### ✅ Summary

- **Strict** → Safe, precise, catches unexpected calls.  
- **Loose** → Convenient, forgiving, returns defaults automatically.