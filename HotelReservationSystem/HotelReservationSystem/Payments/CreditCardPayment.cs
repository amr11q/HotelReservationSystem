using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Payments
{
    public class CreditCardPayment : Payment
    {
       
        public CreditCardPayment(double amount): base(amount)
        {

        }

        
        public override void ProcessPayment()
        {
            Console.WriteLine("Credit Card Payment Processed Successfully");
        }
    }
}
