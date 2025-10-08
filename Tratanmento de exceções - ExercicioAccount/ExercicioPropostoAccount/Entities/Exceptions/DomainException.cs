using System;

namespace ExercicioPropostoAccount.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message) 
        {
        }
    }
}
