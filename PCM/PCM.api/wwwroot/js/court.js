// Simple availability check (simulation)
document.addEventListener('DOMContentLoaded', function() {
    const checkBtn = document.getElementById('checkBtn');
    const availability = document.getElementById('availability');

    checkBtn?.addEventListener('click', function(e) {
        e.preventDefault();
        const date = document.getElementById('bookingDate')?.value;
        const start = parseInt(document.getElementById('startHour')?.value || '0');
        const end = parseInt(document.getElementById('endHour')?.value || '0');

        if (!date) {
            availability.style.display = 'block';
            availability.className = 'alert alert-danger';
            availability.textContent = 'Vui lòng chọn ngày.';
            return;
        }
        if (end <= start) {
            availability.style.display = 'block';
            availability.className = 'alert alert-danger';
            availability.textContent = 'Giờ kết thúc phải lớn hơn giờ bắt đầu.';
            return;
        }

        // Simulate check: mark weekends as busy for demo
        const d = new Date(date + 'T00:00:00');
        const dow = d.getDay();
        if (dow === 0 || dow === 6) {
            availability.style.display = 'block';
            availability.className = 'alert alert-warning';
            availability.textContent = 'Ngày bạn chọn có nhiều đặt trước, hãy chọn ngày khác.';
        } else {
            availability.style.display = 'block';
            availability.className = 'alert alert-success';
            availability.textContent = `Sẵn sàng: ${start}:00 - ${end}:00`;
        }
    });
});
