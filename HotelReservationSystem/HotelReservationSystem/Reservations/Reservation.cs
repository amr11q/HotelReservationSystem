using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelReservationSystem.Rooms;
using HotelReservationSystem.Users;

namespace HotelReservationSystem.Reservations
{
    public class Reservation
    {
        
        private int reservationID;
        private Customer customer;
        private Room room;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private double totalCost;
        private string reservationStatus;
        

        public int ReservationID
        {
            get { return reservationID; }

            set
            {
                if (value > 0)
                {
                    reservationID = value;
                }
                else
                {
                    Console.WriteLine("Invalid Reservation ID");
                }
            }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }

        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }

        public double TotalCost
        {
            get { return totalCost; }

            set
            {
                if (value >= 0)
                {
                    totalCost = value;
                }
                else
                {
                    Console.WriteLine("Invalid Total Cost");
                }
            }
        }
       

        public string ReservationStatus
        {
            get { return reservationStatus; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    reservationStatus = value;
                }
                else
                {
                    Console.WriteLine("Invalid Reservation Status");
                }
            }
        }

       
        public Reservation(int reservationID,Customer customer,Room room,DateTime checkInDate,DateTime checkOutDate,double totalCost,string reservationStatus)
        {
            ReservationID = reservationID;
            Customer = customer;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalCost = totalCost;
            ReservationStatus = reservationStatus;
        
        }
    }
}
