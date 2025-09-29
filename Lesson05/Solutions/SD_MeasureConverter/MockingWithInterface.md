# Mocking in .NET: Why Use Interfaces or Abstract Methods?

## Overview

When writing unit tests in .NET, it's common to use mocking frameworks like Moq to simulate dependencies. However, Moq can only mock methods that are:
- Declared on an **interface**
- Marked as **virtual** or **abstract** in a class

This is because Moq creates a proxy object that overrides these methods at runtime. Non-virtual methods in concrete classes cannot be intercepted by Moq.

## Why Interfaces or Abstract Methods?

- **Interfaces**: All methods are implicitly overridable, so Moq can easily create a mock implementation.
- **Abstract/Virtual Methods**: These can be overridden by derived classes, allowing Moq to inject its own behavior.

**Non-virtual methods** in concrete classes cannot be mocked because .NET does not allow runtime overriding of these methods.

## Example: Mocking with an Interface

Suppose you have a currency API:

In your test, you can mock `ICurrencyApi`:

## Example: Mocking with a Virtual Method

If you use a class, mark the method as `virtual`:

Now Moq can mock this method:

## Summary

- Use **interfaces** or **virtual/abstract methods** for dependencies you want to mock.
- Moq cannot mock non-virtual methods in concrete classes.
- This approach makes your code more testable and flexible.
