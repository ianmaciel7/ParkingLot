using CarParking.Models;
using CarParking.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarParking.Services
{
    public interface IParkingLotService
    {
        public Task<Ticket> GetTicket(int ticketId);
        public Task<IEnumerable<Ticket>> AllTicket();
        public Ticket InsertTicket(TicketInputModel model);
        public Task<IEnumerable<ParkingSpace>> AllParkingSpaces();
        public ReportFinancialGainPerDayViewModel TotalSoldPerDay();
        public Ticket UpdatePaymentStatusInTicket(int ticketId);
        public void RemoveTicketFromParkingSpace(int ticketId);
    }
}
