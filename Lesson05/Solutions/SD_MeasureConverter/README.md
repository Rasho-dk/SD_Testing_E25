# 🧪 Testing APIs: Unit vs Integration

Testing server code that interacts with external APIs requires two approaches: unit testing (with mocks) and integration testing (with real APIs). Each serves a unique purpose in ensuring your code is reliable and robust.

---

## 1️⃣ Unit Testing with Mocked APIs

Unit tests focus on your code in isolation. By mocking external APIs, you can:

- **Verify your logic:**
    - Are you calling the correct endpoint?
    - Is JSON handled properly?
    - Are exceptions thrown for bad responses?
- **Isolate from external systems:**
    - No failures due to API downtime or data changes.
    - Tests run offline and quickly.
- **Control scenarios:**
    - Simulate success (200 OK), errors (404, 500), and edge cases.
    - Test all branches of your logic.
- **Repeatable & fast:**
    - Same input → same output, every run.

**Summary:** Mocking APIs in unit tests makes your code robust, fast, and independent of third-party changes.

---

## 2️⃣ Integration Testing with Real APIs

Integration tests check that your system works end-to-end with real external APIs. They:

- **Verify real communication:**
    - Does your server make the actual HTTP call?
    - Are headers (API key) and URLs correct?
- **Validate real data flow:**
    - Can your code deserialize the real JSON response?
    - Does your service return the correct object?
- **Catch integration issues early:**
    - Field name changes, invalid API keys, SSL issues, etc.
    - Find problems before users do.
- **Ensure end-to-end behavior:**
    - Test the contract between your server and the API: HTTP, authentication, parsing, business logic.

**Summary:** Integration tests ensure your system works with real-world APIs and catches issues that mocks cannot.

---

## 🆚 Comparison

| Aspect              | Unit Test (Mocked API)        | Integration Test (Real API)   |
|---------------------|-------------------------------|-------------------------------|
| Speed               | Fast                          | Slower                        |
| Reliability         | High (no external dependency) | Lower (depends on API uptime) |
| Scope               | Isolated logic                | End-to-end system             |
| Scenario Coverage   | All branches, errors, edge    | Real-world scenarios          |
| Detects API changes | No                            | Yes                           |
| Internet required   | No                            | Yes                           |

---

**Best Practice:** Use both types of tests to ensure your code is correct, robust, and ready for production.
