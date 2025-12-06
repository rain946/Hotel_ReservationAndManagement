using Hotel_ReservationAndManagement.Model;
using Hotel_ReservationAndManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class GuestManager
    {
        private GuestRepository guestRepo;

        public GuestManager()
        {
            guestRepo = new GuestRepository();
        }

        public Guest GetGuestByName(string fullName)
        {
            return guestRepo.GetGuestByName(fullName);
        }

        public void AddGuest(Guest guest)
        {
            guestRepo.AddGuest(guest);
        }

        public void UpdateGuest(Guest guest)
        {
            guestRepo.UpdateGuest(guest);
        }
    }
}
