using Hotel_ReservationAndManagement.Repositories;
using Hotel_ReservationAndManagement.Rooms.Hotel_ReservationAndManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class RoomManager
    {
        private RoomRepository roomRepo;

        public RoomManager()
        {
            roomRepo = new RoomRepository();
        }

        public void CreateRoom(Room room)
        {
            roomRepo.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            roomRepo.UpdateRoom(room);
        }

        public void UpdateRoomStatus(int roomId, string status)
        {
            roomRepo.UpdateRoomStatus(roomId, status);
        }

        public List<Room> GetAvailableRooms(DateTime start, DateTime end)
        {
            return roomRepo.GetAvailableRooms(start, end);
        }
    }
}