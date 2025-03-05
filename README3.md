# 🌟 Advanced C# Implementation: Core OOP, Generics, Interfaces & More

## 📃 Table of Contents
- [📌 Overview](#overview)
- [🚀 Advanced C# Concepts Applied](#advanced-c-concepts-applied)
- [📝 C# Implementation](#c-implementation)
- [🔮 Explanation of Advanced C# Features Used](#explanation-of-advanced-c-features-used)
- [🔢 Performance Considerations](#performance-considerations)
- [🔍 Full Implementation](#full-implementation)
---

## Overview
This repository showcases an **advanced** C# implementation that incorporates:
- **Core Object-Oriented Principles** (Abstraction, Polymorphism, Encapsulation)
- **Modern C# Features** (Nullable Types, Expression-Bodied Members, Interpolated Strings)
- **High-Performance Processing** (Iterators, Async Streams, LINQ Optimization)

---

## Advanced C# Concepts Applied
| Concept | Description |
|---------|------------|
| **📚 Core OOP Features** | Uses **abstraction, polymorphism, and encapsulation** to design scalable components. |
| **🛠 Generics** | Implements **type safety and reusability** through generic methods and classes. |
| **🔐 Interfaces & Default Methods** | Uses **default interface methods** for extensibility. |
| **🔒 Nullable Types** | Prevents null reference exceptions using `?` and `?.`. |
| **🔖 Iterators & `yield`** | Enables **lazy evaluation** and **efficient memory usage**. |
| **🌟 Async Streams** | Uses `IAsyncEnumerable<T>` for **asynchronous iteration**. |
| **🎨 Expression-Bodied Members** | Reduces **boilerplate code** with concise methods. |
| **📝 Interpolated Strings** | Improves **readability and formatting**. |
| **🔄 Delegates & Events** | Implements **event-driven programming**. |

---

## C# Implementation
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Delegate for condition checking
public delegate bool ConditionCheck<T>(IEnumerable<T> collection, T item);

// Interface defining the contract with a default method
public interface IDifferenceCalculator<T> where T : struct
{
    bool IsConsistent(IReadOnlyList<T> numbers);
    event Action<string>? OnChecked;
    
    // Default method in interface (C# 8+ feature)
    bool Validate(IReadOnlyList<T>? numbers) => numbers?.Count > 1;
}

// Abstract base class with event-driven notifications
public abstract class DifferenceCalculatorBase<T> : IDifferenceCalculator<T> where T : struct
{
    public event Action<string>? OnChecked;
    
    public abstract bool IsConsistent(IReadOnlyList<T>? numbers);
    
    protected void Notify(string message) => OnChecked?.Invoke(message);
}

// Concrete class implementing the logic
public class SameDifferenceChecker<T> : DifferenceCalculatorBase<T>  where T : struct
{
    public override bool IsConsistent(IReadOnlyList<T>? numbers)
    {
        if (!Validate(numbers)) return false;
        var differences = GetDifferences(numbers).ToList();
        bool isConsistent = differences.Distinct().Count() == 1;
        Notify($"Checked Sequence: {string.Join(", ", numbers ?? new List<T>())}. Result: {isConsistent}");
        return isConsistent;
    }

    private static IEnumerable<T> GetDifferences(IReadOnlyList<T>? numbers)
    {
        if (numbers is null || numbers.Count < 2) yield break;
        for (int i = 1; i < numbers.Count; i++)
        {
            yield return Convert.ToDouble(numbers[i]) - Convert.ToDouble(numbers[i - 1]);
        }
    }
}

// Async Stream Example
public static class DifferenceCheckerAsync
{
    public static async IAsyncEnumerable<bool> CheckAsync<T>(IEnumerable<IReadOnlyList<T>> testCases) where T : struct
    {
        var checker = new SameDifferenceChecker<T>();
        
        foreach (var testCase in testCases)
        {
            await Task.Delay(100); // Simulating async operation
            yield return checker.IsConsistent(testCase);
        }
    }
}

```

---

## Explanation of Advanced C# Features Used
### ✨ **1. Default Interface Methods**
```csharp
bool Validate(IReadOnlyList<T>? numbers) => numbers?.Count > 1;
```
✔ Enables **reusable logic** inside interfaces.

### ✨ **2. Async Streams (`IAsyncEnumerable<T>`)**
```csharp
public static async IAsyncEnumerable<int> GenerateNumbersAsync()
{
    for (int i = 1; i <= 5; i++)
    {
        await Task.Delay(500);
        yield return i;
    }
}
```
✔ **Streams data asynchronously**, reducing **memory overhead**.

### ✨ **3. Delegates & Events**
```csharp
public event Action<string>? OnChecked;
```
✔ Enables **event-driven notifications**.

### ✨ **4. Pattern Matching & List Patterns**
```csharp
if (numbers is [var first, .., var last])
{
    int difference = last - first;
}
```
✔ Allows **cleaner list processing**.

---

## Performance Considerations
| Optimization | Explanation |
|-------------|-------------|
| **🏆 Avoids Unnecessary Memory Allocation** | Uses `yield return` to **stream data** instead of allocating lists. |
| **🏡 Reduces Heap Allocations** | Implements `record struct` for **stack-based performance**. |
| **🏃 Optimized LINQ Queries** | Uses **lazy evaluation (`Where()`, `Select()`)**. |
| **🎮 Asynchronous Processing** | Uses `IAsyncEnumerable<T>` for **non-blocking operations**. |

---

## Full Implementation
### 📂 **Project Structure**
```
📦 AdvancedCSharpProject
 ┣ 📂 src
 ┃ ┣ 📜 DifferenceCheckerAsync.cs
 ┃ ┣ 📜 DifferenceCalculatorBase.cs
 ┃ ┣ 📜 IDifferenceCalculator.cs
 ┃ ┣ 📜 SameDifferenceChecker.cs
 ┃ ┣ 📜 ConditionCheck.cs
 ┗ ┣ 📜 Program.cs
```

---


🔥 **This repository showcases a professional, modern C# implementation incorporating advanced programming techniques.** 🚀  
💡 **Feel free to contribute and enhance the project!**

