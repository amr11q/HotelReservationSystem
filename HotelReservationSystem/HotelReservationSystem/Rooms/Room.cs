using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Rooms
{
    public abstract class Room
    {
       
        private int roomID;
        private string roomType;
        private double pricePerNight;
        private bool isAvailable;
        private int capacity;

       
        public int RoomID
        {
            get { return roomID; }
            set
            {
                if (value > 0)
                {
                    roomID = value;
                }
                else 
                {
                    Console.WriteLine("Invalid Room ID. It must be greater than 0");
                }  
            }
        }

        public string RoomType
        {
            get { return roomType; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    roomType = value;
                }
                else 
                {
                    Console.WriteLine("Invalid Room Type. It cannot be null or empty");
                }  
            }
        }

        public double PricePerNight
        {
            get { return pricePerNight; }
            set
            {
                if (value > 0)
                {
                    pricePerNight = value;
                }
                else
                {
                    Console.WriteLine("Invalid Price. It must be greater than 0");
                }
            }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value > 0)
                {
                    capacity = value;
                }
                else 
                {
                    Console.WriteLine("Invalid Capacity. It must be greater than 0");
                }
            }
        }

        
        public Room(int roomID, string roomType,double pricePerNight,bool isAvailable,int capacity)
        {
            RoomID = roomID;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
            Capacity = capacity;
        }

        
        public abstract double CalculateTotalCost(int numberOfNights);

    }
}
