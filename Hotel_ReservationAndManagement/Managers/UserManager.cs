using Hotel_ReservationAndManagement.Model;
using Hotel_ReservationAndManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class UserManager
    {
        private UserRepository userRepo;

        public UserManager()
        {
            userRepo = new UserRepository();
        }

        public User Login(string username, string passwordHash)
        {
            // Basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordHash))
                return null;

            return userRepo.Login(username, passwordHash);
        }

        public User GetUserById(int userId)
        {
            return userRepo.GetUserById(userId);
        }
    }
}