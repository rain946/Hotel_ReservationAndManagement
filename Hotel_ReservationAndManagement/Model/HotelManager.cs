using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Model
{
    public class HotelManager : User
    {
        public HotelManager(int userId, string username, string passwordHash, string fullName)
            : base(userId, username, passwordHash, fullName) { }

        public override string GetRole()
        {
            return "Hotel Manager";
        }

        // Additional manager-specific methods
        public void ConfigureRoomRates() { }
        public void ViewReports() { }
        public void ManageUsers() { }
    }
}