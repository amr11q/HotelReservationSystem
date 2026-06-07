using HotelReservationSystem.Reservations;
using HotelReservationSystem.Rooms;
using HotelReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Data
{
    public static class FileManager
    {
        public static void SaveRooms(Room[] rooms, int roomCount)
        {
            using (StreamWriter writer = new StreamWriter("rooms.txt"))
            {
                for (int i = 0; i < roomCount; i++)
                {
                    writer.WriteLine(
                        rooms[i].RoomID + "," +
                        rooms[i].RoomType + "," +
                        rooms[i].PricePerNight + "," +
                        rooms[i].Capacity + "," +
                        rooms[i].IsAvailable
                    );
                }
            }

        }

        public static void SaveCustomers(Customer[] customers, int customerCount)
        {
            using (StreamWriter writer = new StreamWriter("customers.txt"))
            {
                for (int i = 0; i < customerCount; i++)
                {
                    writer.WriteLine(
                                     customers[i].UserID + "," +
                                     customers[i].FullName + "," +
                                     customers[i].PhoneNumber + "," +
                                     customers[i].Email + "," +
                                     customers[i].PreferredRoomType + "," +
                                     customers[i].ReservationHistory
                                 );
                }
            }
        }

        public static void SaveReservations(Reservation[] reservations, int reservationCount)
        {
            using (StreamWriter writer = new StreamWriter("reservations.txt"))
            {
                for (int i = 0; i < reservationCount; i++)
                {
                    writer.WriteLine(
                        reservations[i].ReservationID + "," +
                        reservations[i].Customer.UserID + "," +
                        reservations[i].Room.RoomID + "," +
                        reservations[i].CheckInDate + "," +
                        reservations[i].CheckOutDate + "," +
                        reservations[i].TotalCost + "," +
                        reservations[i].ReservationStatus
                    );
                }
            }
        }

        public static void LoadRooms(Room[] rooms, ref int roomCount)
        {
            if (!File.Exists("rooms.txt"))
                return;

            string[] lines = File.ReadAllLines("rooms.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                int roomID = int.Parse(data[0]);
                string roomType = data[1];
                double price = double.Parse(data[2]);
                int capacity = int.Parse(data[3]);
                bool isAvailable = bool.Parse(data[4]);

                Room room;

                if (roomType == "Standard")
                {
                    room = new StandardRoom(roomID, roomType,price,isAvailable,capacity);
                }
                else
                {
                    room = new DeluxeRoom(roomID, roomType,price,isAvailable, capacity);
                }

                rooms[roomCount] = room;
                roomCount++;
            }
        }

        public static void LoadCustomers(Customer[] customers, ref int customerCount)
        {
            if (!File.Exists("customers.txt"))
                return;

            string[] lines = File.ReadAllLines("customers.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                int userID = int.Parse(data[0]);
                string fullName = data[1];
                string phoneNumber = data[2];
                string email = data[3];
                string preferredRoomType = data[4];
                string reservationHistory = data[5];

              customers[customerCount] = new Customer(userID,fullName,phoneNumber,email,preferredRoomType,reservationHistory );

                customerCount++;
            }
        }

        public static void LoadReservations(Reservation[] reservations, ref int reservationCount)
        {
            using (StreamWriter writer = new StreamWriter("reservations.txt"))
            {
                for (int i = 0; i < reservationCount; i++)
                {
                    writer.WriteLine(
                        reservations[i].ReservationID + "," +
                        reservations[i].Customer.UserID + "," +
                        reservations[i].Room.RoomID + "," +
                        reservations[i].CheckInDate + "," +
                        reservations[i].CheckOutDate + "," +
                        reservations[i].TotalCost + "," +
                        reservations[i].ReservationStatus
                    );
                }
            }
        }
    }
}
