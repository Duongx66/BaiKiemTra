# PCM Frontend

This folder documents the frontend responsibilities for the PCM project.

What belongs here (current project uses Razor Views):
- Views/ (Razor views for pages and partials)
  - Views/Shared/_Layout.cshtml (layout/sidebar/header)
  - Views/Home, Views/Courts, Views/Members, Views/Bookings, Views/Matches, Views/Account
- wwwroot/ (static assets: css, js, lib)

Responsibilities:
- Page UI and client-side validation
- Static assets (Bootstrap, Font Awesome, JS)
- Razor view rendering (server-side) or client-side app if migrated to SPA

Run / dev notes:
- The current Razor views are served by the ASP.NET Core app. To develop UI:
```powershell
cd "PCM"
dotnet run
# open https://localhost:5001 or http://localhost:5000 depending on launch settings
```

Migration to a separate frontend app (optional):
- Move Views/ and wwwroot/ to a dedicated frontend repo (e.g., React/Vue/Angular or static site)
- Convert backend controllers to Web API endpoints returning JSON
- Configure CORS in backend (already present as `AllowAll` policy)

If you'd like, I can help scaffold a separate SPA frontend and convert the backend controllers to API endpoints.

Quick demo pages added:
- `Views/Courts/CourtBooking.cshtml` — giao diện đặt sân cầu lông (form date/time, kiểm tra lịch)
- `wwwroot/css/court.css` — styles cho trang đặt sân
- `wwwroot/js/court.js` — script kiểm tra tính khả dụng (mô phỏng)

Bạn có thể mở `PCM.api` (hoặc cấu hình để server tìm Views trong `PCM.web`) để kiểm thử trang này.
