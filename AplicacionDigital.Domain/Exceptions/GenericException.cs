using System;

namespace AplicacionDigital.Domain.Exceptions
{
    public class GenericException: Exception
    {
        const string baseMessage = "Error message";        
        public GenericException()            
        {
             
        }
        public GenericException(string message)
            : base($"{baseMessage}: {message}")
        {
        }
        public GenericException(string message, Exception Ex)
            : base($"{baseMessage}: {message}", Ex)
        {
        }
    }
}
