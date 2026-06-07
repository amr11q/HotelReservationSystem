using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Rooms
{
     class StandardRoom : Room
    {
        public StandardRoom(int roomID, string roomType,double pricePerNight,bool isAvailable,int capacity)
            : base(roomID, roomType, pricePerNight,isAvailable, capacity)
        {



        }

        public override double CalculateTotalCost(int numberOfNights)
        {
            return PricePerNight * numberOfNights;
        }
    }
}
