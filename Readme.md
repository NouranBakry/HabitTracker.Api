Habit Tracker API
=================
ASP.NET Core | Clean Architecture | Azure-Ready

A scalable backend REST API built with ASP.NET Core to track user habits, daily completions, and progress analytics.
This project demonstrates modern backend engineering practices using C#/.NET, Entity Framework Core, and clean architectural principles.

Purpose of the Project

This project was built to:

Refresh and demonstrate C# / .NET backend expertise

Showcase API design, database modeling, and clean architecture

Serve as a production-style backend service deployable to Azure

Highlight experience relevant to cloud-native backend engineering roles

🏗 Architecture

The API follows a clean layered structure:

HabitTracker.Api
├── Controllers → HTTP endpoints
├── Models → Database entities
├── DTOs → Data transfer objects
├── Data → DbContext & EF Core configuration
├── Services → Business logic layer

Core Features
- User Management

Create user

Basic profile handling

- Habit Management

Create habits (e.g., Exercise, Reading, Water Intake)

Track habit frequency (Daily / Weekly)

Associate habits with specific users

-  Habit Tracking

Mark habits as completed

Track completion dates

Prevent duplicate completion entries per day

- Progress Analytics (Foundation)

Count total completions per habit

Ready for streak logic and reporting extensions

🗄 Database Design

Entity Description
User Represents application users
Habit User-defined habits
HabitEntry Daily completion records

Relationships:

One User → Many Habits

One Habit → Many HabitEntries

🛠 Tech Stack

Language C#
Framework ASP.NET Core Web API
ORM Entity Framework Core
Database SQL Server (Azure SQL compatible)
API Style RESTful
Architecture Clean layered architecture
DevOps Ready Docker & Azure deployable


📌 Example Endpoints
Method Endpoint Description
POST /api/users Create user
POST /api/habits Create habit
GET /api/habits/{userId} Get user habits
POST /api/habits/{habitId}/complete Mark habit complete
☁ Azure Readiness

This API is designed to be deployed using:

Azure App Service

Azure SQL Database

Azure DevOps CI/CD

Containerization via Docker

Planned Enhancements:

JWT Authentication

Habit streak tracking

Weekly/monthly analytics

Notifications system

Unit & integration tests

🧪 How to Run
``` 
dotnet restore
dotnet build
dotnet run
```

API runs at:

<https://localhost:5001>
