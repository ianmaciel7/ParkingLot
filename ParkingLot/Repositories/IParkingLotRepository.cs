using CarParking.Models;
using System.Collections.Generic;

namespace CarParking.Repositories
{
    public interface IParkingLotRepository
    {
        public Ticket GetTicket(int ticketId);
        public IEnumerable<Ticket> AllTicket();
        public void InsertTicket(Ticket ticket);
        public IEnumerable<ParkingSpace> AllParkingSpaces();
        public bool HasAnyEmptyParkingSpaces();
        public ParkingSpace GetAnyEmptyParkingSpaces();
        public void InsertTicketInParkingSpace(Ticket ticket, ParkingSpace parkingSpace);
        double GetPricePerHour(VehicleType vehicleType);
    }
}