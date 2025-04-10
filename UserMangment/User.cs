using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserMangment
{
    public enum UserRole
    {
        Guest,
        Member,
        Moderator,
        Admin
    }

    public class User
    {
        private static readonly Regex EmailRegex = new Regex(@"\A[A-Z0-9+_.-]+@[A-Z0-9.-]+\Z", RegexOptions.IgnoreCase);

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public UserRole Role { get; set; }
        public List<string> Permissions { get; set; }
        public bool IsActive { get; set; }

        public User()
        {
            Permissions = new List<string>();
            IsActive = false;
        }

        public bool Activate()
        {
            if (IsActive)
                return false;

            IsActive = true;
            return true;
        }

        public bool Deactivate()
        {
            if (!IsActive)
                return false;

            IsActive = false;
            return true;
        }

        public bool IsValidEmail()
        {
            return !string.IsNullOrEmpty(Email) && EmailRegex.IsMatch(Email);
        }

        public bool AddPermission(string permission)
        {
            if (string.IsNullOrEmpty(permission) || Permissions.Contains(permission))
                return false;

            Permissions.Add(permission);
            return true;
        }

        public bool RemovePermission(string permission)
        {
            return Permissions.Remove(permission);
        }

        public string GetUserInfo()
        {
            return $"UserID: {Id}, Username: {Username}, Email: {Email}";
        }

        public static bool IsAdultUser(User user)
        {
            return user != null && user.Age >= 18;
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (!EmailRegex.IsMatch(email))
                throw new ArgumentException("Invalid email format", nameof(email));

            Email = email;
        }


    }


}

