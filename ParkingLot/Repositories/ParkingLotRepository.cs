using CarParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarParking.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private static ParkingLot _parkingLot = new ParkingLot()
        {
            Prices = new Dictionary<VehicleType, double>(),
            ParkingSpaces = new List<ParkingSpace>() { new ParkingSpace(1), new ParkingSpace(2) },
            Tickets = new List<Ticket>() { new Ticket(1, VehicleType.CAR, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), PaymentStatus.PAID, 264) }
        };

        static ParkingLotRepository()
        {
            _parkingLot.Prices.Add(VehicleType.CAR, 11);
            _parkingLot.Prices.Add(VehicleType.MOTORCYCLE, 5);
        }

        public IEnumerable<ParkingSpace> AllParkingSpaces()
        {
            return _parkingLot.ParkingSpaces.ToArray();
        }

        public IEnumerable<Ticket> AllTicket()
        {
            return _parkingLot.Tickets.ToArray();
        }

        public Ticket GetTicket(int ticketId)
        {
            return _parkingLot.Tickets.FirstOrDefault(v => v.TicketId == ticketId);
        }

        public ParkingSpace GetAnyEmptyParkingSpaces()
        {
            var parkingSpaces = _parkingLot.ParkingSpaces;
            var p = parkingSpaces.FirstOrDefault(p => p.Ticket == null);
            return p;
        }

        public void InsertTicket(Ticket ticket)
        {
            _parkingLot.Tickets.Add(ticket);
        }

        public bool HasAnyEmptyParkingSpaces()
        {
            var parkingSpaces = _parkingLot.ParkingSpaces;
            var p = parkingSpaces.FirstOrDefault(p => p.Ticket == null);
            if (p != null) return true;
            return false;
        }

        public void InsertTicketInParkingSpace(Ticket ticket, ParkingSpace parkingSpace)
        {
            var p = _parkingLot.ParkingSpaces.FirstOrDefault(p => p == parkingSpace);
            p.Ticket = ticket;
        }

        public double GetPricePerHour(VehicleType vehicleType)
        {
            return _parkingLot.Prices[vehicleType];
        }
    }
}
