//Implementação da Domain Exception --- Exceção Personalizada

using System;

namespace ProblemaExemploReservation.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message) 
        {
        }
    }
}
