using System;

namespace CarParking.Exceptions
{
    public class InsertNullFieldException : Exception
    {
        public InsertNullFieldException()
            : base($"Não foi possível inserir novo objeto, o objeto não pode ser nulo")
        {
        }
        public InsertNullFieldException(string name)
            : base($"Não foi possível inserir novo objeto, o campo {name} não pode ser nulo")
        {
        }
    }
}
