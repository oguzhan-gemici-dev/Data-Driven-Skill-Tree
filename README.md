# Data-Driven Skill Tree Architecture 🌳

A highly modular, data-driven, and event-based skill tree system built with C# and Unity. This project demonstrates core backend software engineering principles, prioritizing the **Separation of Concerns** and **Clean Architecture** over standard game engine coupling.

## 🚀 Engineering Highlights

* **Data-Driven Design (JSON Parsing):** The system dynamically constructs the skill tree by parsing a `.json` configuration file at runtime via Data Transfer Objects (DTOs). Adding new skills requires zero code compilation.
* **Event-Driven Architecture (Observer Pattern):** Eliminates tightly coupled spaghetti code. The core logic uses C# `Action` delegates to broadcast state changes. UI components act solely as listeners (subscribers) that update their visual states independently.
* **Optimized Time Complexity:** Utilizes a Hash Table (`Dictionary<string, SkillNode>`) for underlying data storage instead of linear lists, ensuring **O(1)** time complexity for skill lookups and validation, even in massive skill trees.
* **Dynamic UI Instantiation:** The Frontend (UI) is entirely dynamic. Buttons and layouts are generated procedurally at runtime based on the parsed JSON data (Factory approach), keeping the Unity Editor workflow clean.

## 🧠 System Architecture

The project strictly separates logic, data, and presentation:

1. **Data Layer (`SkillNode.cs`):** Pure C# class holding individual skill states and tracking parent-child dependencies (Directed Graph representation).
2. **Logic Layer (`SkillTreeManager.cs`):** A backend controller completely isolated from Unity's `MonoBehaviour`. It handles algorithm traversal, validation logic, and event dispatching.
3. **Presentation Layer (`SkillUIButton.cs`):** Dumb UI components that only listen to the Logic Layer's broadcasts and trigger unlock requests.

## 🛠️ Tech Stack
* **Language:** C# (Pure C# for core logic)
* **Engine:** Unity (Used strictly for rendering UI and Input handling)
* **Data Format:** JSON
