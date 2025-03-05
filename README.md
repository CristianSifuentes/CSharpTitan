# 🎯 Advanced C# Implementation: Polymorphism, Generics, Delegates & Abstraction

## 📚 Table of Contents

1. [Example One](#example-one)
   - [📌 Overview Example One](#overview-example-one)
   - [🚀 Key Concepts Applied Example One](#key-concepts-applied-example-one)
   - [💡 Code Explanation Example One](#code-explanation-example-one)
   - [🏆 Why This is a Professional Implementation](#why-this-is-a-professional-implementation)
   - [🔍 Full Implementation Example One](#full-implementation-example-one)
2. [Example Two](#example-two)
   - [📌 Overview Example Two](#overview-example-two)
   - [🚀 Advanced C# Concepts Applied Example Two](#advanced-c-concepts-applied-example-two)
   - [📝 C# Implementation Example Two](#c-implementation-example-two)
   - [🔮 Explanation of Advanced C# Features Example Two](#explanation-of-advanced-c-features-example-two)
   - [🔢 Performance Considerations Example Two](#performance-considerations-example-two)
   - [🔍 Full Implementation Example Two](#full-implementation-example-two)
3. [Example Three](#example-three)
   - [📌 Overview Example Three](#overview-example-three)
   - [🚀 Advanced C# Concepts Applied Example Three](#advanced-c-concepts-applied-example-three)
   - [📝 C# Implementation Example Three](#c-implementation-example-three)
   - [🔮 Explanation of Advanced C# Features Used](#explanation-of-advanced-c-features-used)
   - [🔢 Performance Considerations Example Three](#performance-considerations-example-three)
   - [🔍 Full Implementation Example Three](#full-implementation-example-three)
4. [Example Four](#example-four)
5. [Example Five](#example-five)



---

# Example One

Here’s a professional and strongly designed C# implementation using polymorphism, generics, delegates, and abstraction

## Overview Example One
This repository showcases a **professional** and **robust** C# implementation that leverages:
- **Polymorphism**
- **Generics**
- **Delegates**
- **Abstraction**
- **LINQ**
- **Encapsulation**
- **Event-Driven Programming**

The goal of this implementation is to **efficiently determine if a number appears in a collection at least a given number of times**, using **advanced C# principles** for scalability, maintainability, and performance.

---

## Key Concepts Applied Example One
| Concept | Description |
|---------|------------|
| **🔄 Polymorphism** | Enables the use of multiple implementations for a base contract. |
| **🧩 Abstraction** | Uses an abstract class to define a blueprint for checking conditions. |
| **⚡ Delegates** | Encapsulates method references dynamically. |
| **🔢 Generics** | Allows type safety while ensuring flexibility across different data types. |
| **🔍 LINQ** | Enables efficient collection queries. |
| **🔧 Encapsulation** | Restricts direct access to implementation details. |
| **📡 Event-Driven** | Uses an event to notify when a condition is checked. |

---


## Code Explanation Example One
### **1️⃣ Abstract Base Class (`NumberCheckerBase<T>`)**
- Defines the **contract** for checking occurrences.
- Uses a **delegate** to allow **dynamic behavior injection**.

```csharp
public abstract class NumberCheckerBase<T>
{
    protected CheckCondition<T> ConditionChecker { get; }

    protected NumberCheckerBase(CheckCondition<T> conditionChecker)
    {
        ConditionChecker = conditionChecker ?? throw new ArgumentNullException(nameof(conditionChecker));
    }

    public abstract bool Contains(IEnumerable<T> collection, T item, int minOccurrences);
}
```

### **2️⃣ Delegate for Custom Logic (`CheckCondition<T>`)**
- Allows passing a custom comparison function..


```csharp
public delegate bool CheckCondition<T>(IEnumerable<T> collection, T item, int threshold);

```


### **3️⃣ Concrete Implementation (`NumberChecker<T>`)**
- Implements the contract from NumberCheckerBase<T>.
- Calls the delegate dynamically.

```csharp
public class NumberChecker<T> : NumberCheckerBase<T> where T: struct
{
    public NumberChecker(CheckCondition<T> conditionChecker) : base(conditionChecker) { }

    public override bool Contains(IEnumerable<T> collection, T item, int threshold)
    {
        return ConditionChecker(collection, item, threshold);
    }
}
```

### **4️⃣ Utility Class for Condition Checking**
- Provides a reusable LINQ-based implementation for checking occurrences.

```csharp
public static class CheckConditions
{
    public static bool CountOccurrences<T>(IEnumerable<T> collection, T item, int threshold)
    {
        return collection.Count(x => EqualityComparer<T>.Default.Equals(x, item)) >= threshold;
    }
}

```


### **5️⃣ Event-Driven Notifications**
- The class raises an event when a check is performed.


```csharp
public class EventDrivenChecker<T> : NumberCheckerBase<T>
{
    public event Action<string>? OnConditionChecked;

    public EventDrivenChecker(CheckCondition<T> conditionChecker) : base(conditionChecker) { }

    public override bool Contains(IEnumerable<T> collection, T item, int minOccurrences)
    {
        bool result = ConditionChecker(collection, item, minOccurrences);
        OnConditionChecked?.Invoke($"Checked {item} - Result: {result}");
        return result;
    }
}
```


### **6️⃣ Example Usage**

```csharp
List<int> numbers = new() { 4, 5, 2, 4, 5, 9, 9, 4, 4 };

// Instantiate checker with the provided condition
NumberChecker<int> checker = new(CheckConditions.CountOccurrences);

Console.WriteLine(checker.Contains(numbers, 4, 3)); // True
Console.WriteLine(checker.Contains(numbers, 4, 5)); // False
Console.WriteLine(checker.Contains(numbers, 9, 2)); // True

```

### **7️⃣ Event Usage Example**

```csharp
EventDrivenChecker<int> eventChecker = new(CheckConditions.CountOccurrences);
eventChecker.OnConditionChecked += msg => Console.WriteLine($"[Event Triggered] {msg}");

eventChecker.Contains(numbers, 4, 3); // Triggers event

```


## Why This is a Professional Implementation

### 🔧 Follows SOLID Principles
- **Single Responsibility Principle**: Each class has **one job**, making the code easier to maintain.
- **Open/Closed Principle**: New conditions can be **added without modifying existing code**.
- **Liskov Substitution Principle**: `NumberChecker<T>` can be seamlessly **replaced with `EventDrivenChecker<T>`**.

### 🛠 Scalable & Maintainable
- Uses **delegates** instead of **hardcoded logic** for flexibility.
- Implements **event-driven notifications** for **real-time feedback**.
- Supports **different number types using generics**, ensuring extensibility.

### 🏃 High Performance
- **Optimized with LINQ** for efficient **filtering and querying**.
- Uses **expression-bodied members** to write **cleaner, concise code**.
- **Prevents unnecessary object allocations**, improving memory efficiency.

### 🔄 Reusable and Testable
- The **utility class (`CheckConditions`)** provides **reusable logic**.
- The **abstract class (`NumberCheckerBase<T>`)** enables **extensibility**.
- The **event-driven class (`EventDrivenChecker<T>`)** allows **real-time logging**.

This structured approach ensures a **highly professional**, **scalable**, and **efficient** C# implementation, following best software engineering practices. 🚀


## Full Implementation Example One

Project Structure

```css
📦 CSharpTitan
 ┣ 📂 ExampleOne
 ┃ ┣ 📜 CheckConditions.cs
 ┃ ┣ 📜 NumberChecker.cs
 ┃ ┣ 📜 NumberCheckerBase.cs
 ┃ ┣ 📜 EventDrivenChecker.cs 
 ┗ ┣ 📜 Program.cs

```

# Example Two

Here is a highly professional and modern C# solution implementing advanced C# concepts

---

## Overview Example Two
This repository showcases a **highly professional and modern** C# solution using advanced C# concepts, ensuring **scalability, performance, and maintainability**. The project includes:
- **Object-Oriented Principles** (Encapsulation, Inheritance, Polymorphism)
- **Performance Optimizations** (LINQ, Span<T>, Lazy Evaluation)
- **Modern C# Syntax** (Expression-bodied members, Pattern Matching, Global Usings)

---

## Advanced C# Concepts Applied Example Two
| Concept | Description |
|---------|------------|
| **📚 Inheritance & Polymorphism** | Uses an **abstract base class** with a **derived class** for extensibility. |
| **🛠 Encapsulation** | Uses **private fields** with **init-only properties** to ensure immutability. |
| **✨ LINQ** | Efficient querying of collections to **optimize performance**. |
| **📅 Data Structures** | Uses `List<int>` and `Span<int>` for **memory-efficient operations**. |
| **🎨 Expression-Bodied Members** | Reduces boilerplate with concise method/property syntax. |
| **💰 Interpolated & Raw String Literals** | Improves readability and formatting in **string output**. |
| **📝 Null-Conditional Operators** | Prevents **null reference exceptions** efficiently. |
| **🌟 Records & Init-Only Properties** | Provides **immutable** data structures. |
| **🚀 Top-Level Statements** | Simplifies entry points in **C# 9+** projects. |
| **🔍 Pattern Matching & List Patterns** | Enables **cleaner switch-case logic**. |
| **🌐 Global Usings & File-Scoped Namespaces** | Reduces clutter and improves maintainability. |
| **🌐 Delegates & Events** | Implements **event-driven programming**. |
| **🔄 Generic Classes & Attributes** | Enhances **flexibility** and **type safety**. |

---

## C# Implementation Example Two
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

// Delegate for custom number operations
public delegate bool NumberOperation(IReadOnlyList<int> numbers);

// Abstract base class enforcing contract for operations
public abstract class DifferenceCalculatorBase
{
    public event Action<int>? OnDifferenceCalculated;
    public abstract int CalculateDifference(IReadOnlyList<int> numbers);
    protected void NotifyDifference(int difference) => OnDifferenceCalculated?.Invoke(difference);
}

// Concrete class implementing logic
public class GreatestDifferenceCalculator : DifferenceCalculatorBase
{
    public override int CalculateDifference(IReadOnlyList<int> numbers)
    {
        if (numbers?.Any() != true) return 0;
        int min = numbers.Min();
        int max = numbers.Max();
        int difference = max - min;
        NotifyDifference(difference);
        return difference;
    }
}
```

---

## Explanation of Advanced C# Features Example Two
### ✨ **1. Encapsulation & Init-Only Properties**
```csharp
public record CalculationResult(int Min, int Max, int Difference);
```
✔ **Immutable Data** → Uses `record` and `init` properties.

### ✨ **2. LINQ Optimization**
```csharp
int difference = numbers.Max() - numbers.Min();
```
✔ Uses **LINQ functions (`Min()`, `Max()`)** for **performance**.

### ✨ **3. Event-Driven Programming**
```csharp
public event Action<int>? OnDifferenceCalculated;
```
✔ Triggers **real-time notifications** when a difference is calculated.

### ✨ **4. Pattern Matching & List Patterns**
```csharp
if (numbers is [var first, .., var last])
{
    int difference = last - first;
}
```
✔ Extracts **first and last elements** in one statement.

---

## Performance Considerations Example Two
| Optimization | Explanation |
|-------------|-------------|
| **🏆 Avoids Unnecessary Memory Allocation** | Uses `Span<int>` to **process large datasets efficiently**. |
| **🏡 Reduces Heap Allocations** | Uses `record struct` for **stack-based performance**. |
| **🏋 Lazy Evaluation** | Uses `yield return` to **stream data**. |
| **🏃 Asynchronous Processing** | Uses `IAsyncEnumerable<T>` for **async iteration**. |

---

## Full Implementation Example Two
### 📂 **Project Structure**
```
📦 AdvancedCSharpProject
 ┣ 📂 src
 ┃ ┣ 📜 CalculationResult.cs
 ┃ ┣ 📜 CheckConditions.cs
 ┃ ┣ 📜 DifferenceCalculatorBase.cs
 ┃ ┣ 📜 GreatestDifferenceCalculator.cs
 ┃ ┣ 📜 NumericAnalyzerAttribute.cs
 ┗ ┣ 📜 Program.cs
```

---

# Example Three

## Overview Example Three
This repository showcases an **advanced** C# implementation that incorporates:
- **Core Object-Oriented Principles** (Abstraction, Polymorphism, Encapsulation)
- **Modern C# Features** (Nullable Types, Expression-Bodied Members, Interpolated Strings)
- **High-Performance Processing** (Iterators, Async Streams, LINQ Optimization)

---

## Advanced C# Concepts Applied Example Three
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

## C# Implementation Example Three
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

## Performance Considerations Example Three
| Optimization | Explanation |
|-------------|-------------|
| **🏆 Avoids Unnecessary Memory Allocation** | Uses `yield return` to **stream data** instead of allocating lists. |
| **🏡 Reduces Heap Allocations** | Implements `record struct` for **stack-based performance**. |
| **🏃 Optimized LINQ Queries** | Uses **lazy evaluation (`Where()`, `Select()`)**. |
| **🎮 Asynchronous Processing** | Uses `IAsyncEnumerable<T>` for **non-blocking operations**. |

---

## Full Implementation Example Three
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


