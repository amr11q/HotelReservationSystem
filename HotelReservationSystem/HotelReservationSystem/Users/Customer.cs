using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Users
{
    public class Customer : User
    {
      
        private string preferredRoomType;
        private string reservationHistory;



       
        public Customer(int userID,string fullName,string phoneNumber,string email,string preferredRoomType,string reservationHistory)
         : base(userID, fullName, phoneNumber, email)
        {
            PreferredRoomType = preferredRoomType;
            ReservationHistory = reservationHistory;
        }
      
        public string PreferredRoomType
        {
            get { return preferredRoomType; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    preferredRoomType = value;
                }
                else
                {
                    Console.WriteLine("Invalid Preferred Room Type");
                }
            }
        }

        public string ReservationHistory
        {
            get { return reservationHistory; }

            set
            {
                reservationHistory = value;
            }
        }

       
    }
}
