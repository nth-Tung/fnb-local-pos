using System;

namespace POS.UI.Session
{
    public enum UserRole
    {
        Cashier = 1, // Thu ngân (Chỉ vào POS bán hàng)
        Admin = 2    // Quản lý / Quản trị viên (Toàn quyền Back-Office và POS)
    }

    public class UserSession
    {
        private static UserSession _current;

        public static UserSession Current => _current ?? (_current = new UserSession());

        public int UserId { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = "Khách";
        public UserRole Role { get; set; } = UserRole.Cashier;
        public DateTime LoginTime { get; set; } = DateTime.MinValue;
        public bool IsLoggedIn => UserId > 0;

        private UserSession() { }

        public void Login(int userId, string username, string fullName, UserRole role)
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
            Role = role;
            LoginTime = DateTime.Now;
        }

        public void Logout()
        {
            UserId = 0;
            Username = string.Empty;
            FullName = "Khách";
            Role = UserRole.Cashier;
            LoginTime = DateTime.MinValue;
        }
    }
}
