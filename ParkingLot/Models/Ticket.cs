using System;

namespace CarParking.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double FinalPrice { get; set; }

        public Ticket()
        {

        }

        public Ticket(int ticketId, VehicleType vehicleType, DateTime arrivalTime, PaymentStatus paymentStatus)
        {
            TicketId = ticketId;
            VehicleType = vehicleType;
            ArrivalTime = arrivalTime;
            PaymentStatus = paymentStatus;
        }

        public Ticket(int ticketId, VehicleType vehicleType, DateTime arrivalTime, DateTime departureTime, PaymentStatus paymentStatus, double finalPrice)
        {
            TicketId = ticketId;
            VehicleType = vehicleType;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            PaymentStatus = paymentStatus;
            FinalPrice = finalPrice;
        }
    }
}
