using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Payments
{
    public abstract class Payment
    {
        
        private double amount;

        


        public double Amount
        {
            get { return amount; }

            set
            {
                if (value > 0)
                {
                    amount = value;
                }
                else
                {
                    Console.WriteLine("Invalid Amount");
                }
            }
        }

       
        public Payment(double amount)
        {
            Amount = amount;
        }

        
        public abstract void ProcessPayment();
    }
}
