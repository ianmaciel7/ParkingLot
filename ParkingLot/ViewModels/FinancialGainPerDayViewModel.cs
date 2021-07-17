using System;

namespace CarParking.ViewModels
{
    public class FinancialGainPerDayViewModel
    {
        public double FinancialGain { get; set; }
        public DateTime Date { get; set; }
        public FinancialGainPerDayViewModel(double financialGain, DateTime date)
        {
            FinancialGain = financialGain;
            Date = date;
        }
    }
}
