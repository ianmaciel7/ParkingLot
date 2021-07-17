namespace CarParking.Models
{
    public class TicketInputModel
    {
        public string VehicleType { get; set; }
        public string TimeOfArrival { get; set; }

        public TicketInputModel(string vehicleType, string timeOfArrival)
        {
            VehicleType = vehicleType;
            TimeOfArrival = timeOfArrival;
        }
    }
}
