# PCM - Pickleball Club Management System

## 📋 Tổng quan

PCM (Pickleball Club Management) là một giải pháp quản lý câu lạc bộ thể thao chuyên nghiệp, được xây dựng với kiến trúc **ASP.NET Core MVC** hiện đại. Hệ thống giúp tự động hóa các quy trình quản lý, từ đặt sân, tổ chức thách đấu, theo dõi trận đấu đến quản lý tài chính câu lạc bộ.

**Hệ thống được phát triển cho CLB Cầu Lông PCM - Vợt Thủ Phố Núi.**

---

## ✨ Tính năng chính

### 🏠 Dashboard
- **Thống kê tổng quan**: Số lượng sân, thành viên, đặt lịch, trận đấu
- **Bảng xếp hạng**: Top thành viên theo tỷ lệ thắng (WinRate)
- **Danh sách giải đấu**: Các giải đấu sắp diễn ra
- **Tin tức và thông báo**: Bảng tin quan trọng

### 👥 Quản lý thành viên
- Đăng ký và xác thực tài khoản (ASP.NET Core Identity)
- Quản lý thông tin cá nhân: họ tên, email, số điện thoại
- Theo dõi xếp hạng cá nhân dựa trên tỷ lệ thắng
- Lịch sử thi đấu và thống kê (tổng trận, số trận thắng, WinRate)
- Danh sách thành viên với tìm kiếm và phân trang

### 🎾 Quản lý sân đấu
- Danh sách các sân đấu với thông tin chi tiết
- Trạng thái hoạt động của từng sân
- Quản lý (CRUD) sân bởi admin
- Ghi chú và đặc điểm riêng của từng sân

### 📅 Đặt sân
- Đặt sân trực tuyến với chọn ngày giờ linh hoạt
- Kiểm tra trùng lịch tự động
- Lịch sử đặt sân cá nhân
- Quản lý trạng thái: Confirmed, Pending, Cancelled
- Ghi chú cho mỗi lần đặt sân

### 🏆 Giải đấu & Thách đấu
- Tạo và quản lý các giải đấu/thách đấu
- Phân loại theo loại hình:
  - **Tournament**: Giải đấu chính thức
  - **FriendlyMatch**: Trận giao hữu
  - **RankedMatch**: Trận ranked
- Cấu hình định dạng: **Singles** (đơn), **Doubles** (đôi)
- Quản lý phí tham gia và giải thưởng
- Theo dõi số lượng người tham gia và trạng thái
- Trạng thái giải: Open, Ongoing, Completed, Cancelled
- Đăng ký tham gia giải đấu

### 🎯 Quản lý trận đấu
- Ghi nhận kết quả trận đấu
- Hỗ trợ cả trận ranked và friendly
- Liên kết với giải đấu
- Xác định đội chiến thắng (Team1, Team2, Draw)
- Tự động cập nhật thống kê thành viên

### 💰 Quản lý tài chính
- Lịch sử giao dịch chi tiết
- Phân loại thu chi theo danh mục:
  - **Thu nhập**: Phí thành viên, Phí đặt sân, Tài trợ, Tiền thưởng giải đấu, Thu khác
  - **Chi phí**: Mua thiết bị, Chi phí sân, Giải thưởng, Hoạt động CLB, Chi khác
- Báo cáo tài chính với phân trang
- Ghi chú người tạo và mô tả giao dịch

### 📰 Tin tức & Thông báo
- Đăng và quản lý tin tức câu lạc bộ
- Ghim tin quan trọng lên đầu
- Hình ảnh minh họa cho từng bài viết
- Phân trang và sắp xếp theo thời gian

---

## 🛠️ Công nghệ sử dụng

### Backend (PCM.Api)
- **Framework**: ASP.NET Core 10.0 (C# .NET)
- **ORM**: Entity Framework Core 10.0.2 (Code-First)
- **Database**: SQL Server 2019+ hoặc SQL Server Express
- **Authentication**: ASP.NET Core Identity
- **Architecture**: Layered Architecture
  - Controllers
  - Data (DbContext, Migrations)
  - Models (Domain Models)
  - Services (Business Logic)
  - Views (Razor Templates)

### Frontend
- **Engine**: Razor Views (ASP.NET Core MVC)
- **UI Framework**: Bootstrap 5.3.2
- **Icons**: Font Awesome 6.0.0
- **Styling**: Custom CSS with Gradient Themes
- **Interactivity**: Vanilla JavaScript + Bootstrap JS

### Database Tables
- `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles` - Quản lý xác thực
- `_999_Member` - Thông tin thành viên
- `_999_Court` - Danh sách sân
- `_999_Booking` - Lịch đặt sân
- `_999_Challenge` - Giải đấu/thách đấu
- `_999_Participant` - Người tham gia giải đấu
- `_999_Match` - Trận đấu
- `_999_Transaction` - Giao dịch tài chính
- `_999_News` - Tin tức

---

## 🚀 Hướng dẫn cài đặt

### Yêu cầu hệ thống
- **.NET 10.0 SDK** trở lên
- **SQL Server 2019+** hoặc SQL Server Express
- **Visual Studio Code** hoặc **Visual Studio 2022**

### Cài đặt Backend

#### 1. Clone repository
```bash
git clone https://github.com/your-username/PCM.git
cd PCM/PCM.api
```

#### 2. Cấu hình Connection String
Mở file `appsettings.json` và cập nhật:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=PCM_DB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

#### 3. Restore Packages
```bash
dotnet restore
```

#### 4. Chạy Migrations
```bash
dotnet ef database update
```

#### 5. Chạy Backend Server
```bash
dotnet run
```
Backend sẽ chạy tại: `http://localhost:5000`

---

## 📊 Dữ liệu mẫu

Hệ thống tự động tạo dữ liệu mẫu khi khởi động lần đầu:

- **Admin**: `admin@pcm.com` / `Admin@123`
- **Member**: `user@pcm.com` / `User@123`
- **3 sân đấu**: Sân 1, Sân 2, Sân 3
- **5 giải đấu**: Với trạng thái Open và Ongoing
- **10 trận đấu**: Với kết quả mẫu
- **4 giao dịch tài chính**: Thu/chi mẫu
- **2 bài tin tức**: Tin tức mẫu

---

## 🔐 Xác thực và Phân quyền

Hệ thống sử dụng **ASP.NET Core Identity** với 2 vai trò:

- **Admin**: Quản lý toàn bộ hệ thống
  - Quản lý sân đấu
  - Quản lý tài chính
  - Quản lý tin tức
  - Xem báo cáo

- **Member**: Thành viên câu lạc bộ
  - Xem danh sách sân
  - Đặt sân
  - Tham gia giải đấu
  - Xem bảng xếp hạng
  - Xem tin tức

### Main Controllers

| Endpoint | Mô tả |
|----------|------|
| `/` | Trang chủ/Dashboard |
| `/Account/Login` | Đăng nhập |
| `/Account/Register` | Đăng ký |
| `/Challenges` | Danh sách giải đấu |
| `/Challenges/Details/{id}` | Chi tiết giải đấu |
| `/Challenges/Create` | Tạo giải đấu (Admin) |
| `/Transactions` | Quản lý tài chính |
| `/News` | Tin tức |
| `/Dashboard/Leaderboard` | Bảng xếp hạng |

---

## 📁 Cấu trúc thư mục

```
kiemtra/
├── PCM/
│   ├── PCM.api/
│   │   ├── Controllers/        # API Controllers
│   │   │   ├── AccountController.cs
│   │   │   ├── ChallengesController.cs
│   │   │   ├── TransactionsController.cs
│   │   │   ├── NewsController.cs
│   │   │   ├── DashboardController.cs
│   │   │   └── ...
│   │   ├── Data/              # DbContext & Initializer
│   │   │   ├── ApplicationDbContext.cs
│   │   │   └── DbSeeder.cs
│   │   ├── Models/            # Domain Models
│   │   │   ├── _999_Court.cs
│   │   │   ├── _999_Member.cs
│   │   │   ├── _999_Booking.cs
│   │   │   ├── _999_Challenge.cs
│   │   │   ├── _999_Participant.cs
│   │   │   ├── _999_Match.cs
│   │   │   ├── _999_Transaction.cs
│   │   │   ├── _999_News.cs
│   │   │   └── ...
│   │   ├── Migrations/        # EF Core Migrations
│   │   ├── Services/          # Business Logic
│   │   ├── Views/             # Razor Templates
│   │   │   ├── Account/
│   │   │   ├── Challenges/
│   │   │   ├── Transactions/
│   │   │   ├── News/
│   │   │   ├── Dashboard/
│   │   │   ├── Shared/        # _Layout.cshtml, _Navigation
│   │   │   └── ...
│   │   ├── wwwroot/           # Static files
│   │   ├── Properties/
│   │   ├── Program.cs         # Entry point
│   │   └── appsettings.json
│   │
│   ├── PCM.sln
│   └── README.md
│
└── README.md
```

---

## 🔍 Models & Relationships

### Entity Relationships
```
Member (1) ──────── (*) Booking
Member (1) ──────── (*) Participant
Member (1) ──────── (*) Match
Member (1) ──────── (*) Transaction
Member (1) ──────── (*) News (Author)

Court (1) ──────── (*) Booking

Challenge (1) ──────── (*) Participant
Participant (1) ──── (*) Match

User (1:1) ──────── Member
```

---

## 🌐 Giao diện & UX

### Trang Login/Register
- **Modern Gradient Design**: Purple-to-Pink gradient background
- **Glassmorphism Effect**: Semi-transparent cards với blur backdrop
- **Animations**: Smooth slide-in, bounce-in, ripple effects
- **Password Strength Meter**: Real-time password validation
- **Responsive**: Hoạt động tốt trên mobile & desktop

### Navigation
- **Sidebar Navigation**: Collapsible menu
- **Role-based Links**: Menu thay đổi theo quyền
- **Icons**: Font Awesome icons cho mỗi section
- **Active State**: Highlight section hiện tại

### Cards & Components
- **Dashboard Cards**: Thống kê với icons
- **Challenge Cards**: Hiển thị thông tin giải đấu
- **Responsive Tables**: Phân trang, tìm kiếm
- **Form Validation**: Real-time validation feedback

---

## 🐛 Troubleshooting

### Backend không kết nối được database
- Kiểm tra SQL Server đã chạy chưa
- Xác nhận connection string trong `appsettings.json`
- Chạy lại `dotnet ef database update`
- Kiểm tra quyền truy cập database

### Trang Login/Register lỗi CSS
- Xóa cache browser (Ctrl+Shift+Delete)
- Kiểm tra file CSS tải bình thường
- Reload lại trang (Ctrl+F5)

### Không thể tham gia giải đấu
- Kiểm tra đã đăng nhập chưa
- Kiểm tra user có quyền (phải là Member)
- Xem logs backend để debug

### Dữ liệu không hiển thị
- Kiểm tra migrations đã chạy xong
- Xác nhận seed data đã được tạo
- Kiểm tra Include relationships trong Controller

---

## 📝 Ghi chú Migration

Hệ thống sử dụng **Entity Framework Code-First Migrations**. Các migration files chính:

| Migration | Mô tả |
|-----------|------|
| `InitIdentity` | Tạo bảng ASP.NET Core Identity |
| `InitPCM` / `InitDB` | Tạo bảng Members, Courts, Bookings |
| `AddMatches` | Thêm bảng Matches |
| `AddChallengesTransactionsNews` | Thêm Challenges, Participants, Transactions, News |
| `UpdateMemberSchema` | Cập nhật schema Member |
| `AddIdentitySchema` | Cập nhật Identity schema |

---

## 👨‍💻 Phát triển thêm

### Tính năng có thể mở rộng
- [ ] Chat/Messaging giữa thành viên
- [ ] Booking recurring (đặt sân định kỳ)
- [ ] Payment gateway integration (VNPay, Stripe)
- [ ] Mobile app (React Native/Flutter)
- [ ] Email notifications
- [ ] Báo cáo và thống kê nâng cao
- [ ] Tournament bracket visualization
- [ ] Live scoring system
- [ ] Attendance tracking
- [ ] Skill level ranking

### Best Practices
1. Luôn sử dụng `[Authorize]` attribute cho protected endpoints
2. Validate input ở client-side và server-side
3. Log lỗi và important events
4. Sử dụng async/await cho database operations
5. Tạo migrations khi thay đổi Models
6. Test các workflows chính trước khi deploy

---

## 📧 Liên hệ & Hỗ trợ

Nếu có câu hỏi hoặc góp ý, vui lòng:
- Tạo Issue trên GitHub
- Gửi email cho admin
- Liên hệ trực tiếp với team phát triển

---

## 📄 License

Dự án này được phát triển cho mục đích quản lý CLB Cầu Lông PCM.

---

## 📊 Project Status

- **Version**: 1.0.0
- **Last Updated**: 31/01/2026
- **Status**: Active Development 🚀
- **Build**: ✅ Success (0 errors)
- **Database**: ✅ Applied (9 migrations)

---

**Made with ❤️ for PCM Badminton Club**

### Cách chạy

1. Cài đặt .NET 10.0 SDK
2. Cập nhật connection string trong `appsettings.json`
3. Chạy lệnh:
   ```bash
   dotnet build
   dotnet run
   ```
4. Truy cập http://localhost:5000

### Database

Dự án sử dụng SQL Server. Connection string mặc định:
```
Server=DESKTOP-AMH5GRG\\SQLEXPRESS;Database=PCM_DB;Trusted_Connection=True;TrustServerCertificate=True;
```

Dữ liệu mẫu sẽ được seed tự động khi chạy lần đầu.

### Lưu ý

- Dự án có thể chạy với hoặc không có authentication tùy chỉnh
- UI được thiết kế responsive và thân thiện với người dùng
- Validation được thực hiện ở cả client và server side