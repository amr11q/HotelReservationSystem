using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Users
{
    public  abstract class User
    {
       
        private int userID;
        private string fullName;
        private string phoneNumber;
        private string email;



        public User(int userID,string fullName,string phoneNumber,string email)
        {
            UserID = userID;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        
        public int UserID
        {
            get { return userID; }

            set
            {
                if (value > 0)
                {
                    userID = value;
                }
                else
                {
                    Console.WriteLine("Invalid User ID");
                }
            }
        }

        public string FullName
        {
            get { return fullName; }

            set{fullName = value;}
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    phoneNumber = value;
                }
                else
                {
                    Console.WriteLine("Invalid Phone Number");
                }
            }
        }

        public string Email
        {
            get { return email; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Contains("@"))
                {
                    email = value;
                }
                else
                {
                    Console.WriteLine("Invalid Email");
                }
            }
        }

       
       


    }
}
