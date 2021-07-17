using System;

namespace CarParking.Exceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException()
            : base("A lista esta vazia")
        {
        }
    }
}
