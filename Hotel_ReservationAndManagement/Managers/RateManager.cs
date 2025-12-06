using Hotel_ReservationAndManagement.Rates;
using Hotel_ReservationAndManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class RateManager
    {
        private RateRepository rateRepo;

        public RateManager()
        {
            rateRepo = new RateRepository();
        }

        public decimal GetRate(int roomTypeId, string rateType)
        {
            // Example: VIP, Corporate, Standard
            return rateRepo.GetRate(roomTypeId, rateType);
        }

        public List<RateConfiguration> GetAllRates()
        {
            return rateRepo.GetAllRates();
        }
    }
}