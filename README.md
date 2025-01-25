# Workout Tracker API

Welcome to the **Workout Tracker API**! This is a personal project where I've built an API to track workout schedules, exercises, and user data. Along the way, I learned how to use **OpenAPI** for API documentation and testing, and **xUnit** for unit testing to ensure everything works as expected.

---

## Features

- Manage workout schedules and exercises.
- Keep track of users and their workout routines.
- API documentation with OpenAPI (Swagger).
- Comprehensive unit tests using xUnit to ensure reliability.

---

## What I Learned

### **OpenAPI**
- I learned how to document my API endpoints clearly with OpenAPI, making it easier for others (and my future self) to understand how to interact with the API.
- I explored how Swagger works and how it generates interactive API documentation directly from my code.
- This experience helped me appreciate how important proper documentation is for any API project.

### **xUnit**
- Using xUnit, I wrote unit tests for my API to validate its behavior.
- I learned how to mock dependencies like my database context using `Moq`, which made testing much easier.
- This project gave me a solid understanding of how to test controllers and services effectively.

---

## How to Run the Project

### Prerequisites
- .NET 6.0 or later (tested on .NET 9.0)
- SQL Server (or any configured database for Entity Framework Core)
- Visual Studio Code or any preferred IDE.

### Steps
1. Clone this repository:
   ```bash
   git clone https://github.com/synchoz/Workout-Tracker-API.git
   cd workout-tracker-api
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the project:
   ```bash
   dotnet run --project WorkoutTrackerAPI
   ```

4. Open your browser and navigate to:
   ```
   http://localhost:5000/swagger
   ```
   This will open the Swagger UI with the full API documentation.

---

## How to Run Tests

1. Navigate to the test project directory:
   ```bash
   cd WorkoutTrackerAPI.Tests
   ```

2. Run all tests:
   ```bash
   dotnet test
   ```

This will execute all xUnit tests and display the results in the terminal.

---

## Tools and Libraries Used

- **ASP.NET Core**: For building the API.
- **Entity Framework Core**: For database interaction.
- **SQL Server**: As the database.
- **OpenAPI (Swagger)**: For API documentation.
- **xUnit**: For unit testing.
- **Moq**: For mocking database dependencies in tests.

---

## Acknowledgments

- Thanks to the OpenAPI and xUnit communities for the excellent tools and documentation that made learning so much easier.
- This project is a stepping stone in my journey to become a better developer, and I’m excited to keep building and learning more.

---

Feel free to use or contribute to this project. Let’s build something great! 💪
