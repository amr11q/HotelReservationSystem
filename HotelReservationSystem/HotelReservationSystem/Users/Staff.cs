using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Users
{
    internal class Staff : User
    {

        public Staff(int userID,
                    string fullName,
                    string phoneNumber,
                    string email)

           : base(userID, fullName, phoneNumber, email)
        {
        }

        public void AddRoom()
        {
            Console.WriteLine("Room Added Successfully");
        }

        public void RemoveRoom()
        {
            Console.WriteLine("Room Removed Successfully");
        }
    }
}
