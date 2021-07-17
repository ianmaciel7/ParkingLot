using System;

namespace CarParking.Exceptions
{
    public class ExceededTheLimitException : Exception
    {
        public ExceededTheLimitException()
            : base("Não foi possível inserir novo objeto, o limite da lista de objetos foi excedida")
        {
        }
    }
}
