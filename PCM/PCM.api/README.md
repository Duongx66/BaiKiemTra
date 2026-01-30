# PCM Backend

This folder documents the backend responsibilities for the PCM project (ASP.NET Core server).

What belongs here (current project):
- Program.cs (app startup, middleware)
- Data/ApplicationDbContext.cs (EF Core DbContext, DbSets)
- Controllers/ (API/MVC controllers: CourtsController, MembersController, BookingsController, MatchesController, AccountController, HomeController)
- Models/ (entities: _999_Court, _999_Member, _999_Booking, _999_Match, view models)
- Migrations/ (EF Core migrations)
- Services/ (DbSeeder, other backend services)

Responsibilities:
- Database access and schema (EF Core + migrations)
- Business logic and validation (Controllers, Services)
- Authentication/authorization (ASP.NET Identity)
- Expose endpoints consumed by frontend (Razor views or external SPA)

How to run locally (from `PCM` folder):
```powershell
cd "PCM"
dotnet build
dotnet ef database update
dotnet run
```

Notes:
- Currently the project is a single ASP.NET Core MVC app that contains both backend and Razor-based frontend. The README files define how to split responsibilities for future separation into a dedicated API backend and a separate frontend app.
