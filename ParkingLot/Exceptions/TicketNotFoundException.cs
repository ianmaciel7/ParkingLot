using System;

namespace CarParking.Exceptions
{
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException()
            : base("Não foi possível encontrar objeto ticket")
        {
        }
    }
}
