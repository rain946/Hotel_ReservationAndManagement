using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Model
{
    public class FrontDeskStaff : User
    {
        public FrontDeskStaff(int userId, string username, string passwordHash, string fullName)
            : base(userId, username, passwordHash, fullName) { }

        public override string GetRole()
        {
            return "Front Desk Staff";
        }

        // Additional Front Desk-specific methods
        public void ProcessReservation() { }
        public void CheckInGuest() { }
        public void CheckOutGuest() { }
        public void AssignRoom() { }
    }
}