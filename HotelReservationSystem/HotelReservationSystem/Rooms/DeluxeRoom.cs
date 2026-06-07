using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Rooms
{
    internal class DeluxeRoom : Room
    {
        public DeluxeRoom(int roomID,string roomType,double pricePerNight,bool isAvailable, int capacity)
          : base(roomID, roomType, pricePerNight,isAvailable, capacity)
        {


        }

        public override double CalculateTotalCost(int numberOfNights)
        {
            double totalCost = PricePerNight * numberOfNights;

         
            totalCost += 500;

          
            if (numberOfNights > 5)
            {
                totalCost *= 0.9;
            }

            return totalCost;
        }
    }
}
