namespace CarParking.Models
{
    public class ParkingSpace
    {
        public int ParkingSpaceId { get; set; }
        public Ticket Ticket { get; set; }

        public ParkingSpace(int parkingSpaceId)
        {
            ParkingSpaceId = parkingSpaceId;
        }
    }
}
