# PCM: Backend / Frontend separation notes

This file describes how the existing project maps to backend vs frontend responsibilities, and next steps to fully separate them if desired.

## Current mapping (in-repo)

- Backend (handled by `PCM` ASP.NET project):
  - `Program.cs` (startup, services)
  - `Data/ApplicationDbContext.cs` (EF Core DbContext + OnModelCreating)
  - `Controllers/` (business logic + routing)
  - `Models/` (entities and view models)
  - `Migrations/` (EF migrations)
  - `Services/` (DbSeeder and other backend helpers)
  - `appsettings.json` (connection string)

- Frontend (server-rendered Razor views and static assets):
  - `Views/` (Razor pages: `Home`, `Courts`, `Members`, `Bookings`, `Matches`, `Account`)
  - `Views/Shared/_Layout.cshtml` (layout and sidebar)
  - `wwwroot/` (css, js, libraries)

## What I created
- `PCM/backend/README.md` — describes backend responsibilities and run steps
- `PCM/frontend/README.md` — describes frontend responsibilities and run steps

## Next steps to fully separate (options)

Option A — Keep server-rendered frontend (no separation):
- Leave as-is; continue developing in single project.

Option B — Split to API backend + SPA frontend:
1. Create a new project `PCM.Api` (ASP.NET Core Web API) and move `Controllers/`, `Data/`, `Models/`, `Migrations/`, `Services/` to it.
2. Keep or remove Identity depending on auth strategy; if keeping, configure Identity in API and expose token-based auth endpoints.
3. Create a new frontend project (e.g., `pcm-frontend` using React/Vue/Angular) and move `Views/` UI into it or rebuild UI as SPA.
4. Configure CORS in API (a permissive policy exists already) and update `appsettings.json` / CI accordingly.

Option C — Minimal split (serve static frontend separately but keep server-rendered views):
- Copy `wwwroot/` and `Views/Shared` assets into a separate static site if needed and let backend provide JSON endpoints.

If you want, I can:
- Scaffold `PCM.Api` (Web API) and update controllers to return JSON.
- Scaffold a React-based frontend and port the Views to components.
- Or just update the top-level `README.md` to link the new backend/frontend READMEs (I can do that next).

Tell me which option you prefer and I will continue (I can update the top-level README or start scaffolding the split).