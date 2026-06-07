using HotelReservationSystem.Rooms;
using HotelReservationSystem.Users;
using HotelReservationSystem.Payments;
using HotelReservationSystem.Reservations;

namespace HotelReservationSystem
{
    internal class Program
    {
        static Room[] rooms = new Room[100];
        static int roomCount = 0;

        static Customer[] customers = new Customer[100];
        static int customerCount = 0;

        static Reservation[] reservations = new Reservation[100];
        static int reservationCount = 0;



    
            static void Main(string[] args)
            {
                int choice;

                do
                {
                    Console.WriteLine("\n===== Hotel Reservation System =====");
                    Console.WriteLine("1. Add Room");
                    Console.WriteLine("2. Display Rooms");
                    Console.WriteLine("3. Add Customer");
                    Console.WriteLine("4. Search Available Rooms");
                    Console.WriteLine("5. Book Reservation");
                    Console.WriteLine("6. Modify Reservation");
                    Console.WriteLine("7. Cancel Reservation");
                    Console.WriteLine("8. Process Payment");
                    Console.WriteLine("9. Generate Receipt");
                    Console.WriteLine("10. Exit");

                    Console.Write("Enter Choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddRoom();
                            break;

                        case 2:
                            DisplayRooms();
                            break;

                        case 3:
                            AddCustomer();
                            break;

                        case 4:
                            SearchRoom();
                            break;

                        case 5:
                            MakeReservation();
                            break;

                        case 6:
                            ModifyReservation();
                            break;

                        case 7:
                            CancelReservation();
                            break;

                        case 8:
                            ProcessPayment();
                            break;

                        case 9:
                            GenerateReceipt();
                            break;

                        case 10:
                            Console.WriteLine("Good Bye");
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }

                } while (choice != 10);



            // add room

            static void AddRoom()
            {
                Console.Write("Enter Room ID: ");
                int roomID;
                while (!int.TryParse(Console.ReadLine(), out roomID))
                {
                    Console.Write("Invalid Input, Enter Again: ");
                }

                bool exists = false;
                for (int i = 0; i < roomCount; i++)
                {
                    if (rooms[i].RoomID == roomID)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    Console.WriteLine("Room ID Already Exists!");
                    return;
                }


                int choice;
                do
                {
                    Console.WriteLine("1. Standard Room");
                    Console.WriteLine("2. Deluxe Room");

                    choice = int.Parse(Console.ReadLine());

                } while (choice != 1 && choice != 2);

                Console.Write("Enter Capacity: ");
                int capacity = int.Parse(Console.ReadLine());

                Console.Write("Enter Price Per Night: ");
                double price = double.Parse(Console.ReadLine());


                Room room;
                if (choice == 1)
                {
                    room = new StandardRoom(roomID,"Standard", price,true,capacity);
                }
                else 
                {
                    room = new DeluxeRoom(roomID, "Deluxe", price, true, capacity);
               
                }
               
                rooms[roomCount] = room;
                roomCount++;

                Console.WriteLine("Room Added Successfully");
            }

            //display rooms
            static void DisplayRooms()
                {
                    if (roomCount == 0)
                    {
                        Console.WriteLine("No Rooms Found");
                        return;
                    }

                    for (int i = 0; i < roomCount; i++)
                    {
                        Console.WriteLine("--------------------");

                        Console.WriteLine($"Room ID: {rooms[i].RoomID}");
                        Console.WriteLine($"Room Type: {rooms[i].RoomType}");
                        Console.WriteLine($"Price: {rooms[i].PricePerNight}");
                        Console.WriteLine($"Capacity: {rooms[i].Capacity}");
                        Console.WriteLine($"Available: {rooms[i].IsAvailable}");
                    }
                }

                //add customer
                static void AddCustomer()
                {
                    if (customerCount >= customers.Length)
                    {
                        Console.WriteLine("Customer Storage Is Full!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Customer ID: ");
                        int id = int.Parse(Console.ReadLine());

                        if (id <= 0)
                        {
                            Console.WriteLine("Invalid ID!");
                            return;
                        }

                        for (int i = 0; i < customerCount; i++)
                        {
                            if (customers[i].UserID == id)
                            {
                                Console.WriteLine("Customer ID Already Exists!");
                                return;
                            }
                        }

                        Console.Write("Enter Full Name: ");
                        string name = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Invalid Name!");
                            return;
                        }

                        Console.Write("Enter Phone Number: ");
                        string phone = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(phone))
                        {
                            Console.WriteLine("Invalid Phone Number!");
                            return;
                        }

                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(email))
                        {
                            Console.WriteLine("Invalid Email!");
                            return;
                        }

                        Console.Write("Enter Preferred Room Type: ");
                        string roomType = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(roomType))
                        {
                            roomType = "Standard";
                        }

                        Customer customer = new Customer( id,name, phone,email,roomType,"No Reservations");

                        customers[customerCount] = customer;
                        customerCount++;

                        Console.WriteLine("Customer Added Successfully!");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }

                //search rooms
                static void SearchRoom()
                {
                    if (roomCount == 0)
                    {
                        Console.WriteLine("No Rooms Available!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Room ID: ");
                        int roomId = int.Parse(Console.ReadLine());

                        bool found = false;

                        for (int i = 0; i < roomCount; i++)
                        {
                            if (rooms[i].RoomID == roomId)
                            {
                                Console.WriteLine("\nRoom Found");

                                Console.WriteLine("Room ID: " + rooms[i].RoomID);
                                Console.WriteLine("Room Type: " + rooms[i].RoomType);
                                Console.WriteLine("Price: " + rooms[i].PricePerNight);
                                Console.WriteLine("Available: " + rooms[i].IsAvailable);

                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Room Not Found!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }

                // make reservation
                static void MakeReservation()
                {
                    if (customerCount == 0)
                    {
                        Console.WriteLine("No Customers Found!");
                        return;
                    }

                    if (roomCount == 0)
                    {
                        Console.WriteLine("No Rooms Found!");
                        return;
                    }

                    if (reservationCount >= reservations.Length)
                    {
                        Console.WriteLine("Reservation Storage Full!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Reservation ID: ");
                        int reservationId = int.Parse(Console.ReadLine());

                        for (int i = 0; i < reservationCount; i++)
                        {
                            if (reservations[i].ReservationID == reservationId)
                            {
                                Console.WriteLine("Reservation ID Already Exists!");
                                return;
                            }
                        }

                        Console.Write("Enter Customer ID: ");
                        int customerId = int.Parse(Console.ReadLine());

                        Customer selectedCustomer = null;

                        for (int i = 0; i < customerCount; i++)
                        {
                            if (customers[i].UserID == customerId)
                            {
                                selectedCustomer = customers[i];
                                break;
                            }
                        }

                        if (selectedCustomer == null)
                        {
                            Console.WriteLine("Customer Not Found!");
                            return;
                        }

                        Console.Write("Enter Room ID: ");
                        int roomId = int.Parse(Console.ReadLine());

                        Room selectedRoom = null;

                        for (int i = 0; i < roomCount; i++)
                        {
                            if (rooms[i].RoomID == roomId)
                            {
                                selectedRoom = rooms[i];
                                break;
                            }
                        }

                        if (selectedRoom == null)
                        {
                            Console.WriteLine("Room Not Found!");
                            return;
                        }

                        if (!selectedRoom.IsAvailable)
                        {
                            Console.WriteLine("Room Is Already Reserved!");
                            return;
                        }

                        Console.Write("Enter Number Of Nights: ");
                        int nights = int.Parse(Console.ReadLine());

                        if (nights <= 0)
                        {
                            Console.WriteLine("Invalid Number Of Nights!");
                            return;
                        }

                        DateTime checkIn = DateTime.Now;
                        DateTime checkOut = checkIn.AddDays(nights);

                        double totalCost =
                            selectedRoom.CalculateTotalCost(nights);

                        Reservation reservation =
                            new Reservation(
                                reservationId,
                                selectedCustomer,
                                selectedRoom,
                                checkIn,
                                checkOut,
                                totalCost,
                                "Confirmed"
                                
                               
                            );

                        reservations[reservationCount] = reservation;
                        reservationCount++;

                        selectedRoom.IsAvailable = false;

                        Console.WriteLine("Reservation Created Successfully!");
                        Console.WriteLine("Total Cost = " + totalCost);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }

                // modify reservation

                static void ModifyReservation()
                {
                    if (reservationCount == 0)
                    {
                        Console.WriteLine("No Reservations Found!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Reservation ID: ");
                        int reservationId = int.Parse(Console.ReadLine());


                        Reservation reservation = null;

                        for (int i = 0; i < reservationCount; i++)
                        {
                            if (reservations[i].ReservationID == reservationId)
                            {
                                reservation = reservations[i];
                                break;
                            }
                        }

                        if (reservation == null)
                        {
                            Console.WriteLine("Reservation Not Found!");
                            return;
                        }

                        Console.Write("Enter New Number Of Nights: ");
                        int nights = int.Parse(Console.ReadLine());

                        if (nights <= 0)
                        {
                            Console.WriteLine("Invalid Number Of Nights!");
                            return;
                        }

                        reservation.CheckOutDate =
                            reservation.CheckInDate.AddDays(nights);

                        reservation.TotalCost =
                            reservation.Room.CalculateTotalCost(nights);

                        Console.WriteLine("Reservation Updated Successfully!");

                        Console.WriteLine("New Total Cost = "
                                          + reservation.TotalCost);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }

                // cancel reservation
                static void CancelReservation()
                {
                    if (reservationCount == 0)
                    {
                        Console.WriteLine("No Reservations Found!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Reservation ID: ");
                        int reservationId = int.Parse(Console.ReadLine());

                        int index = -1;

                        for (int i = 0; i < reservationCount; i++)
                        {
                            if (reservations[i].ReservationID == reservationId)
                            {
                                index = i;
                                break;
                            }
                        }

                        if (index == -1)
                        {
                            Console.WriteLine("Reservation Not Found!");
                            return;
                        }

                        reservations[index].Room.IsAvailable = true;

                        for (int i = index; i < reservationCount - 1; i++)
                        {
                            reservations[i] = reservations[i + 1];
                        }

                        reservations[reservationCount - 1] = null;

                        reservationCount--;

                        Console.WriteLine("Reservation Cancelled Successfully!");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }
                // process payment
                static void ProcessPayment()
                {
                    if (reservationCount == 0)
                    {
                        Console.WriteLine("No Reservations Found!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Reservation ID: ");
                        int reservationId = int.Parse(Console.ReadLine());

                        Reservation reservation = null;

                        for (int i = 0; i < reservationCount; i++)
                        {
                            if (reservations[i].ReservationID == reservationId)
                            {
                                reservation = reservations[i];
                                break;
                            }
                        }

                        if (reservation == null)
                        {
                            Console.WriteLine("Reservation Not Found!");
                            return;
                        }

                        Console.WriteLine("1. Cash Payment");
                        Console.WriteLine("2. Credit Card Payment");

                        Console.Write("Choose Payment Method: ");
                        int choice = int.Parse(Console.ReadLine());

                        Payment payment;

                        switch (choice)
                        {
                            case 1:
                                payment = new CashPayment(reservation.TotalCost);
                                payment.ProcessPayment();
                                break;

                            case 2:
                                payment = new CreditCardPayment(reservation.TotalCost);
                                payment.ProcessPayment();
                                break;

                            default:
                                Console.WriteLine("Invalid Choice!");
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }
                // generate receipt
                static void GenerateReceipt()
                {
                    if (reservationCount == 0)
                    {
                        Console.WriteLine("No Reservations Found!");
                        return;
                    }

                    try
                    {
                        Console.Write("Enter Reservation ID: ");
                        int reservationId = int.Parse(Console.ReadLine());

                        Reservation reservation = null;

                        for (int i = 0; i < reservationCount; i++)
                        {
                            if (reservations[i].ReservationID == reservationId)
                            {
                                reservation = reservations[i];
                                break;
                            }
                        }

                        if (reservation == null)
                        {
                            Console.WriteLine("Reservation Not Found!");
                            return;
                        }

                        Console.WriteLine("\n===== RECEIPT =====");

                        Console.WriteLine("Reservation ID: " + reservation.ReservationID);

                        Console.WriteLine("Customer Name: "+ reservation.Customer.FullName);

                        Console.WriteLine("Room ID: "+ reservation.Room.RoomID);

                        Console.WriteLine("Room Type: "+ reservation.Room.RoomType);

                        Console.WriteLine("Check In: "+ reservation.CheckInDate);

                        Console.WriteLine("Check Out: " + reservation.CheckOutDate);

                        Console.WriteLine("Status: "+ reservation.ReservationStatus);

                        Console.WriteLine("Total Cost: " + reservation.TotalCost);

                        Console.WriteLine("===================");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }





            }



        }
    }

