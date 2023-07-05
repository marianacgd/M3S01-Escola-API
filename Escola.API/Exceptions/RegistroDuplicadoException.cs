using System;

namespace Escola.API.Exceptions
{
    public class RegistroDuplicadoException : Exception
    {
        public RegistroDuplicadoException(string message) :base (message)
        {
            
        }
    }
}
