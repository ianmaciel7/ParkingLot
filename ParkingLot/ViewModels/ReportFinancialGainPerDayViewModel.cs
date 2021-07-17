using CarParking.Models;
using System.Collections.Generic;

namespace CarParking.ViewModels
{
    public class ReportFinancialGainPerDayViewModel
    {
        public ICollection<FinancialGainPerDayViewModel> ListPaid { get; set; }
        public ICollection<Ticket> listUnpaid { get; set; }
        public ReportFinancialGainPerDayViewModel()
        {
            ListPaid = new List<FinancialGainPerDayViewModel>();
            listUnpaid = new List<Ticket>();
        }
    }
}
