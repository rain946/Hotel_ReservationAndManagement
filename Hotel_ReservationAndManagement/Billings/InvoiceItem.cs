using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Billings
{
    public class InvoiceItem
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public InvoiceItem(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }
    }
}