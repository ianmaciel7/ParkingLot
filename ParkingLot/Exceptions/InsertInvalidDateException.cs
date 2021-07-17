using System;

namespace CarParking.Exceptions
{
    public class InsertInvalidDateException : Exception
    {
        public InsertInvalidDateException(string name) :
            base($"Não foi possível inserir novo objeto, o campo {name} não recebeu uma data válida")
        {
        }
    }
}
