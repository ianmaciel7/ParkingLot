using System;

namespace CarParking.Exceptions
{
    public class InsertInvalidEnumException : Exception
    {
        public InsertInvalidEnumException(string name) :
            base($"Não foi possível inserir novo objeto, o campo {name} não recebeu código válido para encontrar sua categoria no enum")
        {
        }
    }
}
