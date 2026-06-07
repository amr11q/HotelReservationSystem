using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Payments
{
    public class CashPayment : Payment
    {
        
        public CashPayment(double amount)

            : base(amount)
        {
        }

        
        public override void ProcessPayment()
        {
            Console.WriteLine("Cash Payment Processed Successfully");
        }
    }
}
