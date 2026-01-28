namespace QLCafe.Shared
{
    public static class SessionManager
    {
        // Lưu tên đăng nhập thực tế (phải khớp với cột TenDangNhap trong DB)
        // Mặc định để 'thukho1' để bạn test vì tài khoản này đã có trong script SQL của bạn.
        public static string UserName { get; set; } = "thukho1";

        public static string DisplayName { get; set; }
        public static int UserRole { get; set; }
    }
}