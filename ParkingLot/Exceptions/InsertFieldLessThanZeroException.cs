using System;

namespace CarParking.Exceptions
{
    public class InsertFieldLessThanZeroException : Exception
    {
        public InsertFieldLessThanZeroException(string name)
            : base($"Não foi possível inserir novo objeto, o campo {name} precisa ser um número maior que 0")
        {
        }
    }
}
