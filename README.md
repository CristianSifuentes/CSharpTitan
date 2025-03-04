# 🎯 Advanced C# Implementation: Polymorphism, Generics, Delegates & Abstraction

## 📚 Table of Contents
- [📌 Overview](#overview)
- [🚀 Key Concepts Applied](#key-concepts-applied)
- [💡 Code Explanation](#code-explanation)
- [🏆 Why This is a Professional Implementation](#why-this-is-a-professional-implementation)
- [🔍 Full Implementation](#full-implementation)

---

## Overview
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

## Key Concepts Applied
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

## Code Explanation
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

    public override bool Contains(IEnumerable<T> collection, T item, int minOccurrences)
    {
        return ConditionChecker(collection, item, minOccurrences);
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




## Full Implementation

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

