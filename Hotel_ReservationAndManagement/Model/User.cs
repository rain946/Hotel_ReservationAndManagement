using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Model
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }

        // Constructor
        protected User(int userId, string username, string passwordHash, string fullName)
        {
            UserId = userId;
            Username = username;
            PasswordHash = passwordHash;
            FullName = fullName;
        }

        // Abstract method for role info
        public abstract string GetRole();
    }
}
