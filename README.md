# Description:
This project implements a Rebate Calculation Service using SOLID principles and clean architecture to ensure scalability, testability, and maintainability. The service calculates rebates based on various incentive types, allowing easy extension for future incentive types. The project includes unit tests to ensure correctness and follows best practices for dependency injection and separation of concerns.

## Key Features:
Rebate Calculation: Supports different incentive types including:
- Fixed Cash Amount
- Fixed Rate Rebate
- Amount Per Unit of Measure (UoM)

## SOLID Principles: 

The service is designed to adhere to SOLID principles, ensuring the system is open for extension but closed for modification.
Extensible Design: New incentive types can be added easily without modifying the existing codebase, thanks to the use of interfaces and the strategy pattern.
Unit Testing: Comprehensive unit tests using Moq and xUnit to verify the behavior of the rebate calculation in various scenarios, including success and failure cases.

## Technologies:
- C# (.NET Core)
- Autofac: For dependency injection.
- xUnit: For unit testing.
- Moq: For mocking dependencies in unit tests.
