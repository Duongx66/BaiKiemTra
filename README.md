# BaiKiemTra - Hệ thống quản lý CLB Cầu Lông PCM

## Mô tả dự án

Đây là một ứng dụng web ASP.NET Core MVC để quản lý hệ thống đặt lịch sân cầu lông cho CLB PCM. Dự án bao gồm các chức năng chính sau:

### Tính năng chính

1. **Quản lý Sân cầu lông**
   - Thêm, sửa, xóa thông tin sân
   - Hiển thị danh sách sân với trạng thái hoạt động
   - Tự động tạo số thứ tự cho sân mới

2. **Quản lý Hội viên**
   - Thêm, sửa, xóa thông tin hội viên
   - Danh sách hội viên với tên đầy đủ

3. **Đặt lịch**
   - Đặt lịch sân với thông tin hội viên
   - Kiểm tra trùng lịch tự động
   - Tạo sân/hội viên mới nếu chưa tồn tại
   - Hiển thị danh sách đặt lịch

4. **Giao diện người dùng**
   - Giao diện chuyên nghiệp với Bootstrap 5
   - Font Awesome icons
   - Responsive design
   - Sidebar navigation
   - Dashboard với thống kê

### Công nghệ sử dụng

- **Backend**: ASP.NET Core MVC (.NET 10.0)
- **Database**: SQL Server với Entity Framework Core
- **Frontend**: Razor Views, Bootstrap 5, Font Awesome
- **Authentication**: ASP.NET Core Identity (có thể bật/tắt)

### Cấu trúc dự án

```
PCM/
├── Controllers/          # Controllers cho Courts, Members, Bookings
├── Data/                 # ApplicationDbContext
├── Models/               # Entity models (_999_Court, _999_Member, _999_Booking)
├── Views/                # Razor views
├── Services/             # DbSeeder
├── wwwroot/              # Static files (CSS, JS)
└── Properties/           # launchSettings.json
```

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