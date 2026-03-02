## Overview

This repository contains a refactored solution for the Gilded Rose inventory system. The primary goal was to transform a tightly coupled, conditional-heavy codebase into a maintainable, test-driven architecture while implementing the new "Conjured" item functionality.

## Design Decisions
### 1. The Strategy Pattern
I replaced the nested if-else logic in UpdateQuality with a Strategy Pattern.

- **Reasoning**: Each item type now has its own dedicated class (e.g., `AgedBrieUpdater`, `BackstagePassUpdater`) implementing a common IItemUpdater interface. This follows the **Single Responsibility Principle** and makes the logic for each item type easy to isolate and debug.
- **Encapsulation**: By using a `BaseItemUpdater`, I centralized the shared "safety rails" (Min Quality 0, Max Quality 40).

### 2. Factory Pattern
The ItemUpdaterFactory centralizes the logic for selecting the correct update strategy.

- **Robustness**: I utilized .StartsWith() for category matching (e.g. `Conjured`). This ensures the system is resilient to varied item naming while strictly following the categories defined in the requirements.

### 3. Item Class Constraint
As per the specification, the Item class and its properties remained unaltered. All logic was implemented by wrapping the item in an updater retrieved via the Factory.

### Technical Capability & Principles
- **Readability**: Each updater class is small (typically <15 lines), making the business logic for each item immediately apparent.
- **Maintainability**: Adding a new item type no longer requires touching existing logic for other items, preventing regression bugs.
- **Open/Closed Principle**: The system is "Open" for extension (adding new items) but "Closed" for modification (we don't need to change the main GildedRose loop).

### Testing Strategy
I utilized NUnit 4 to create a robust suite of unit tests.

- **Data-Driven Testing**: I used `[TestCase]` attributes to cover multiple boundary conditions (e.g., SellIn values of 11, 10, 6, 5, 1, and 0 for Backstage Passes) within single test methods.
- **Boundary Analysis**: Tests were specifically written to verify the 40 Quality Cap and the 0 Quality Floor, ensuring that even "Legendary" or "Conjured" items respect the system's global constraints.
- **Refactoring Safety**: Before modifying the original logic, I verified existing behavior with characterization tests to ensure 100% functional parity.

### "Above and Beyond": Extensibility
A key advantage of this refactored architecture is its extreme ease of extension. For example, if the innkeeper introduced a "Frozen" item category (which degrades at half the speed of normal items), the implementation would require only two steps:

- Create a FrozenUpdater class inheriting from `BaseItemUpdater`.
- Add one line to the `ItemUpdaterFactory` to map the name "Frozen" to the new class.
This illustrates that the codebase is now prepared for future business requirements with minimal risk.

### How to Run
#### Prerequisites
- .NET 8.0 SDK

#### Build and Run
To restore dependencies, build the project, and run the main entry point:

#### Bash
- dotnet run
  
#### Running Tests
To execute the NUnit test suite and view the results:

#### Bash
- dotnet test


