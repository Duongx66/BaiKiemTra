# PCM - Pickleball Club Management System

Hệ thống quản lý câu lạc bộ Pickleball toàn diện, hỗ trợ quản lý thành viên, đặt sân, tổ chức giải đấu và quản lý tài chính.

## 📋 Tổng quan

PCM (Pickleball Club Management) là một giải pháp quản lý câu lạc bộ thể thao chuyên nghiệp, được xây dựng với kiến trúc Full-stack hiện đại. Hệ thống giúp tự động hóa các quy trình quản lý, từ đặt sân, tổ chức thách đấu, theo dõi trận đấu đến quản lý tài chính câu lạc bộ.

## ✨ Tính năng chính

### 🏠 Dashboard
- Thống kê tổng quan: số lượng thành viên, giải đấu đang mở, tin tức
- Bảng xếp hạng top thành viên theo rank và tỷ lệ thắng
- Danh sách giải đấu sắp diễn ra
- Tin tức và thông báo quan trọng

### 👥 Quản lý thành viên
- Đăng ký và xác thực tài khoản (JWT Authentication)
- Quản lý thông tin cá nhân: họ tên, email, số điện thoại, ngày sinh
- Theo dõi xếp hạng cá nhân (Rank Level)
- Lịch sử thi đấu và thống kê (tổng trận, số trận thắng, tỷ lệ thắng)
- Danh sách thành viên với phân trang và tìm kiếm

### 🎾 Quản lý sân đấu
- Danh sách các sân đấu với mô tả chi tiết
- Trạng thái hoạt động của từng sân
- Xem lịch đặt sân theo tuần (Calendar View)
- Kiểm tra khung giờ còn trống

### 📅 Đặt sân
- Đặt sân trực tuyến với chọn ngày giờ linh hoạt
- Kiểm tra khung giờ khả dụng (Available Slots)
- Xem lịch sử đặt sân cá nhân
- Quản lý trạng thái booking: Confirmed, Pending, Cancelled
- Ghi chú cho mỗi lần đặt sân
- Xem lịch đặt sân toàn câu lạc bộ theo tuần

### 🏆 Giải đấu & Thách đấu
- Tạo và quản lý các giải đấu/thách đấu
- Phân loại theo loại hình: Tournament, FriendlyMatch, RankedMatch
- Cấu hình định dạng trận đấu: Singles (đơn), Doubles (đôi)
- Quản lý phí tham gia và giải thưởng
- Theo dõi số lượng người tham gia và trạng thái
- Trạng thái giải: Open, Ongoing, Completed, Cancelled
- Đăng ký tham gia và thanh toán phí tham gia
- Chọn đội và đối tác (cho doubles)

### 🎯 Quản lý trận đấu
- Ghi nhận kết quả trận đấu
- Hỗ trợ cả trận ranked và friendly
- Liên kết với giải đấu
- Xác định đội chiến thắng (Team1, Team2, Draw)
- Tự động cập nhật thống kê thành viên

### 💰 Quản lý tài chính
- Ví điện tử cho mỗi thành viên
- Lịch sử giao dịch chi tiết
- Phân loại thu chi theo danh mục:
  - Thu nhập: Phí thành viên, Phí đặt sân, Tài trợ, Tiền thưởng giải đấu, Thu khác
  - Chi phí: Mua thiết bị, Chi phí sân, Giải thưởng, Hoạt động CLB, Chi khác
- Báo cáo tài chính với phân trang
- Ghi chú người tạo và mô tả giao dịch

### 📰 Tin tức & Thông báo
- Đăng và quản lý tin tức câu lạc bộ
- Ghim tin quan trọng lên đầu
- Hình ảnh minh họa cho từng bài viết
- Phân trang và sắp xếp theo thời gian

## 🛠️ Công nghệ sử dụng

### Backend (PCM.Api)
- **Framework**: ASP.NET Core 8.0 (C# .NET)
- **ORM**: Entity Framework Core 8.0.4 (Code-First)
- **Database**: SQL Server (LocalDB hoặc SQL Server Express)
- **Authentication**: ASP.NET Core Identity với JWT Bearer Token
- **API/Web Style**: RESTful API + Razor Views (MVC)
- **Architecture**: Layered Architecture (Controllers, Data, Models, Services)

### Frontend (PCM.Web)
- **Framework**: ASP.NET Core Razor Views (MVC)
- **Styling**: Custom CSS/SCSS
- **UI**: Bootstrap + Font Awesome Icons
- **Interactivity**: Vanilla JavaScript
- **Hosting**: Integrated trong ASP.NET Core

### Database Tables
- `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles` - Quản lý xác thực
- `025_Members` - Thông tin thành viên
- `025_Courts` - Danh sách sân
- `025_Bookings` - Lịch đặt sân
- `025_Challenges` - Giải đấu/thách đấu
- `025_Participants` - Người tham gia giải đấu
- `025_Matches` - Trận đấu
- `025_WalletTransactions` - Giao dịch tài chính
- `025_News` - Tin tức

## 🚀 Hướng dẫn cài đặt

### Yêu cầu hệ thống
- .NET 8.0 SDK trở lên
- SQL Server 2019+ hoặc SQL Server Express
- Visual Studio Code hoặc Visual Studio 2022

### Cài đặt Backend

1. Clone repository và di chuyển vào thư mục backend
```bash
cd PCM
```

2. Cấu hình connection string

Mở file `PCM.api/appsettings.json` và cập nhật connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=PCM_DB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

3. Restore packages
```bash
cd PCM.api
dotnet restore
```

4. Chạy migrations để tạo database
```bash
dotnet ef database update
```

5. Chạy backend server
```bash
dotnet run
```

Backend sẽ chạy tại: `http://localhost:5000`

### Cài đặt Frontend

Frontend được tích hợp sẵn trong ASP.NET Core, không cần cài đặt riêng biệt.

## 🚢 Docker (Quick deploy)

1. Copy `.env.example` to `.env` và thiết lập `SA_PASSWORD` (password mạnh):
```bash
cp .env.example .env
```

2. Build và chạy với Docker Compose (tại root directory):
```bash
docker compose build
docker compose up -d
```

3. API sẽ có sẵn tại `http://localhost:8080` (hoặc `http://<server-ip>:8080`)

4. Để dừng và xóa containers & volumes:
```bash
docker compose down -v
```

**Ghi chú:**
- Trên DigitalOcean Droplet, mở port `8080` trong firewall hoặc sử dụng Nginx làm reverse proxy và lấy SSL với Certbot
- Không commit `.env` vào source control; giữ `SA_PASSWORD` bí mật

## VPS / Droplet deploy (DigitalOcean)

Bạn có thể chạy script `deploy-do.sh` trên Droplet của bạn để cài đặt Docker, clone repo, và khởi động stack.

1. Upload hoặc đặt `deploy-do.sh` trên Droplet và làm cho nó có thể thực thi:
```bash
cd /root
curl -O <raw-url-to-repo>/deploy-do.sh
chmod +x deploy-do.sh
```

2. Tạo file `.env` với `SA_PASSWORD` an toàn (hoặc đặt nó tại `/root/.env`):
```bash
cp .env.example .env
nano .env  # edit .env và thiết lập SA_PASSWORD
```

3. Chạy deploy script (tùy chọn ghi đè `REPO_URL` và `APP_DIR`):
```bash
REPO_URL=https://github.com/your-username/your-repo.git APP_DIR=/opt/pcm
./deploy-do.sh
```

4. Sử dụng `docker compose ps` và `docker compose logs -f api` để xác minh API

5. (Tùy chọn) Sử dụng cấu hình Nginx mẫu tại `deploy/nginx-pcm.conf` để tạo một trang Nginx và lấy SSL qua Certbot

## 📊 Dữ liệu mẫu

Hệ thống tự động tạo dữ liệu mẫu khi khởi động lần đầu:

- **Admin account**: `admin@pcm.com` / `Admin@123`
- **25 thành viên mẫu**: `member1@pcm.com` đến `member25@pcm.com` / `Member@123`
- **3 sân đấu**: Sân 1, Sân 2, Sân 3
- **8 lượt đặt sân** với thời gian khác nhau
- **5 giải đấu** với trạng thái Open và Ongoing
- **10 trận đấu** với kết quả mẫu
- **4 giao dịch tài chính** (thu/chi)
- **2 bài tin tức**

## 🔐 Xác thực và Phân quyền

Hệ thống sử dụng JWT Authentication với 2 vai trò:
- **Admin**: Quản lý toàn bộ hệ thống
- **Member**: Thành viên câu lạc bộ

### API Endpoints chính

#### Authentication
- `POST /api/auth/register` - Đăng ký tài khoản mới
- `POST /api/auth/login` - Đăng nhập

#### Members
- `GET /api/members` - Danh sách thành viên (phân trang)
- `GET /api/members/{id}` - Chi tiết thành viên
- `GET /api/members/leaderboard` - Bảng xếp hạng

#### Courts
- `GET /api/courts` - Danh sách sân

#### Bookings
- `POST /api/bookings` - Tạo booking mới
- `GET /api/bookings` - Danh sách tất cả booking
- `GET /api/bookings/my-bookings` - Booking của tôi
- `GET /api/bookings/available-slots` - Khung giờ còn trống
- `GET /api/bookings/calendar` - Lịch đặt sân theo tuần

#### Challenges
- `GET /api/challenges` - Danh sách giải đấu
- `POST /api/challenges` - Tạo giải đấu mới
- `POST /api/challenges/{id}/join` - Tham gia giải đấu

#### Matches
- `GET /api/matches` - Danh sách trận đấu
- `POST /api/matches` - Ghi nhận trận đấu mới

#### Transactions
- `GET /api/transactions` - Lịch sử giao dịch
- `POST /api/transactions` - Tạo giao dịch mới
- `GET /api/transaction-categories` - Danh mục thu chi

#### News
- `GET /api/news` - Danh sách tin tức
- `GET /api/news/{id}` - Chi tiết tin tức
- `POST /api/news` - Đăng tin tức mới

## 📁 Cấu trúc thư mục

```
kiemtra/
├── PCM/
│   ├── PCM.api/
│   │   ├── Controllers/        # MVC Controllers
│   │   │   ├── AccountController.cs
│   │   │   ├── ChallengesController.cs
│   │   │   ├── TransactionsController.cs
│   │   │   ├── NewsController.cs
│   │   │   ├── DashboardController.cs
│   │   │   └── ...
│   │   ├── Data/              # DbContext & Database
│   │   │   ├── ApplicationDbContext.cs
│   │   │   └── DbInitializer.cs
│   │   ├── Models/            # Domain Models
│   │   │   ├── _999_Court.cs
│   │   │   ├── _999_Member.cs
│   │   │   ├── _999_Booking.cs
│   │   │   ├── _999_Challenge.cs
│   │   │   ├── _999_Participant.cs
│   │   │   ├── _999_Match.cs
│   │   │   ├── _999_Transaction.cs
│   │   │   └── _999_News.cs
│   │   ├── Migrations/        # EF Core Migrations
│   │   ├── Services/          # Business Logic
│   │   ├── Program.cs         # Entry point
│   │   └── appsettings.json
│   │
│   ├── PCM.web/
│   │   ├── Views/             # Razor Views
│   │   │   ├── Account/
│   │   │   ├── Challenges/
│   │   │   ├── Transactions/
│   │   │   ├── News/
│   │   │   ├── Dashboard/
│   │   │   ├── Shared/        # _Layout.cshtml
│   │   │   └── ...
│   │   └── wwwroot/           # Static files (CSS, JS, images)
│   │
│   ├── PCM.sln
│   └── SEPARATION.md
│
└── README.md
```

## 🐛 Troubleshooting

### Backend không kết nối được database
- Kiểm tra SQL Server đã chạy chưa
- Xác nhận connection string trong `appsettings.json`
- Chạy lại `dotnet ef database update`

### Frontend không gọi được API
- Kiểm tra backend đã chạy ở port 5003
- Xem lại cấu hình CORS trong `Program.cs`
- Kiểm tra API_BASE_URL trong `app.config.js`

### Lỗi Authentication
- Xóa token cũ trong localStorage
- Đăng nhập lại
- Kiểm tra JWT configuration trong backend

## 📝 Ghi chú Migration

Hệ thống sử dụng Entity Framework Code-First Migrations. Các migration files:

- `InitIdentity` - Tạo bảng Identity
- `AddCoreTables` - Tạo bảng Members, Courts, Bookings
- `AddChallenges` - Thêm bảng Challenges và Participants
- `FixParticipantCascade` - Fix cascading delete
- `AddWalletRelation` - Thêm quan hệ Wallet
- `AddPrizeAndStatus` - Thêm trường Prize và Status
- `AddMatchesTable` - Tạo bảng Matches

## 👨‍💻 Phát triển thêm

### Tính năng có thể mở rộng
- Chat/Messaging giữa thành viên
- Booking recurring (đặt sân định kỳ)
- Payment gateway integration
- Mobile app (React Native/Flutter)
- Email notifications
- Báo cáo và thống kê nâng cao
- Tournament bracket visualization
- Live scoring system

## 📄 License

Dự án này được phát triển cho mục đích học tập và nghiên cứu.

## 📧 Liên hệ

Nếu có câu hỏi hoặc góp ý, vui lòng liên hệ qua email hoặc tạo issue trên repository.

---

**Phiên bản**: 1.0.0  
**Ngày cập nhật**: 31/01/2026