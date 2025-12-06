using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Billings
{
    public class Folio
    {
        public int ReservationId { get; set; }
        public List<InvoiceItem> Items { get; set; }

        public Folio(int reservationId)
        {
            ReservationId = reservationId;
            Items = new List<InvoiceItem>();
        }

        public decimal TotalAmount()
        {
            decimal total = 0;
            foreach (var item in Items) total += item.Amount;
            return total;
        }
    }
}