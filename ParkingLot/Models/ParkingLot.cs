using System.Collections.Generic;

namespace CarParking.Models
{
    public class ParkingLot
    {
        public int ParkingLotId { get; set; }
        public IDictionary<VehicleType, double> Prices { get; set; }
        public ICollection<ParkingSpace> ParkingSpaces { get; set; }
        public ICollection<Ticket> Tickets { get; set; }


    }
}
