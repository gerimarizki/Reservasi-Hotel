using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SilverCoastHotel
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }
        public string RoomType { get; set; }
        public decimal RoomCostPerNight { get; set; }
         
        public Dictionary<string, Guest> ListGuest { get; set; } = new Dictionary<string, Guest>();

        public Room(string roomNumber, string floorNumber, string roomType, decimal roomCostPerNight)
        {
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
            RoomType = roomType;
            RoomCostPerNight = roomCostPerNight;
        }

        public void AddGuest(Guest guest)
        {
            guest.Room = this;
            this.ListGuest.Add(guest.NomorRegister, guest);
        }
       
    }
}
