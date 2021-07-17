using CarParking.Exceptions;
using CarParking.Models;
using CarParking.Repositories;
using CarParking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParking.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<IEnumerable<ParkingSpace>> AllParkingSpaces()
        {
            var p = _parkingLotRepository.AllParkingSpaces();
            if (!p.Any()) throw new EmptyListException();
            return p;
        }

        public async Task<IEnumerable<Ticket>> AllTicket()
        {
            var t = _parkingLotRepository.AllTicket();
            if (!t.Any()) throw new EmptyListException();
            return t;
        }

        public async Task<Ticket> GetTicket(int ticketId)
        {
            Ticket ticket = _parkingLotRepository.GetTicket(ticketId);
            if (ticket == null) throw new TicketNotFoundException();
            return _parkingLotRepository.GetTicket(ticketId);
        }

        public Ticket InsertTicket(TicketInputModel model)
        {

            if (model.TimeOfArrival == "") throw new InsertNullFieldException("Hora da chegada");
            if (model.VehicleType == "") throw new InsertNullFieldException("Tipo do veículo");

            if (!Enum.IsDefined(typeof(VehicleType), model.VehicleType))
                throw new InsertInvalidEnumException("Tipo do veículo");

            if (!DateTime.TryParse(model.TimeOfArrival, out DateTime theDate))
                throw new InsertInvalidDateException("Hora da chegada");

            if (!_parkingLotRepository.HasAnyEmptyParkingSpaces()) throw new ExceededTheLimitException();
            var parkingSpace = _parkingLotRepository.GetAnyEmptyParkingSpaces();

            Ticket ticket = new Ticket()
            {
                TicketId = _parkingLotRepository.AllTicket().Max(p => p.TicketId) + 1,
                PaymentStatus = PaymentStatus.UNPAID,
                ArrivalTime = DateTime.Parse(model.TimeOfArrival),
                VehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), model.VehicleType.ToString()),
            };


            _parkingLotRepository.InsertTicket(ticket);
            _parkingLotRepository.InsertTicketInParkingSpace(ticket, parkingSpace);
            return _parkingLotRepository.GetTicket(ticket.TicketId);
        }

        public void RemoveTicketFromParkingSpace(int ticketId)
        {
            var parkingSpace = _parkingLotRepository.AllParkingSpaces()
                 .Where(p => p.Ticket != null)
                 .FirstOrDefault(p => p.Ticket.TicketId == ticketId);
            if (parkingSpace == null) throw new TicketNotFoundException();

            parkingSpace.Ticket = null;
        }

        public ReportFinancialGainPerDayViewModel TotalSoldPerDay()
        {
            var viewModel = new ReportFinancialGainPerDayViewModel();
            double totalPricePerHourPaid = 0;

            var groupPaid = _parkingLotRepository.AllTicket()
            .Where(t => t.PaymentStatus == PaymentStatus.PAID)
            .GroupBy(t => t.DepartureTime.Date);

            foreach (var item in groupPaid)
            {
                totalPricePerHourPaid = 0;
                foreach (var subItem in item.ToList())
                {
                    totalPricePerHourPaid += subItem.FinalPrice;
                }
                viewModel.ListPaid.Add(new FinancialGainPerDayViewModel(totalPricePerHourPaid, item.Key));
            }

            var groupUnpaid = _parkingLotRepository.AllTicket()
           .Where(t => t.PaymentStatus == PaymentStatus.UNPAID);

            viewModel.listUnpaid = groupUnpaid.ToList();
            return viewModel;

        }

        public Ticket UpdatePaymentStatusInTicket(int ticketId)
        {
            var t = _parkingLotRepository.GetTicket(ticketId);
            if (t == null) throw new TicketNotFoundException();
            t.DepartureTime = DateTime.Now;
            t.PaymentStatus = PaymentStatus.PAID;
            var ticketHours = (t.DepartureTime - t.ArrivalTime).TotalHours;
            var pricePerHour = ticketHours * _parkingLotRepository.GetPricePerHour(t.VehicleType);
            t.FinalPrice = Math.Round(pricePerHour, 2);
            return t;
        }
    }
}
